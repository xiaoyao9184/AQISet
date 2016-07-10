using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Helper.IO.Format.Json
{
    /// <summary>
    /// Json 帮助对象
    /// xiaoyao9184
    /// 1.3 2016-03-13
    /// 1.2 2015-02-12 + dele
    /// 1.1 2015-02-11 + add
    /// 1.0 2015-02-06
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    public class JsonHelper
    {

        #region 字段

        /// <summary>
        /// 缓存
        /// </summary>
        private readonly JObject _jObject;

        #endregion

        public JsonHelper(string jsonText)
        {
            _jObject = JObject.Parse(jsonText);
        }

        public JsonHelper(TextReader reader)
        {
            JsonTextReader jsonTextReader = new JsonTextReader(reader);
            _jObject = JObject.Load(jsonTextReader);
        }

        #region 属性

        public JObject JsonObject
        {
            get { return _jObject; }
        }

        #endregion

        #region 方法

        #region 内部方法

        /// <summary>
        /// 递归添加属性
        /// </summary>
        /// <param name="jToken"></param>
        /// <param name="path"></param>
        /// <param name="value"></param>
        private void AddPropertyByJToken(JToken jToken, string path, object value)
        {
            //TODO 添加其他支持
            JObject jObj = jToken as JObject;
            if (jObj == null)
                throw new NotSupportedException("only support add property to JObject, not this :" + jToken.Type);

            int p = path.IndexOf('.');
            if (p != -1)
            {
                bool isArray = false;   //标识为数组
                string name = path.Substring(0, p);
                if (name.EndsWith("]"))
                {
                    isArray = true;
                }

                JToken jt = jObj.SelectToken(name);

                if (jt == null)
                {
                    JObject jot = new JObject();
                    if (isArray)
                    {
                        string arrname = name.Substring(0, name.IndexOf('['));
                        JArray ja = jObj.SelectToken(arrname) as JArray;
                        if (ja == null)
                        {
                            //数组不存在
                            ja = new JArray();
                            jObj.Add(arrname, ja);
                        }
                        //添加到数组
                        ja.Add(jot);
                    }
                    else
                    {
                        jObj.Add(name, jot);
                    }
                    jt = jot;
                }

                AddPropertyByJToken(jt, path.Substring(p + 1), value);
            }
            else
            {
                Type t = value.GetType();
                if (t == typeof(string))
                {
                    //String类型可能还会是JSON文本
                    JToken jtt;
                    try
                    {
                        //JSON解析
                        jtt = JToken.Parse(value as string);
                    }
                    catch
                    {
                        //非JSON
                        jtt = JToken.FromObject(value);
                    }
                    jObj.Add(path, jtt);
                }
                else
                {
                    //基本类型
                    jObj.Add(path, JToken.FromObject(value));
                }
            }
        }

        /// <summary>
        /// 递归转换
        /// </summary>
        /// <param name="jToken"></param>
        /// <param name="map"></param>
        public void ConvertNotNestedMapByJToken(JToken jToken, ref IDictionary<string, object> map)
        {
            if (jToken == null)
                return;

            if (jToken is JObject)
            {
                JEnumerable<JToken> je = jToken.Children();
                foreach (JToken jt in je)
                {
                    //属性
                    JProperty jp = jt as JProperty;
                    if (jp == null)
                        throw new NullReferenceException(jt.Path);
                    if (!jp.HasValues)
                    {
                        map.Add(jp.Path, jp.Value);
                    }
                    ConvertNotNestedMapByJToken(jp.Value, ref map);
                }
            }
            else if (jToken is JArray)
            {
                JEnumerable<JToken> je = jToken.Children();
                foreach (JToken jt in je)
                {
                    ConvertNotNestedMapByJToken(jt, ref map);
                }
            }
            else if (jToken is JValue)
            {
                JValue jv = jToken as JValue;
                map.Add(jv.Path, jv.Value);
            }
            else
            {
                throw new NotSupportedException("not support convert: " + jToken.Type);
            }
        }

        #endregion

        #region 属性操作

        /// <summary>
        /// 读取属性
        /// </summary>
        /// <param name="propertyname"></param>
        /// <returns></returns>
        public string ReadProperty(string propertyname)
        {
            JToken jt = _jObject.SelectToken(propertyname);
            if (jt == null)
                return null;

            if (jt is JValue)
            {
                JValue jv = jt as JValue;
                return jv.Value<string>();
            }
            return jt.ToString();
        }

        /// <summary>
        /// 保存属性
        /// </summary>
        /// <param name="propertyname"></param>
        /// <param name="value">任意类型</param>
        /// <returns></returns>
        public bool SaveProperty(string propertyname, object value)
        {
            JToken jt = _jObject.SelectToken(propertyname);
            if (jt == null)
                return false;

            Type t = value.GetType();
            if (t == typeof(string))
            {
                //String类型可能还会是JSON文本
                JToken jtt;
                try
                {
                    //JSON解析
                    jtt = JToken.Parse(value as string);
                }
                catch
                {
                    //非JSON
                    jtt = JToken.FromObject(value);
                }

                jt.Replace(jtt);
            }
            else
            {
                //基本类型
                JToken jtt = JToken.FromObject(value);
                jt.Replace(jtt);
            }

            return true;
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="propertyname"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool AddProperty(string propertyname, object value)
        {
            //递归添加
            AddPropertyByJToken(_jObject, propertyname, value);

            return true;
        }

        /// <summary>
        /// 删除属性
        /// </summary>
        /// <param name="propertyname"></param>
        /// <returns></returns>
        public bool DeleProperty(string propertyname)
        {
            JToken jt = _jObject.SelectToken(propertyname);
            if (jt == null)
                return false;

            jt.Parent.Remove();
            return true;
        }

        #endregion

        #region 转换操作

        /// <summary>
        /// 通用泛型转换
        /// (JObject -> T)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyname"></param>
        /// <param name="nestedDictionary"></param>
        /// <returns></returns>
        public T Convert<T>(string propertyname = null, bool nestedDictionary = false)
        {
            JToken jt = String.IsNullOrEmpty(propertyname) ? _jObject : _jObject.SelectToken(propertyname);

            if (jt == null)
                return default(T);

            // http://stackoverflow.com/questions/732677/converting-from-string-to-t
            if (typeof(string).IsAssignableFrom(typeof(T)))
                return (T)System.Convert.ChangeType(jt.ToString(), typeof(T));

            if (nestedDictionary)
            {
                //JsonConvert use JsonSerializer to Deserialize
                return JsonConvert.DeserializeObject<T>(
                    jt.ToString(),
                    new NestedDictionaryConverter());
            }
            return JsonConvert.DeserializeObject<T>(jt.ToString());
        }

        /// <summary>
        /// 转换为(嵌套)Dictionary
        /// (JObject -> Dictionary)
        /// </summary>
        /// <param name="propertyname"></param>
        /// <returns></returns>
        public IDictionary<string, object> ConvertMap(string propertyname = null)
        {
            JToken jt = String.IsNullOrEmpty(propertyname) ? _jObject : _jObject.SelectToken(propertyname);
            if (jt == null)
                return default(IDictionary<string, object>);

            if (jt.Type != JTokenType.Object)
            {
                throw new NotSupportedException("only support JObject");
            }

            //JsonConvert use JsonSerializer to Deserialize
            return JsonConvert.DeserializeObject<IDictionary<string, object>>(
                jt.ToString(),
                new NestedDictionaryConverter());
        }

        /// <summary>
        /// 转换为(非嵌套)Dictionary
        /// (JObject -> Dictionary)
        /// </summary>
        /// <param name="propertyname"></param>
        /// <param name="removePropertyname"></param>
        /// <returns></returns>
        public IDictionary<string, object> ConvertNotNestedMap(string propertyname = null, bool removePropertyname = true)
        {
            JToken jt = String.IsNullOrEmpty(propertyname) ? _jObject : _jObject.SelectToken(propertyname);
            if (jt == null)
                return default(IDictionary<string, object>);

            IDictionary<string, object> map = new Dictionary<string, object>();

            ConvertNotNestedMapByJToken(jt, ref map);

            if (!String.IsNullOrEmpty(propertyname) && removePropertyname)
            {
                map = map.ToDictionary(
                    kv =>
                    {
                        // remove property name prefix
                        string str = kv.Key.Replace(propertyname, "");
                        if (str.StartsWith("."))
                        {
                            // is JObject
                            return str.Substring(1);
                        }
                        return str;
                    }
                    , kv => kv.Value);
            }
            return map;
        }

        #endregion

        #region 连接操作

        /// <summary>
        /// 合并JObject
        /// (JObject -> JObject)
        /// </summary>
        /// <param name="helper"></param>
        public void Concat(JsonHelper helper)
        {
            // http://stackoverflow.com/questions/14121010/merge-two-json-net-jtokens
            _jObject.Merge(helper._jObject);
        }

        /// <summary>
        /// 合并 TODO test
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyname"></param>
        public void ConcatObject(object obj, string propertyname = null)
        {
            if (String.IsNullOrEmpty(propertyname))
            {
                JToken jToken = JToken.FromObject(obj);
                if (jToken.Type != JTokenType.Object)
                    throw new NotSupportedException("concat object is not JObject, not type: " + jToken.Type);

                _jObject.Merge(jToken);
            }
            else
            {
                bool bResult = SaveProperty(propertyname, obj);
                if (!bResult)
                {
                    AddProperty(propertyname, obj);
                }
            }
        }

        /// <summary>
        /// 合并Map TODO test
        /// </summary>
        /// <param name="map">(嵌套)Dictionary</param>
        /// <param name="propertyname">Map使用的propertyname</param>
        public void ConcatMap(IDictionary<string, object> map, string propertyname = null)
        {
            ConcatObject(map, propertyname);
        }

        /// <summary>
        /// 合并Map
        /// </summary>
        /// <param name="map">(非嵌套)Dictionary</param>
        /// <param name="propertyname">Map使用的propertyname</param>
        public void ConcatNotNestedMap(IDictionary<string, object> map, string propertyname = null)
        {
            bool bResult;
            foreach (KeyValuePair<string, object> kv in map)
            {
                string key = kv.Key;
                if (!String.IsNullOrEmpty(propertyname))
                {
                    if (kv.Key.StartsWith("["))
                    {
                        key = propertyname + kv.Key;
                    }
                    else
                    {
                        key = propertyname + "." + kv.Key;
                    }
                }

                bResult = SaveProperty(key, kv.Value);
                if (!bResult)
                {
                    AddProperty(key, kv.Value);
                }
            }
        }

        #endregion

        #region Obsolete

        /// <summary>
        /// 生成Json字符串
        /// </summary>
        /// <returns></returns>
        [Obsolete("Use Convert<String>(null)")]
        public string CreateString()
        {
            return _jObject.ToString();
            //return JsonConvert.SerializeObject(jobject);
        }

        /// <summary>
        /// 生成Map
        /// </summary>
        /// <param name="propertyname"></param>
        /// <returns></returns>
        [Obsolete("Use ConvertNotNestedMap(?)")]
        public Dictionary<string, object> CreateMap(string propertyname)
        {
            IDictionary<string, object> map = new Dictionary<string, object>();

            JToken jt = _jObject.SelectToken(propertyname);

            if (jt is JValue)
            {
                throw new Exception("CreateMap only for JSON's Object and Array");
            }

            CreateMapByJToken(jt, ref map);

            return (Dictionary<string, object>)map;
        }

        /// <summary>
        /// 联合Map
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        [Obsolete("Use ConcatNotNestedMap(?)")]
        public bool JoinMap(Dictionary<string, object> map)
        {
            foreach (KeyValuePair<string, object> kv in map)
            {
                var bResult = SaveProperty(kv.Key, kv.Value);
                if (!bResult)
                {
                    AddProperty(kv.Key, kv.Value);
                }
            }

            return true;
        }

        /// <summary>
        /// 递归生成map
        /// </summary>
        /// <param name="jtoken"></param>
        /// <param name="map"></param>
        [Obsolete("Use ConvertNotNestedMap(?)")]
        private void CreateMapByJToken(JToken jtoken, ref IDictionary<string, object> map)
        {
            //cant be JValue
            //             if (jtoken is JValue)
            //             {
            //                 JValue jv = jtoken as JValue;
            //                 map.Add(jv.Path, jv.Value);
            //             }
            //            else if (jtoken is JObject)
            if (jtoken is JObject)
            {
                JEnumerable<JToken> je = jtoken.Children();
                foreach (JToken jt in je)
                {
                    //属性
                    JProperty jp = jt as JProperty;
                    if (jp == null || !jp.HasValues)
                    {
                        return;
                    }
                    if (jp.Value is JObject)
                    {
                        //对象
                        JObject joT = jp.Value as JObject;
                        CreateMapByJToken(joT, ref map);
                    }
                    else if (jp.Value is JArray)
                    {
                        //数组
                        JArray jaT = jp.Value as JArray;
                        foreach (JToken jtt in jaT)
                        {
                            CreateMapByJToken(jtt, ref map);
                        }
                    }
                    else
                    {
                        //基本类型
                        map.Add(jp.Path, jp.Value);
                    }
                }
            }
            else if (jtoken is JArray)
            {
                JEnumerable<JToken> je = jtoken.Children();
                foreach (JToken jt in je)
                {
                    CreateMapByJToken(jt, ref map);
                }
            }
            else
            {
                throw new Exception("param jtoken must be JSON's value");
            }
        }

        #endregion

        #endregion




        #region Converter

        /// <summary>
        /// JSON.NET 嵌套Map转换器
        /// 2016-03-12 + Support JsonObject in JsonArray
        /// http://stackoverflow.com/questions/6416017/json-net-deserializing-nested-dictionaries
        /// </summary>
        public class NestedDictionaryConverter : CustomCreationConverter<IDictionary<string, object>>
        {

            public override bool CanConvert(Type objectType)
            {
                // in addition to handling IDictionary<string, object>
                // we want to handle the deserialization of dict value
                // which is of type object
                return objectType == typeof(object) || base.CanConvert(objectType);
            }

            public override IDictionary<string, object> Create(Type objectType)
            {
                // only use in base.ReadJson()
                return new Dictionary<string, object>();
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.StartObject
                    || reader.TokenType == JsonToken.Null)
                    return base.ReadJson(reader, objectType, existingValue, serializer);
                // support JsonObject in JsonArray
                if (reader.TokenType == JsonToken.StartArray)
                    // cant, because ReadJson() will call Create(), cant create other type 
                    //return base.ReadJson(reader, typeof(List<object>), existingValue, serializer);
                    //
                    return serializer.Deserialize<IList<object>>(reader);

                // if the next token is not an object
                // then fall back on standard deserializer (strings, numbers etc.)
                return serializer.Deserialize(reader);
            }
        }

        #endregion

    }
}
