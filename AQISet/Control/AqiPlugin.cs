using AQI.Interface;
using AQISet.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AQISet.Control
{

    /// <summary>
    /// 插件者
    /// </summary>
    public class AqiPlugin : IStatus
    {

        #region 字段

        private static string Tag = "AQIPluin";
        private List<Assembly> allDLLs;
        private Dictionary<string, IAqiWeb> allAqiWebs;
        private Dictionary<string, ISrcUrl> allSrcUrls;
        
        #endregion

        #region 单例

        private static readonly AqiPlugin _instance;

        /// <summary>
        /// 单例属性
        /// </summary>
        public static AqiPlugin Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// 线程安全单例
        /// </summary>
        static AqiPlugin()
        {
            _instance = new AqiPlugin();
        }

        private AqiPlugin()
        {
            this.InitDll();
            this.InitAqiWeb();
            this.InitSrcUrl();
        }

        #endregion

        #region 初始化

        private void InitDll()
        {
            this.allDLLs = new List<Assembly>();
            string location = Assembly.GetExecutingAssembly().Location;
            int length = location.LastIndexOf('\\');
            DirectoryInfo info = new DirectoryInfo(location.Substring(0, length));
            foreach (FileInfo info2 in info.GetFiles())
            {
                if (info2.Name.IndexOf("AQI") > 1 && info2.Name.IndexOf(".dll") > 1)
                {
                    try
                    {
                        Assembly item = Assembly.LoadFrom(info2.FullName);
                        this.allDLLs.Add(item);
                        AqiManage.Remind.Log_Debug("加载程序集:" + item.FullName, new string[] { Tag });
                    }
                    catch (Exception exception)
                    {
                        AqiManage.Remind.Log_Error("初始化DLL错误", exception, new string[] { Tag });
                    }
                }
            }
        }

        private void InitAqiWeb()
        {
            this.allAqiWebs = new Dictionary<string, IAqiWeb>();
            foreach (Assembly assembly in this.allDLLs)
            {
                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    if (type.GetInterface("IAqiWeb") != null)
                    {
                        IAqiWeb web = Activator.CreateInstance(type) as IAqiWeb;
                        this.allAqiWebs.Add(web.TAG, web);
                        AqiManage.Remind.Log_Debug("加载数据源:" + web.NAME, new string[] { Tag });
                    }
                }
            }
        }

        private void InitSrcUrl()
        {
            this.allSrcUrls = new Dictionary<string, ISrcUrl>();
            foreach (IAqiWeb web in this.allAqiWebs.Values)
            {
                Dictionary<string, ISrcUrl> second = web.getAllSrcUrl();
                this.allSrcUrls = this.allSrcUrls.Concat<KeyValuePair<string, ISrcUrl>>(second).ToDictionary<KeyValuePair<string, ISrcUrl>, string, ISrcUrl>(x => x.Key, x => x.Value);
                AqiManage.Remind.Log_Debug("整合数据源接口:" + web.NAME, new string[] { Tag });
            }
        }

        #endregion

        #region 基本控制

        public IAqiWeb GetAqiWeb(string name)
        {
            if (this.allAqiWebs.ContainsKey(name))
            {
                return this.allAqiWebs[name];
            }
            return null;
        }

        public List<IAqiWeb> GetAqiWebList(params string[] name)
        {
            if (name.Length > 0)
            {
                List<IAqiWeb> list = new List<IAqiWeb>();
                foreach (string str in name)
                {
                    if (this.allAqiWebs.ContainsKey(str))
                    {
                        list.Add(this.allAqiWebs[str]);
                    }
                }
                return list;
            }
            return this.allAqiWebs.Values.ToList<IAqiWeb>();
        }

        public Dictionary<string, ISrcUrl> GetAqiWebSrcUrlList(string awName, params string[] suName)
        {
            if (this.allAqiWebs.ContainsKey(awName))
            {
                Dictionary<string, ISrcUrl> dictionary = this.allAqiWebs[awName].getAllSrcUrl();
                if (suName.Length <= 0)
                {
                    return dictionary;
                }
                Dictionary<string, ISrcUrl> dictionary2 = new Dictionary<string, ISrcUrl>();
                foreach (string str in suName)
                {
                    if (dictionary.ContainsKey(str))
                    {
                        dictionary2.Add(dictionary[str].TAG, dictionary[str]);
                    }
                }
                return dictionary2;
            }
            return null;
        }

        public ISrcUrl GetSrcUrl(string name)
        {
            if (this.allSrcUrls.ContainsKey(name))
            {
                return this.allSrcUrls[name];
            }
            return null;
        }

        public List<ISrcUrl> GetSrcUrlList(params string[] name)
        {
            if (name.Length > 0)
            {
                List<ISrcUrl> list = new List<ISrcUrl>();
                foreach (string str in name)
                {
                    if (this.allSrcUrls.ContainsKey(str))
                    {
                        list.Add(this.allSrcUrls[str]);
                    }
                }
                return list;
            }
            return this.allSrcUrls.Values.ToList<ISrcUrl>();
        }

        #endregion

        #region 动态控制

        public IAqiWeb LoadDll(string dllpath)
        {
            try
            {
                IAqiWeb web = null;
                Assembly ass = Assembly.LoadFrom(dllpath);
                Type[] types = ass.GetTypes();
                foreach (Type type in types)
                {
                    if (type.GetInterface("IAqiWeb") != null)
                    {
                        web = Activator.CreateInstance(type) as IAqiWeb;
                    }
                }
                if (web == null)
                {
                    AqiManage.Remind.Log_Error("程序集未实现IAqiWeb接口:" + ass.FullName, new string[] { Tag });
                    return null;
                }
                if (this.allDLLs.Exists(dll => dll.FullName == ass.FullName))
                {
                    AqiManage.Remind.Log_Debug("程序集已经存在:" + ass.FullName, new string[] { Tag });
                    this.allDLLs.Remove(ass);
                }
                this.allDLLs.Add(ass);
                return web;
            }
            catch (Exception exception)
            {
                AqiManage.Remind.Log_Error("加载DLL错误", exception, new string[] { Tag });
                return null;
            }
        }

        public bool UnLoadDll(string name)
        {
            if (this.allAqiWebs.ContainsKey(name))
            {
                this.allDLLs.Remove(this.allAqiWebs[name].GetType().Assembly);
                this.allAqiWebs.Remove(name);
                AqiManage.Remind.Log_Debug("移除数据源插件成功:" + name, new string[] { Tag });
                return true;
            }
            AqiManage.Remind.Log_Error("移除数据源插件失败:" + name, new string[] { Tag });
            return false;
        }

        #endregion

        #region IStatus接口

        public string Name
        {
            get
            {
                return Tag;
            }
        }

        public string GetInfo()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("插件信息：");
            builder.Append("\n\t");
            builder.Append(this.allDLLs.Count + "个程序集；");
            builder.Append(this.allAqiWebs.Count + "个数据源；");
            builder.Append(this.allSrcUrls.Count + "个数据接口；");

            return builder.ToString();
        }

        #endregion

    }
}

