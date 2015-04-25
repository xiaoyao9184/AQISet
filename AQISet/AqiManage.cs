using System;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using AQI;
using AQI.Interface;
using AQISet.Interface;
using AQISet.Collection;
using AQISet.Saver;
using AQISet.Runner;
using AQISet.Cfg;
using Helper.Setting;
using System.Threading;

namespace AQISet
{
    /// <summary>
    /// 管理者
    /// </summary>
    public sealed class AqiManage : IThrowMessage
    {

        #region 枚举

        enum RunMode
        {
            NONE, SELF, JOINT
        }

        #endregion

        #region 事件

        //定义delegate
        public delegate void ManageEventHandler(RunMessage m);
        //用event 关键字声明事件对象
        public event ManageEventHandler ManageEvent;
        //传递事件
        private void TransferEvent(RunMessage runmsg)
        {
            if (ManageEvent != null)
            {
                runmsg.PutMessageSender(this);
                ManageEvent(runmsg);
            }
        }
        //抛出事件
        public bool ThrowEvent(RunMessage eRunMessage)
        {
            if (ManageEvent != null)
            {
                ManageEvent(eRunMessage);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ThrowEvent(RunMessage.RunType eType, string eMsg)
        {
            if (ManageEvent != null)
                ManageEvent(new RunMessage(eType, eMsg, this));
        }

        #endregion

        #region 字段

        private static string Tag = "AQIManage";
        private IAqiSave aqiSaver;      //存储者
        private AqiRunner aqiRunner;    //运行者
        private AqiNoter aqiNoter;      //记录者
        private AqiRetryer aqiRetryer;  //重试者
        private List<Assembly> allDLLs;                 //所有程序集
        private Dictionary<string, IAqiWeb> allAqiWebs; //所有数据源
        private Dictionary<string, ISrcUrl> allSrcUrls; //所有数据接口
        private Dictionary<string, AqiRunner> runnerlist;

        private ReaderWriterLockSlim thisLock;       //读写锁

        #endregion

        #region 属性

        public string Name
        {
            get
            {
                return Tag;
            }
        }

        public IAqiSave AqiSave
        {
            get
            {
                return aqiSaver;
            }
        }

        public AqiNoter AqiNote
        {
            get
            {
                return aqiNoter;
            }
        }

        public AqiRetryer AqiRetry
        {
            get
            {
                return aqiRetryer;
            }
        }

        public AqiRunner AqiRun
        {
            get
            {
                return aqiRunner;
            }
        }

        public InstanceSettingHelper AqiSetting
        {
            get
            {
                return Setting;
            }
        }

        /// <summary>
        /// 设置
        /// </summary>
        public static InstanceSettingHelper Setting
        {
            get
            {
                return InstanceSettingHelper.Instance;
            }
        }

        /// <summary>
        /// 根据名称索引运行者
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public AqiRunner this[string name]
        {
            get
            {
                AqiRunner r = null;
                thisLock.EnterReadLock();
                {
                    RunMode rm = (RunMode)Enum.Parse(typeof(RunMode), AqiManage.Setting["RunMode"]);
                    switch (rm)
                    {
                        case RunMode.SELF:
                            if (runnerlist.ContainsKey(name))
                            {
                                r = runnerlist[name];
                            }
                            break;
                        case RunMode.JOINT:
                        default:
                            r = aqiRunner;
                            break;
                    }
                }
                thisLock.ExitReadLock();
                return r;
            }
        }

        #endregion

        public AqiManage()
        {
            thisLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);


            allDLLs = new List<Assembly>();
            InitDll();

            allAqiWebs = new Dictionary<string, IAqiWeb>();
            InitAqiWeb();

            allSrcUrls = new Dictionary<string, ISrcUrl>();
            InitSrcUrl();

            
            

            
            initSaver();
            //aqiSaver = new AqiFileSaver(this);
            aqiNoter = new AqiNoter(this);

            //目前默认为一个Retryer
            aqiRetryer = new AqiRetryer(this);

            initRunner();

            //目前默认为一个Runner
            //aqiRunner = new AqiRunner(this, allSrcUrls);
            //aqiRunner.RunEvent += new AqiRunner.RunEventHandler(aqiRunner_RunEvent);
        }

        #region 内部方法

        /// <summary>
        /// 初始化DLL程序集
        /// </summary>
        private void InitDll()
        {
            //DLL路径
            string ExePath = Assembly.GetExecutingAssembly().Location;
            int p = ExePath.LastIndexOf('\\');
            string DllPath = ExePath.Substring(0, p);
            DirectoryInfo TheFolder = new DirectoryInfo(DllPath);
            //遍历文件
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                if (NextFile.Name.IndexOf("AQI") > 1)
                {
                    try
                    {
                        Assembly ass = Assembly.LoadFrom(NextFile.FullName);
                        allDLLs.Add(ass);
                        Console.WriteLine("加载程序集:" + ass.FullName);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 初始化IAqiWeb接口
        /// </summary>
        private void InitAqiWeb()
        {
            foreach(Assembly ass in allDLLs)
            {
                Type[] types = ass.GetTypes();
                foreach (Type type in types)
                {
                    if (type.GetInterface("IAqiWeb") != null)
                    {
                        IAqiWeb iaw = Activator.CreateInstance(type) as IAqiWeb;
                        allAqiWebs.Add(iaw.TAG, iaw);
                        Console.WriteLine("加载数据源:" + iaw.NAME);
                    }
                }
            }
        }

        /// <summary>
        /// 初始化ISrcUrl接口
        /// </summary>
        private void InitSrcUrl()
        {
            foreach (IAqiWeb iaw in allAqiWebs.Values)
            {
                Dictionary<string, ISrcUrl> temp = iaw.getAllSrcUrl();
                allSrcUrls = allSrcUrls.Concat(temp).ToDictionary(x => x.Key, x => x.Value);
                //TODO 对不同更新时间的数据接口加载到不同的集合里面
                Console.WriteLine("整合数据源接口:" + iaw.NAME);
            }
        }

        /// <summary>
        /// 初始化存储者
        /// </summary>
        private void initSaver()
        {
            //读取配置文件，使用不同Saver
            string name = AqiManage.Setting["Saver"];
            Type type = Type.GetType("AQISet.Saver." + name);
            aqiSaver = Activator.CreateInstance(type,new object[]{ this }) as IAqiSave;
        }

        /// <summary>
        /// 初始化运行者
        /// </summary>
        private void initRunner()
        {
            //读取配置文件，独立或合并
            RunMode rm = (RunMode)Enum.Parse(typeof(RunMode), AqiManage.Setting["RunMode"]);
            switch (rm)
            {
                case RunMode.SELF:
                    runnerlist = new Dictionary<string, AqiRunner>();
                    foreach(IAqiWeb iaw in allAqiWebs.Values)
                    {
                        AqiRunner ar = new AqiRunner(this, iaw.getAllSrcUrl(), iaw.TAG + "_Runner");
                        runnerlist.Add(ar.Name, ar);
                    }
                    break;
                case RunMode.JOINT:
                default:
                    aqiRunner = new AqiRunner(this, allSrcUrls);
                    aqiRunner.RunEvent += new AqiRunner.RunEventHandler(aqiRunner_RunEvent);
                    break;
            }
        }

        #endregion

        #region 公共方法

        #region 基本控制

        /// <summary>
        /// 运行所有
        /// </summary>
        /// <returns></returns>
        public bool RunAll()
        {
            if (runnerlist ==null || runnerlist.Count <= 0)
            { return false; }

            ThrowEvent(RunMessage.RunType.TIP,"开始全部运行");

            foreach (AqiRunner runner in runnerlist.Values)
            {
                runner.RunAll();
            }
            
            return true;
        }

        /// <summary>
        /// 结束所有
        /// </summary>
        /// <returns></returns>
        public bool EndAll()
        {
            if (runnerlist == null || runnerlist.Count <= 0)
            { return false; }

            ThrowEvent(RunMessage.RunType.TIP, "结束全部运行");
            foreach (AqiRunner runner in runnerlist.Values)
            {
                runner.EndAll();
            }
            return true;
        }

        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="name">运行者名称</param>
        /// <returns></returns>
        public bool Run(string name)
        {
            if(String.IsNullOrEmpty(name))
            {
                if(aqiRunner != null)
                {
                    ThrowEvent(RunMessage.RunType.TIP, "开始运行:" + aqiRunner.Name);
                    aqiRunner.RunAll();
                    return true;
                }
            }
            else
            {
                if (runnerlist.ContainsKey(name)) 
                {
                    ThrowEvent(RunMessage.RunType.TIP, "开始运行:" + name);
                    runnerlist[name].RunAll();
                    return true;
                }
            }

            //默认不存在
            ThrowEvent(RunMessage.RunType.ERR, "不存在运行者:" + name);
            return false;
        }

        /// <summary>
        /// 结束
        /// </summary>
        /// <param name="name">运行者名称</param>
        /// <returns></returns>
        public bool End(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                if (aqiRunner != null)
                {
                    ThrowEvent(RunMessage.RunType.TIP, "结束运行:" + aqiRunner.Name);
                    aqiRunner.EndAll();
                    return true;
                }
            }
            else
            {
                if (runnerlist.ContainsKey(name))
                {
                    ThrowEvent(RunMessage.RunType.TIP, "结束运行:" + name);
                    runnerlist[name].EndAll();
                    return true;
                }
            }

            //默认不存在
            ThrowEvent(RunMessage.RunType.ERR, "不存在运行者:" + name);
            return false;
        }

        #endregion

        #region 动态控制

        /// <summary>
        /// 添加runner
        /// </summary>
        /// <param name="runner"></param>
        public void Add(AqiRunner runner)
        {
            if (runnerlist.ContainsKey(runner.Name))
            {
                runnerlist[runner.Name].Union(runner);
            }
            else
            {
                runnerlist.Add(runner.Name, runner);
                runner.RunAll();
            }
        }

        /// <summary>
        /// 删除runner
        /// </summary>
        /// <param name="runnername"></param>
        public void Dele(string runnername)
        {
            if (runnerlist.ContainsKey(runnername))
            {
                runnerlist[runnername].EndAll();
                runnerlist.Remove(runnername);
            }
        }

        /// <summary>
        /// 添加 数据源
        /// </summary>
        /// <param name="iaw">数据源</param>
        public void AddAqiWeb(IAqiWeb iaw)
        {
            thisLock.EnterUpgradeableReadLock();
            {
                if (allAqiWebs.ContainsKey(iaw.TAG))
                {
                    //移出旧数据
                    ThrowEvent(RunMessage.RunType.TIP, "数据源已经存在，进行更新:" + iaw.TAG);
                    allAqiWebs.Remove(iaw.TAG);
                }

                //1添加到All集合
                Dictionary<string, ISrcUrl> temp = iaw.getAllSrcUrl();
                thisLock.EnterWriteLock();
                {
                    //添加到列表
                    allAqiWebs.Add(iaw.TAG, iaw);
                    allSrcUrls = allSrcUrls.Concat(temp).ToDictionary(x => x.Key, x => x.Value);
                }
                thisLock.ExitWriteLock();

                //2应用到具体的Runner
                AqiRunner runner = this[iaw.TAG + "_Runner"];
                if (runner == null)
                {
                    //独立模式&&不存在
                    runner = new AqiRunner(this, temp, iaw.TAG + "_Runner");
                    //新添加
                    Add(runner);
                }
                else
                {
                    //只给数据
                    runner.AddSrcUrl(temp);
                }

            }
            thisLock.ExitUpgradeableReadLock();
        }

        /// <summary>
        /// 删除 数据源
        /// </summary>
        /// <param name="awname">数据源名称</param>
        public IAqiWeb DeleAqiWeb(string awname)
        {
            IAqiWeb iaw = null;

            //1删除具体的Runner
            AqiRunner runner = this[awname + "_Runner"];
            if (aqiRunner != null)
            {
                aqiRunner.DeleSrcUrl(awname);
            }

            //2删除All集合
            if (allAqiWebs.ContainsKey(awname))
            {
                iaw = allAqiWebs[awname];
                allAqiWebs.Remove(awname);
            }
            List<string> tlist = new List<string>();
            foreach (ISrcUrl isu in allSrcUrls.Values)
            {
                if (isu.IAW.TAG == awname)
                {
                    tlist.Add(isu.TAG);
                }
            }
            foreach (string isutag in tlist)
            {
                allSrcUrls.Remove(isutag);
            }

            return iaw;
        }

        #endregion

        /// <summary>
        /// 添加插件
        /// </summary>
        /// <param name="path">程序集路径</param>
        public IAqiWeb LoadDll(string dllpath)
        {
            try
            {
                //1过滤DLL
                IAqiWeb iaw = null;
                Assembly ass = Assembly.LoadFrom(dllpath);
                Type[] types = ass.GetTypes();
                foreach (Type type in types)
                {
                    if (type.GetInterface("IAqiWeb") != null)
                    {
                        iaw = Activator.CreateInstance(type) as IAqiWeb;
                    }
                }

                if(iaw == null)
                {
                    //无接口
                    ThrowEvent(RunMessage.RunType.ERR, "程序集未实现IAqiWeb接口:" + ass.FullName);
                    return null;
                }

                if (allDLLs.Exists(dll =>
                {
                    if (dll.FullName == ass.FullName)
                    {
                        return true; 
                    }
                    return false; 
                }))
                {
                    //存在
                    ThrowEvent(RunMessage.RunType.TIP, "程序集已经存在:" + ass.FullName);
                    allDLLs.Remove(ass);
                }
                allDLLs.Add(ass);

                //if (allAqiWebs.ContainsKey(iaw.TAG))
                //{
                //    //存在
                //    ThrowEvent(RunMessage.RunType.TIP, "数据源已经存在:" + iaw.TAG);
                //    allAqiWebs.Remove(iaw.TAG);
                //}
                //allAqiWebs.Add(iaw.TAG,iaw);

                return iaw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// 删除插件
        ///     确保卸载之前已经从Runner移除
        /// </summary>
        /// <param name="name">IAW名称或程序集名称</param>
        public void UnLoadDll(string name)
        {
            if (allAqiWebs.ContainsKey(name))
            {
                allDLLs.Remove(allAqiWebs[name].GetType().Assembly);
                allAqiWebs.Remove(name);
                ThrowEvent(RunMessage.RunType.ERR, "移除数据源插件成功:" + name);
            }
            else
            {
                ThrowEvent(RunMessage.RunType.ERR, "移除数据源插件失败:" + name);
            }
        }


        /// <summary>
        /// 显示信息
        /// </summary>
        public void ShowInfo()
        {

        }

        #endregion

        #region 事件

        private void aqiRunner_RunEvent(RunMessage m)
        {
            TransferEvent(m);
        }

        #endregion

    }
}
