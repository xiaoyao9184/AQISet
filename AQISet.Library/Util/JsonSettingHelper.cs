using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Helper.IO.Format.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Helper.Setting
{
    /// <summary>
    /// Json文件设置
    /// xiaoyao9184
    /// 1.0 2016-03-13
    /// </summary>
    public class JsonSettingHelper
    {

        #region 字段

        private const string TAG = "JsonSettingHelper";

        private ReaderWriterLockSlim thisLock;               //读写锁

        private string jsonFile;                             //Json文件
        private string jsonPropertyName;                     //Json属性，分组

        private DateTime cacheJsonTime;                                 //缓存时间戳
        private JsonHelper cacheJsonHelper;                             //缓存JObject
        private IDictionary<string, object> cacheSettingDictionary;     //缓存Map

        #endregion

        public JsonSettingHelper() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonFile">JSON 文件</param>
        /// <param name="propertyGroup">属性分组</param>
        public JsonSettingHelper(string jsonFile, string propertyGroup = null)
        {
            this.thisLock = new ReaderWriterLockSlim();
            this.jsonFile = jsonFile;
            this.jsonPropertyName = propertyGroup;
            Cache();
        }

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

        public JsonHelper JsonHelper
        {
            get { return cacheJsonHelper; }
        }

        public string JsonPropertyName
        {
            get { return jsonPropertyName; }
        }

        public string JsonFile
        {
            get { return jsonFile; }
        }

        #endregion

        #region 方法

        #region 内部

        /// <summary>
        /// 获取Json绝对路径
        /// (不会超出此实例的分组等级，只能是下级属性)
        /// </summary>
        /// <param name="groupJsonPropertyName">缓存名称(Json相对属性)/绝对名称(Json绝对属性)</param>
        /// <returns></returns>
        private string GetJsonPropertyName(string groupJsonPropertyName)
        {
            if (!String.IsNullOrEmpty(jsonPropertyName) &&
                !groupJsonPropertyName.StartsWith(jsonPropertyName))
            {
                if (groupJsonPropertyName.StartsWith("["))
                {
                    // now is JArray
                    return jsonPropertyName + groupJsonPropertyName;
                }
                // now is JObject
                return jsonPropertyName + "." + groupJsonPropertyName;
            }
            // already good
            return groupJsonPropertyName;
        }

        #endregion
        
        #region 同步

        /// <summary>
        /// 缓存到内存
        /// File -> JObject -> Dictionary
        /// </summary>
        public void Cache()
        {
            if (File.Exists(jsonFile))
            {
                thisLock.EnterWriteLock();
                {
                    cacheJsonTime = File.GetLastWriteTime(jsonFile);
                    cacheJsonHelper = new JsonHelper(File.ReadAllText(jsonFile));
                    cacheSettingDictionary = cacheJsonHelper.ConvertNotNestedMap(jsonPropertyName);
                }
                thisLock.ExitWriteLock();
            }
            else
            {
                throw new FileNotFoundException(jsonFile);
            }
        }

        /// <summary>
        /// 同步缓存与文件
        /// File -> JObject -> Dictionary
        /// Dictionary -> JObject -> File
        /// </summary>
        public void Sync()
        {
            if (!File.Exists(jsonFile)){
                throw new FileNotFoundException(jsonFile);
            }

            JsonHelper newJsonHelper = new JsonHelper(File.ReadAllText(jsonFile));
            IDictionary<string, object> newSettingMap = newJsonHelper.ConvertNotNestedMap(jsonPropertyName);

            thisLock.EnterWriteLock();
            {
                // http://stackoverflow.com/questions/294138/merging-dictionaries-in-c-sharp
                // http://stackoverflow.com/questions/10559367/combine-multiple-dictionaries-into-a-single-dictionary
                cacheSettingDictionary = cacheSettingDictionary.Concat(newSettingMap)
                    .GroupBy(d => d.Key)
                    .ToDictionary(kv => kv.Key, kv => kv.First().Value);
                cacheJsonHelper.Concat(newJsonHelper);
            }
            thisLock.ExitWriteLock();

            Apply();
        }

        /// <summary>
        /// 保存到文件
        /// Dictionary -> JObject -> File
        /// </summary>
        public void Apply()
        {
            string jsonText;
            //保存JSON
            thisLock.EnterReadLock();
            {
                cacheJsonHelper.ConcatNotNestedMap(cacheSettingDictionary, jsonPropertyName);
                jsonText = cacheJsonHelper.Convert<string>();
            }
            thisLock.ExitReadLock();

            StreamWriter sw = new StreamWriter(jsonFile);
            sw.Write(jsonText);
            sw.Close();
        }

        #endregion

        #region 单个设置

        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">缓存名称(Json相对属性)</param>
        /// <returns></returns>
        public T Get<T>(string name)
        {
            T ts = default(T);
            thisLock.EnterReadLock();
            {
                try
                {
                    ts = (T)Convert.ChangeType(cacheSettingDictionary[name], typeof(T));
                }
                catch
                {
                    Console.WriteLine(TAG + ":cant change type,use type default value");
                }
            }
            thisLock.ExitReadLock();
            return ts;
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">缓存名称(Json相对属性)</param>
        /// <param name="value">值</param>
        public void Set<T>(string name, T value)
        {
            thisLock.EnterWriteLock();
            {
                if (cacheSettingDictionary.ContainsKey(name))
                {
                    cacheSettingDictionary[name] = value;
                }
                else
                {
                    Console.WriteLine(TAG + ":cant save setting,setting not exist,auto add setting");
                    cacheSettingDictionary.Add(name, value);
                }
            }
            thisLock.ExitWriteLock();
        }

        #endregion
        
        #region 组合设置

        /// <summary>
        /// 获取分组Helper
        /// </summary>
        /// <param name="groupJsonPropertyName">缓存名称(Json相对属性)/绝对名称(Json绝对属性)</param>
        /// <returns></returns>
        public JsonSettingHelper GetGroupHelper(string groupJsonPropertyName)
        {
            groupJsonPropertyName = GetJsonPropertyName(groupJsonPropertyName);
            // 分组 JsonSettingHelper 共享一个 JsonFile、JsonTime、JsonHelper
            var helper = new JsonSettingHelper
            {
                thisLock = new ReaderWriterLockSlim(),
                jsonFile = jsonFile,
                cacheJsonTime = cacheJsonTime,
                cacheJsonHelper = cacheJsonHelper,

                jsonPropertyName = groupJsonPropertyName,
                cacheSettingDictionary = cacheJsonHelper.ConvertNotNestedMap(groupJsonPropertyName)
            };
            return helper;
        }

        /// <summary>
        /// 获取分组(嵌套)对象
        /// </summary>
        /// <param name="groupJsonPropertyName">缓存名称(Json相对属性)/绝对名称(Json绝对属性)</param>
        /// <returns></returns>
        public object GetGroupObject(string groupJsonPropertyName)
        {
            object obj;
            thisLock.EnterReadLock();
            {
                obj = cacheJsonHelper.Convert<object>(GetJsonPropertyName(groupJsonPropertyName), true);
            }
            thisLock.ExitReadLock();
            return obj;
        }

        /// <summary>
        /// 获取分组(非嵌套)Dictionary
        /// </summary>
        /// <param name="groupJsonPropertyName">缓存名称(Json相对属性)/绝对名称(Json绝对属性)</param>
        /// <returns></returns>
        public IDictionary<string, object> GetGroupNotNestedDictionary(string groupJsonPropertyName)
        {
            IDictionary<string, object> map;
            thisLock.EnterReadLock();
            {
                map = cacheJsonHelper.ConvertNotNestedMap(GetJsonPropertyName(groupJsonPropertyName));
            }
            thisLock.ExitReadLock();
            return map;
        }

        /// <summary>
        /// 设置分组Helper
        /// </summary>
        /// <param name="jsonSettingHelper"></param>
        public void SetGroupHelper(JsonSettingHelper jsonSettingHelper)
        {
            if (!jsonFile.Equals(jsonSettingHelper.jsonFile))
            {
                throw new NotSupportedException("cant set group with different json file");
            }
            cacheJsonTime = (cacheJsonTime > jsonSettingHelper.cacheJsonTime)
                ? cacheJsonTime
                : jsonSettingHelper.cacheJsonTime;
            cacheJsonHelper = (cacheJsonTime > jsonSettingHelper.cacheJsonTime)
                ? cacheJsonHelper
                : jsonSettingHelper.cacheJsonHelper;

            if (jsonPropertyName.Equals(jsonSettingHelper.jsonPropertyName))
            {
                //分组路径相同，直接合并
                cacheSettingDictionary = cacheSettingDictionary.Concat(jsonSettingHelper.cacheSettingDictionary)
                        .GroupBy(d => d.Key)
                        .ToDictionary(kv => kv.Key, kv => kv.First().Value);
            }
            else
            {
                //直接将Map设置到公用的JsonHelper里
                cacheJsonHelper.ConcatNotNestedMap(jsonSettingHelper.cacheSettingDictionary, jsonSettingHelper.jsonPropertyName);
                cacheSettingDictionary = cacheJsonHelper.ConvertNotNestedMap(jsonPropertyName);
            }
        }

        /// <summary>
        /// 设置分组(嵌套)对象
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="groupJsonPropertyName"></param>
        public void SetGroupObject(object obj, string groupJsonPropertyName)
        {
            if (jsonPropertyName.Equals(groupJsonPropertyName))
            {
                //分组路径相同，直接合并
                JToken jToken = JToken.FromObject(obj);
                IDictionary<string, object> map = new Dictionary<string, object>();
                cacheJsonHelper.ConvertNotNestedMapByJToken(jToken, ref map);

                cacheSettingDictionary = cacheSettingDictionary.Concat(map)
                        .GroupBy(d => d.Key)
                        .ToDictionary(kv => kv.Key, kv => kv.First().Value);
            }
            else
            {
                //直接将Object设置到公用的JsonHelper里
                cacheJsonHelper.ConcatObject(obj, groupJsonPropertyName);
                cacheSettingDictionary = cacheJsonHelper.ConvertNotNestedMap(jsonPropertyName);
            }
        }

        /// <summary>
        /// 设置分组(非嵌套)Dictionary
        /// </summary>
        /// <param name="map">(非嵌套)Dictionary</param>
        /// <param name="groupJsonPropertyName">分组路径</param>
        public void SetGroupNotNestedDictionary(IDictionary<string, object> map, string groupJsonPropertyName)
        {

            map = map.ToDictionary(
                kv =>
                {
                    if (kv.Key.StartsWith(groupJsonPropertyName))
                    {
                        // remove property name prefix
                        string str = kv.Key.Replace(groupJsonPropertyName, "");
                        if (str.StartsWith("."))
                        {
                            // is JObject
                            return str.Substring(1);
                        }
                        return str;
                    }
                    else
                    {
                        return kv.Key;
                    }
                }, kv => kv.Value);

            //TODO 应该是替换不是合并
            if (jsonPropertyName.Equals(groupJsonPropertyName))
            {
                //分组路径相同，直接合并
//                cacheSettingDictionary = cacheSettingDictionary.Concat(map)
//                        .GroupBy(d => d.Key)
//                        .ToDictionary(kv => kv.Key, kv => kv.First().Value);
                cacheSettingDictionary = map;
            }
            else
            {
                //直接将Map设置到公用的JsonHelper里
                cacheJsonHelper.ConcatNotNestedMap(map, GetJsonPropertyName(groupJsonPropertyName));
                cacheSettingDictionary = cacheJsonHelper.ConvertNotNestedMap(jsonPropertyName);
            }
        }

        #endregion

        #endregion

    }
}
