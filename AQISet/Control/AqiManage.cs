using System;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using Helper.Setting;
using AQI;
using AQI.Interface;
using AQISet.Interface;
using AQISet.Collection;
using AQISet.Control;
using AQISet.Control.Saver;
using AQISet.Cfg;


namespace AQISet.Control
{
    /// <summary>
    /// 管理者
    /// </summary>
    public sealed class AqiManage : IThrowMessage, ISubObject, IStatus
    {

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

        private static string tag = "AQIManage";
        private Dictionary<string, AqiRunner> aqiRunner;    //运行者
        private IAqiSave aqiSaver;      //存储者
        private AqiNoter aqiNoter;      //记录者
        private AqiRetryer aqiRetryer;  //重试者

        private ReaderWriterLockSlim thisLock;       //读写锁

        #endregion

        #region 属性

        public static AqiPlugin Plugin
        {
            get
            {
                return AqiPlugin.Instance;
            }
        }

        public static AqiRemind Remind
        {
            get
            {
                return AqiRemind.Instance;
            }
        }

        public static AqiSetting Setting
        {
            get
            {
                return AqiSetting.Instance;
            }
        }

        public Dictionary<string, AqiRunner> AqiRun
        {
            get
            {
                return this.aqiRunner;
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

        /// <summary>
        /// 根据名称索引运行者
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public AqiRunner this[string name]
        {
            get
            {
                AqiRunner runner = null;
                this.thisLock.EnterReadLock();
                string str = Setting[AqiRunner.SET_RUNMODE];
                if (str == null)
                {
                    str = AqiRunner.RunMode.JOINT.ToString();
                }
                switch (((AqiRunner.RunMode) Enum.Parse(typeof(AqiRunner.RunMode), str)))
                {
                    case AqiRunner.RunMode.SELF:
                        if (this.aqiRunner.ContainsKey(name))
                        {
                            runner = this.aqiRunner[name];
                        }
                        break;

                    default:
                        runner = this.aqiRunner[AqiRunner.DEFAULT_NAME];
                        break;
                }
                this.thisLock.ExitReadLock();
                return runner;
            }
        }

        #endregion

        #region 构造/初始化

        public AqiManage()
        {
            thisLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

            this.init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void init()
        {
            try
            {
                Remind.Log_Info(Plugin.GetInfo(), tag);
                this.aqiNoter = new AqiNoter(this);
                this.aqiRetryer = new AqiRetryer(this);
                this.initSaver();
                this.initRunner();
            }
            catch(Exception ex)
            {
                Remind.Log_Error("初始化失败", ex, tag);
            }
        }

        /// <summary>
        /// 初始化运行者
        /// </summary>
        private void initRunner()
        {
            this.aqiRunner = new Dictionary<string, AqiRunner>();
            AqiRunner runner = null;
            //读取配置文件，独立或合并
            switch (((AqiRunner.RunMode) Enum.Parse(typeof(AqiRunner.RunMode), Setting[AqiRunner.SET_RUNMODE])))
            {
                case AqiRunner.RunMode.SELF:
                    List<IAqiWeb> aqiWebList = AqiPlugin.Instance.GetAqiWebList();
                    foreach (IAqiWeb web in aqiWebList)
                    {
                        runner = new AqiRunner(this, web.GetAllSrcUrl().Values.ToList(), web.Tag + "_Runner");
                        runner.RunEvent += new AqiRunner.RunEventHandler(this.aqiRunner_RunEvent);
                        this.aqiRunner.Add(runner.Name, runner);
                        Remind.Log_Debug("初始化Runner:" + runner.Name, tag);
                    }
                    break;
                case AqiRunner.RunMode.JOINT:
                    runner = new AqiRunner(this, AqiPlugin.Instance.GetSrcUrlList());
                    runner.RunEvent += new AqiRunner.RunEventHandler(this.aqiRunner_RunEvent);
                    this.aqiRunner.Add(AqiRunner.DEFAULT_NAME, runner);
                    Remind.Log_Debug("初始化单一Runner:" + runner.Name, tag);
                    break;
            }
        }

        /// <summary>
        /// 初始化存储者
        /// </summary>
        private void initSaver()
        {
            this.aqiSaver = Plugin.CreateSave(AqiManage.Setting["Saver"]);
            
            Remind.Log_Debug("初始化Saver:" + this.aqiSaver.Name, tag);
        }

        #endregion

        #region 基本控制

        /// <summary>
        /// 运行所有
        /// </summary>
        /// <returns></returns>
        public bool RunAll()
        {
            if ((this.aqiRunner == null) || (this.aqiRunner.Count <= 0))
            {
                return false;
            }
            Remind.Log_Debug("开始运行全部Runner", tag);
            foreach (AqiRunner runner in this.aqiRunner.Values)
            {
                runner.RunAll();
            }
            Remind.Log_Info(this.aqiRunner.Count + "个运行者，全部启用", tag);
            return true;
        }

        /// <summary>
        /// 结束所有
        /// </summary>
        /// <returns></returns>
        public bool EndAll()
        {
            if ((this.aqiRunner == null) || (this.aqiRunner.Count <= 0))
            {
                return false;
            }
            Remind.Log_Debug("结束运行全部Runner", tag);
            foreach (AqiRunner runner in this.aqiRunner.Values)
            {
                runner.EndAll();
            }
            Remind.Log_Info(this.aqiRunner.Count + "个运行者，全部结束", tag);
            return true;
        }

        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="name">运行者名称</param>
        /// <returns></returns>
        public bool Run(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "default";
            }
            if (this.aqiRunner.ContainsKey(name))
            {
                Remind.Log_Debug("开始运行Runner:" + name, tag);
                this.aqiRunner[name].RunAll();
                return true;
            }
            Remind.Log_Error("不存在Runner:" + name, tag);
            return false;
        }

        /// <summary>
        /// 结束
        /// </summary>
        /// <param name="name">运行者名称</param>
        /// <returns></returns>
        public bool End(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "default";
            }
            if (this.aqiRunner.ContainsKey(name))
            {
                Remind.Log_Debug("结束运行Runner:" + name, tag);
                this.aqiRunner[name].EndAll();
                return true;
            }
            Remind.Log_Error("不存在Runner:" + name, tag);
            return false;
        }

        #endregion

        #region 动态控制

        /// <summary>
        /// 加载插件
        /// </summary>
        /// <param name="dllPath"></param>
        /// <returns></returns>
        public bool Load(string dllPath)
        {
            try 
            {
                //加载到AqiPlugin
                IAqiWeb iaw = AqiManage.Plugin.Load(dllPath);
                if (iaw == null)
                {
                    Remind.Log_Info("未能从指定插件加载IAqiWeb接口", tag);
                    return false;
                }
                //加载到AqiRunner
                AqiRunner runner = null;
                switch (((AqiRunner.RunMode)Enum.Parse(typeof(AqiRunner.RunMode), Setting[AqiRunner.SET_RUNMODE])))
                {
                    case AqiRunner.RunMode.SELF:
                        runner = new AqiRunner(this, iaw.GetAllSrcUrl().Values.ToList(), iaw.Tag + "_Runner");
                        runner.RunEvent += new AqiRunner.RunEventHandler(this.aqiRunner_RunEvent);
                        if (!this.aqiRunner.ContainsKey(runner.Name))
                        {
                            this.aqiRunner.Add(runner.Name, runner);
                            Remind.Log_Info("初始化Runner:" + runner.Name, tag);
                        }
                        else
                        {
                            if(this.aqiRunner[runner.Name].Union(runner))
                            {
                                runner = this.aqiRunner[runner.Name];
                                Remind.Log_Info("合并存在Runner:" + runner.Name, tag);
                            }
                        }
                        break;
                    case AqiRunner.RunMode.JOINT:
                        runner = this.aqiRunner[AqiRunner.DEFAULT_NAME];
                        runner.AddSrcUrl(iaw.GetAllSrcUrl());
                        break;
                }
                //自动运行
                if (Setting.Get<bool>("LoadAutoRun"))
                {
                    runner.RunAll();
                    Remind.Log_Info("插件加载自动开启Runner:" + runner.Name, tag);
                }
            }
            catch(Exception ex)
            {
                Remind.Log_Error("加载指定插件错误", ex, tag);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 卸载插件
        /// </summary>
        /// <param name="iawTag"></param>
        /// <returns></returns>
        public bool UnLoad(string iawTag)
        {
            try
            {
                //卸载AqiRunner
                AqiRunner runner = null;
                switch (((AqiRunner.RunMode)Enum.Parse(typeof(AqiRunner.RunMode), Setting[AqiRunner.SET_RUNMODE])))
                {
                    case AqiRunner.RunMode.SELF:
                        runner = this.aqiRunner[iawTag + "_Runner"];
                        break;
                    case AqiRunner.RunMode.JOINT:
                        runner = this.aqiRunner[AqiRunner.DEFAULT_NAME];
                        break;
                }
                if (runner == null)
                {
                    Remind.Log_Error("卸载插件时没有找到同名Runner:" + iawTag, tag);
                    return false;
                }
                if(!runner.DeleSrcUrl(iawTag))
                {
                    Remind.Log_Error("未能卸载Runner中的ISrcUrl接口:" + iawTag, tag);
                    return false;
                }
                //卸载AqiPlugin
                if (!AqiManage.Plugin.UnLoad(iawTag))
                {
                    Remind.Log_Error("未能卸载指定插件:" + iawTag, tag);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Remind.Log_Error("卸载指定插件错误", ex, tag);
                return false;
            }
            return true;
        }

        #endregion

        #region 事件接收

        private void aqiRunner_RunEvent(RunMessage m)
        {
            this.TransferEvent(m);
            Remind.Log_RunMessage(m);
        }

        #endregion

        #region ISubObject接口

        public object GetSubObject(string name)
        {
            Dictionary<string, object> first = new Dictionary<string, object>();
            Dictionary<string, object> second = this.aqiRunner.ToDictionary<KeyValuePair<string, AqiRunner>, string, object>(old => old.Key, old => old.Value);
            first = first.Concat<KeyValuePair<string, object>>(second).ToDictionary<KeyValuePair<string, object>, string, object>(x => x.Key, x => x.Value);
            first.Add(this.aqiSaver.Name, this.aqiSaver);
            first.Add(this.aqiNoter.Name, this.aqiNoter);
            first.Add(this.aqiRetryer.Name, this.aqiRetryer);
            first.Add(AqiManage.Plugin.Name, AqiManage.Plugin);
            if (first.ContainsKey(name))
            {
                return first[name];
            }
            return null;
        }

        #endregion

        #region IStatus接口

        public string Name
        {
            get
            {
                return tag;
            }
        }

        public string GetInfo()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("AQI基本信息：");
            builder.Append("\n\t");
            builder.Append("运行者：" + this.aqiRunner.Count + "个");
            foreach (AqiRunner runner in this.aqiRunner.Values)
            {
                builder.Append("\n\t\t");
                builder.Append(runner.Name);
            }
            builder.Append("\n\t");
            builder.Append("保存者：" + this.aqiSaver.Name);
            builder.Append("\n\t");
            builder.Append("重试者：" + this.aqiRetryer.Name);
            builder.Append("\n\t");
            builder.Append("记录者：" + this.aqiNoter.Name);
            builder.Append("\n\t");
            builder.Append("插件器：" + Plugin.GetType().Name);
            builder.Append("\n\t");
            builder.Append("提醒器：" + Remind.GetType().Name);
            builder.Append("\n\t");
            builder.Append("设置器：" + Setting.GetType().Name);
            return builder.ToString();
        }

        #endregion

    }
}
