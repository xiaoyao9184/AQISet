using AQI.Interface;
using AQISet.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using AQISet.Control.Saver;

namespace AQISet.Control
{

    /// <summary>
    /// 插件者
    /// </summary>
    public class AqiPlugin : IStatus
    {

        #region 常量

        public const string PLUGIN_DLL = ".dll";
        public const string PLUGIN_NAME = "AQIPlugin";

        #endregion

        #region 字段

        private static string tag = "AqiPlugin";
        private List<Assembly> allDLLs;
        private Dictionary<string, IAqiWeb> allAqiWebs;
        private Dictionary<string, ISrcUrl> allSrcUrls;
        private Dictionary<string, IAqiSave> allAqiSaves;
// 
//         private Dictionary<string, List<Type>> allPluginInterface;
// 
//         private Dictionary<Type, Dictionary<string, Type>> allPluginType;

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
//             allPluginType = new Dictionary<Type, Dictionary<string, Type>>();
//             allPluginType.Add(typeof(IAqiWeb), new Dictionary<string,Type>());
//             allPluginType.Add(typeof(IAqiSave), new Dictionary<string,Type>());
            allAqiSaves = new Dictionary<string, IAqiSave>();
            allAqiSaves.Add(AqiFileSaver.NAME, new AqiFileSaver());
            
            this.initDll();
            this.initAqiWeb();
            this.initSrcUrl();
        }

        #endregion

        #region 初始化

        private void initDll()
        {
            this.allDLLs = new List<Assembly>();
            string location = Assembly.GetExecutingAssembly().Location;
            int length = location.LastIndexOf('\\');
            DirectoryInfo info = new DirectoryInfo(location.Substring(0, length));
            foreach (FileInfo info2 in info.GetFiles())
            {
                if (info2.Name.IndexOf(PLUGIN_NAME) != -1 && info2.Name.IndexOf(PLUGIN_DLL) > 1)
                {
                    try
                    {
                        Assembly item = Assembly.LoadFrom(info2.FullName);
                        this.allDLLs.Add(item);
                        AqiManage.Remind.Log_Debug("加载程序集:" + info2.FullName, AqiPlugin.tag);
                    }
                    catch (Exception exception)
                    {
                        AqiManage.Remind.Log_Error("初始化DLL错误", exception, AqiPlugin.tag);
                    }
                }
            }
        }

        private void initAqiWeb()
        {
            this.allAqiWebs = new Dictionary<string, IAqiWeb>();
            foreach (Assembly assembly in this.allDLLs)
            {
                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    if (type.GetInterface(typeof(IAqiWeb).Name) != null)
                    {
                        try
                        {
                            IAqiWeb iaw = Activator.CreateInstance(type) as IAqiWeb;
                            this.allAqiWebs.Add(iaw.Tag, iaw);
                            AqiManage.Remind.Log_Debug("加载数据源:" + iaw.Name, AqiPlugin.tag);
                        }
                        catch (Exception ex)
                        {
                            AqiManage.Remind.Log_Error("加载数据源错误", ex, AqiPlugin.tag);
                        }
                    }
                    else if (type.GetInterface(typeof(IAqiSave).Name) != null)
                    {
/*                        AddTypeToMapping(typeof (IAqiSave), type);*/
//                         string name = typeof(IAqiSave).Name;
//                         this.allPluginInterface[name].Add(type);
//                         AqiManage.Remind.Log_Debug("加载持久插件:" + type.Name, AqiPlugin.tag);
                        try
                        {
                            IAqiSave ias = Activator.CreateInstance(type) as IAqiSave;
                            this.allAqiSaves.Add(ias.Name, ias);
                            AqiManage.Remind.Log_Debug("加载持久插件:" + ias.Name, AqiPlugin.tag);
                        }
                        catch (Exception ex)
                        {
                            AqiManage.Remind.Log_Error("加载持久插件错误", ex, AqiPlugin.tag);
                        }
                    }
                }
            }
        }

        private void initSrcUrl()
        {
            this.allSrcUrls = new Dictionary<string, ISrcUrl>();
            foreach (IAqiWeb iaw in this.allAqiWebs.Values)
            {
                Dictionary<string, ISrcUrl> second = iaw.GetAllSrcUrl();
                this.allSrcUrls = this.allSrcUrls.Concat<KeyValuePair<string, ISrcUrl>>(second).ToDictionary<KeyValuePair<string, ISrcUrl>, string, ISrcUrl>(x => x.Key, x => x.Value);
                AqiManage.Remind.Log_Debug("整合数据源接口:" + iaw.Name, AqiPlugin.tag);
            }
        }


