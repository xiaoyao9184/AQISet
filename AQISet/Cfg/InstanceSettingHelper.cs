using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Specialized;
using System.Threading;
using Helper.JSON;

namespace Helper.Setting
{
    /// <summary>
    /// 单例设置
    /// xiaoyao9184
    /// 1.0 2015-02-12
    /// 1.0beta 2015-02-11
    /// </summary>
    public sealed class InstanceSettingHelper
    {

        private const string tag = "InstanceSettingHelper";

        #region 字段

        private string settingtag;                   //json文件中的名称
        private JsonHelper jh;                       //json帮助对象
        private Dictionary<string, object> setting;  //缓存
        private ReaderWriterLockSlim thisLock;       //读写锁

        #endregion

        #region 属性

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string this[string name]
        {
            get
            {
                return Get<string>(name);
            }
            set
            {
                Set(name, value);
            }
        }

        #endregion

        #region 单例

        private static readonly InstanceSettingHelper _instance;

        /// <summary>
        /// 单例属性
        /// </summary>
        public static InstanceSettingHelper Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// 线程安全单例
        /// </summary>
        static InstanceSettingHelper()
        {
            _instance = new InstanceSettingHelper();
        }

        /// <summary>
        /// 单例
        /// </summary>
        private InstanceSettingHelper()
        {
            settingtag = "Setting";
            thisLock = new ReaderWriterLockSlim();
            Cache();
        }

        #endregion

        #region 方法

        #region 内部

        /// <summary>
        /// 配置文件路径
        /// </summary>
        /// <returns></returns>
        private string GetCfgJsonFile()
        {
            //JSON文件
            string exeFile = this.GetType().Assembly.Location;
            int p = exeFile.LastIndexOf('\\');
            string dllPath = exeFile.Substring(0, p);
            string jsonFile = dllPath + "\\JSON\\cfg.json";

            return jsonFile;
        }

        /// <summary>
        /// 精简map key名称
        /// </summary>
        /// <param name="map">键值对集合</param>
        /// <param name="name">去除的Key前缀</param>
        /// <returns></returns>
        private Dictionary<string, object> Simp(Dictionary<string, object> map, string prefixname)
        {
            Dictionary<string, object> value = new Dictionary<string, object>();

            foreach (KeyValuePair<string, object> kv in map)
            {
                value.Add(kv.Key.Replace(prefixname, ""), kv.Value);
            }

            return value;
        }

        /// <summary>
        /// 复杂map key名称
        /// </summary>
        /// <param name="map">键值对集合</param>
        /// <param name="name">添加到的Key前缀</param>
        /// <returns></returns>
        private Dictionary<string, object> Complex(Dictionary<string, object> map, string prefixname)
        {
            Dictionary<string, object> value = new Dictionary<string, object>();

            foreach (KeyValuePair<string, object> kv in map)
            {
                value.Add(prefixname + kv.Key, kv.Value);
            }

            return value;
        }

        /// <summary>
        /// 重置数据
        ///     将文本数据缓存到JSON对象中
        /// </summary>
        private void Reset()
        {
            //JSON路径
            string jsonPath = GetCfgJsonFile();

            //读取JSON
            StreamReader sr = new StreamReader(jsonPath);
            string jsonText = sr.ReadToEnd();

            thisLock.EnterWriteLock();

                jh = new JsonHelper(jsonText);

            thisLock.ExitWriteLock();
        }

        #endregion

        #region 通用方法
        
        /// <summary>
        /// 缓存数据
        ///     将文件数据缓存到Map对象中
        /// </summary>
        /// <returns></returns>
        public void Cache()
        {
            //JSON路径
            string jsonPath = GetCfgJsonFile();

            //读取JSON
            StreamReader sr = new StreamReader(jsonPath);
            string jsonText = sr.ReadToEnd();
            sr.Close();

            thisLock.EnterWriteLock();
            {
                jh = new JsonHelper(jsonText);
                setting = jh.CreateMap(settingtag);
                setting = Simp(setting, settingtag + ".");
            }
            thisLock.ExitWriteLock();
        }

        /// <summary>
        /// 更新组数据
        ///     将部分文本数据缓存到Map对象中
        /// </summary>
        /// <param name="groupname">需要更新的组名</param>
        /// <returns></returns>
        public bool UpdataGroup(string groupname)
        {
            Reset();

            thisLock.EnterWriteLock();
            {
                Dictionary<string, object> map = jh.CreateMap(groupname);
                map = Simp(map, settingtag + ".");

                foreach (KeyValuePair<string, object> kv in map)
                {

                    if (setting.ContainsKey(kv.Key))
                    {
                        setting[kv.Key] = kv.Value;
                    }
                    else
                    {
                        setting.Add(kv.Key, kv.Value);
                    }
                }
            }
            thisLock.ExitWriteLock();

            return true;
        }

