using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Helper.JSON
{
    /// <summary>
    /// JSON 帮助对象
    /// xiaoyao9184
    /// 1.2 2015-02-12 + dele
    /// 1.1 2015-02-11 + add
    /// 1.0 2015-02-06
    /// </summary>
    public class JsonHelper
    {

        #region 字段

        /// <summary>
        /// 缓存
        /// </summary>
        private JObject jobject;

        #endregion

        public JsonHelper(string jsonText)
        {
            jobject = JObject.Parse(jsonText);
        }

        #region 方法

        #region 提取

        /// <summary>
        /// 递归生成map
        /// </summary>
        /// <param name="jtoken"></param>
        /// <param name="map"></param>
        private void CreateMapByJToken(JToken jtoken, ref Dictionary<string, object> map)
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
                else if (jp.Value is JObject)
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

        /// <summary>
        /// 生成Map
        /// </summary>
        /// <param name="propertyname"></param>
        /// <returns></returns>
        public Dictionary<string, object> CreateMap(string propertyname)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();

            JToken jt = jobject.SelectToken(propertyname);

            CreateMapByJToken(jt, ref map);

            return map;
        }

        /// <summary>
        /// 生成Json字符串
        /// </summary>
        /// <returns></returns>
        public string CreateString()
        {
            return jobject.ToString();
            //return JsonConvert.SerializeObject(jobject);
        }

        #endregion

        #region 存入

        /// <summary>
        /// 递归添加属性
        /// </summary>
        /// <param name="jtoken"></param>
        /// <param name="path"></param>
        /// <param name="value"></param>
        private void AddPropertyByJToken(JToken jtoken, string path, object value)
        {
            JObject jo = jtoken as JObject;
            int p = path.IndexOf('.');
            if (p != -1)
            {
                bool isArray = false;   //标识为数组
                string name = path.Substring(0, p);
                if (name.EndsWith("]"))
                {
                    isArray = true;
                }

                JToken jt = jo.SelectToken(name);

                if (jt == null)
                {
                    JObject jot = new JObject();
                    if (isArray)
                    {
                        string arrname = name.Substring(0, name.IndexOf('['));
                        JArray ja = jo.SelectToken(arrname) as JArray;
                        if (ja == null)
                        {
                            //数组不存在
                            ja = new JArray();
                            jo.Add(arrname, ja);
                        }
                        //添加到数组
                        ja.Add(jot);
                    }
                    else
                    {
                        jo.Add(name, jot);
                    }
                    jt = jot;
                }

                AddPropertyByJToken(jt, path.Substring(p+1), value);
            }
            else
            {
                Type t = value.GetType();
                if (t == typeof(string))
                {
                    //String类型可能还会是JSON文本
                    JToken jtt = null;
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
                    jo.Add(path, jtt);
                }
                else
                {
                    //基本类型
                    jo.Add(path, JToken.FromObject(value));
                }
            }
        }

        /// <summary>
        /// 联合Map
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        public bool JoinMap(Dictionary<string, object> map)
        {
            bool bResult = false;

            foreach (KeyValuePair<string, object> kv in map)
            {
                bResult = SaveProperty(kv.Key, kv.Value);
                if(!bResult)
                {
                    AddProperty(kv.Key, kv.Value);
                }
            }

            return true;
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
            JToken jt = jobject.SelectToken(propertyname);

            if (jt == null)
            {
                return null;
            }
            else if (jt is JValue)
            {
                JValue jv = jt as JValue;
                return jv.Value<string>();
            }
            else
            {
                return jt.ToString();
            }
        }

        /// <summary>
        /// 保存属性
        /// </summary>
        /// <param name="propertyname"></param>
        /// <param name="value">任意类型</param>
        /// <returns></returns>
        public bool SaveProperty(string propertyname, object value)
        {
            JToken jt = jobject.SelectToken(propertyname);
            if (jt == null)
            {
                return false;
            }

            Type t = value.GetType();
            if (t == typeof(string))
            {
                //String类型可能还会是JSON文本
                JToken jtt = null;
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
            AddPropertyByJToken(jobject,propertyname,value);

            return true;
        }

        /// <summary>
        /// 删除属性
        /// </summary>
        /// <param name="propertyname"></param>
        /// <returns></returns>
        public bool DeleProperty(string propertyname)
        {
            JToken jt = jobject.SelectToken(propertyname);
            if (jt == null)
            {
                return false;
            }
            jt.Parent.Remove();
            return true;
        }

        #endregion

        #endregion

    }
}