//         private void AddTypeToMapping(Type baseType, Type type)
//         {
//             allPluginType[baseType].Add(type.Name, type);
//         }
// 
//         private void GetTypeFormMapping()
//         {
//             
//         }
// 
//         private List<Type> GetSupportType()
//         {
//             return allPluginType.Keys.ToList();
//         }


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

        public Dictionary<string, ISrcUrl> GetAqiWebSrcUrlList(string iawName, params string[] suName)
        {
            if (this.allAqiWebs.ContainsKey(iawName))
            {
                Dictionary<string, ISrcUrl> dictionary = this.allAqiWebs[iawName].GetAllSrcUrl();
                if (suName.Length <= 0)
                {
                    return dictionary;
                }
                Dictionary<string, ISrcUrl> dictionary2 = new Dictionary<string, ISrcUrl>();
                foreach (string str in suName)
                {
                    if (dictionary.ContainsKey(str))
                    {
                        dictionary2.Add(dictionary[str].Tag, dictionary[str]);
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

        /// <summary>
        /// 加载插件
        /// </summary>
        /// <param name="dllpath"></param>
        /// <returns></returns>
        public IAqiWeb Load(string dllpath)
        {
            Assembly ass = null;
            IAqiWeb iaw = null;
            try
            {
                //DLL
                ass = Assembly.LoadFrom(dllpath);
                if (this.allDLLs.Exists(dll => dll.FullName == ass.FullName))
                {
                    AqiManage.Remind.Log_Error("程序集已经存在:" + ass.FullName, tag);
                    return null;
                }
                //IAW
                Type[] types = ass.GetTypes();
                foreach (Type type in types)
                {
                    if (type.GetInterface(typeof(IAqiWeb).Name) != null)
                    {
                        this.allDLLs.Add(ass);
                        iaw = Activator.CreateInstance(type) as IAqiWeb;
                        break;
                    }
                }
                if (iaw == null)
                {
                    AqiManage.Remind.Log_Error("程序集未实现IAqiWeb接口:" + ass.FullName, tag);
                    return null;
                }
                if (this.allAqiWebs.ContainsKey(iaw.Tag))
                {
                    AqiManage.Remind.Log_Error("IAqiWeb接口已经存在:" + iaw.Tag, tag);
                    this.allDLLs.Remove(ass);
                    return null;
                }
                this.allAqiWebs.Add(iaw.Tag, iaw);
                
                //ISU
                Dictionary<string, ISrcUrl> dictISU = iaw.GetAllSrcUrl();
                this.allSrcUrls = this.allSrcUrls.Concat<KeyValuePair<string, ISrcUrl>>(dictISU).ToDictionary<KeyValuePair<string, ISrcUrl>, string, ISrcUrl>(x => x.Key, x => x.Value);
                AqiManage.Remind.Log_Info("加载数据源插件成功:" + iaw.Name, AqiPlugin.tag);
            }
            catch (Exception ex)
            {
                this.allDLLs.Remove(ass);
                this.allAqiWebs.Remove(iaw.Tag);
                AqiManage.Remind.Log_Error("加载数据源插件错误", ex, tag);
            }
            return iaw;
        }

        /// <summary>
        /// 卸载插件
        /// </summary>
        /// <param name="iawName"></param>
        /// <returns></returns>
        public bool UnLoad(string iawName)
        {
            try
            {
                if (this.allAqiWebs.ContainsKey(iawName))
                {
                    //ISU
                    Dictionary<string, ISrcUrl> listISU = this.allAqiWebs[iawName].GetAllSrcUrl();
                    foreach (string isuName in listISU.Keys)
                    {
                        this.allSrcUrls.Remove(isuName);
                    }
                    //DLL
                    Assembly ass = this.allAqiWebs[iawName].GetType().Assembly;
                    this.allDLLs.Remove(ass);
                    //IAW
                    this.allAqiWebs.Remove(iawName);

                    AqiManage.Remind.Log_Info("移除数据源插件成功:" + iawName, tag);
                    return true;
                }
            }
            catch(Exception ex)
            {
                AqiManage.Remind.Log_Error("移除数据源插件失败:" + iawName, ex, tag);
            }
            return false;
        }

        #endregion

        #region 工厂方法


//         public T CreateInterface<T>(T t, string name)
//         {
//             Dictionary<string, Type> mapType = allPluginType[typeof(T)];
//             if (mapType.Count < 1)
//             {
//                 throw Exception("空集合，无法创建");
//             }
// 
//             Type type = null;
// 
//             if (mapType.ContainsKey(name))
//             {
//                 type = mapType[name];
//             }
//             else
//             {
//                 AqiManage.Remind.Log_Error("没有找到相关类型", AqiPlugin.tag);
//                 type = mapType.ElementAt(0).Value;
//             }
// 
//             T obj = (T)Activator.CreateInstance(type);
// 
//             return obj;
//         }

        public IAqiSave CreateSave(string saverName)
        {
            if (String.IsNullOrEmpty(saverName) || !allAqiSaves.ContainsKey(saverName))
            {
                return allAqiSaves.ElementAt(0).Value;
            }
            else
            {
                return allAqiSaves[saverName];
            }
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