        /// <summary>
        /// 保存数据
        ///     将Map对象数据保存到文件中
        /// </summary>
        public void Apply()
        {
            //JSON路径
            string jsonPath = GetCfgJsonFile();
            string jsonText = null;
            //保存JSON
            thisLock.EnterWriteLock();
            {
                jh.JoinMap(Complex(setting, settingtag + "."));
                jsonText = jh.CreateString();
                
            }
            thisLock.ExitWriteLock();
            
            StreamWriter sw = new StreamWriter(jsonPath);
            sw.Write(jsonText);
            sw.Close();
        }

        #endregion

        #region 缓存读取

        /// <summary>
        /// 读取配置
        ///     Map缓存
        /// </summary>
        /// <typeparam name="T">字符串、数字、布尔</typeparam>
        /// <param name="fullname"></param>
        /// <returns></returns>
        public T Get<T>(string fullname)
        {
            T ts = default(T);
            thisLock.EnterReadLock();
            {
                try
                {
                    ts = (T)Convert.ChangeType(setting[fullname], typeof(T));
                }
                catch
                {
                    Console.WriteLine(tag + ":cant change type,use type default value");
                }
            }
            thisLock.ExitReadLock();
            return ts;
        }
        
        /// <summary>
        /// 读取配置
        ///     Json缓存
        /// </summary>
        /// <typeparam name="T">字符串、数字、布尔</typeparam>
        /// <param name="tag"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public T GetFromJson<T>(string tag, string name)
        {
            T ts = default(T);
            thisLock.EnterReadLock();
            {
                try
                {
                    string str = jh.ReadProperty(settingtag + "." + tag + "." + name);
                    ts = (T)Convert.ChangeType(str, typeof(T));
                }
                catch
                {
                    Console.WriteLine(tag + ":cant change type,use type default value");
                }
            }
            thisLock.ExitReadLock();
            return ts;
        }

        /// <summary>
        /// 读取配置组
        ///     Json缓存
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public Dictionary<string, object> GetGroupFromJson(string tag)
        {
            Dictionary<string, object> map = null;
            thisLock.EnterReadLock();
            {
                map = jh.CreateMap(settingtag + "." + tag);
            }
            thisLock.ExitReadLock();
            return map;
        }

        #endregion

        #region 缓存修改

        /// <summary>
        /// 修改配置
        ///     Map缓存
        /// </summary>
        /// <param name="fullname"></param>
        /// <param name="value"></param>
        public void Set(string fullname, object value)
        {
            thisLock.EnterWriteLock();
            {
                if (setting.ContainsKey(fullname))
                {
                    setting[fullname] = value;
                }
                else
                {
                    Console.WriteLine(tag + ":cant save setting,setting not exist,auto add setting");
                    setting.Add(fullname,value);
                }
            }
            thisLock.ExitWriteLock();
        }

        /// <summary>
        /// 修改配置
        ///     Json缓存
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetToJson(string tag, string name, object value)
        {
            thisLock.EnterWriteLock();
            {
                bool bResult = jh.SaveProperty(settingtag + "." + tag + "." + name, value);
                if(!bResult)
                {
                    Console.WriteLine(tag + ":cant save property,property not exist,auto add property");
                    jh.AddProperty(settingtag + "." + tag + "." + name, value);
                }
            }
            thisLock.ExitWriteLock();
        }

        /// <summary>
        /// 删除配置
        ///     Json缓存
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="name"></param>
        public void RemoveToJson(string tag, string name)
        {
            thisLock.EnterWriteLock();
            {
                bool bResult = jh.DeleProperty(settingtag + "." + tag + "." + name);
                if (!bResult)
                {
                    Console.WriteLine(tag + ":cant dele property,property not exist");
                }
            }
            thisLock.ExitWriteLock();
        }

        #endregion

        #region 动态读取

        /// <summary>
        /// 读取配置
        ///     Map缓存
        /// </summary>
        /// <typeparam name="T">字符串、数字、布尔</typeparam>
        /// <param name="fullname"></param>
        /// <returns></returns>
        public T DynamicGet<T>(string fullname)
        {
            Cache();
            return Get<T>(fullname);
        }

        /// <summary>
        /// 读取配置
        ///     Json缓存
        /// </summary>
        /// <typeparam name="T">字符串、数字、布尔</typeparam>
        /// <param name="tag"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public T DynamicGet<T>(string tag, string name)
        {
            Reset();
            return GetFromJson<T>(tag,name);
        }

        /// <summary>
        /// 读取配置组
        ///     Json缓存
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public Dictionary<string, object> DynamicGetGroup(string tag)
        {
            Reset();
            return GetGroupFromJson(tag);
        }

        #endregion

        #endregion

    }
}
