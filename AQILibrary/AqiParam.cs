using System;
using System.Collections.Generic;
using AQI.Interface;
using System.IO;
using Newtonsoft.Json.Linq;
using AQI.Abstract;
using System.Text.RegularExpressions;

namespace AQI
{
    /// <summary>
    /// 参数
    /// </summary>
    public class AqiParam : Dictionary<string,string>
    {

        #region 常用字符串

        public const string PARAMS = "Params";
        private const string PARAM = "Param";
        private const string REFER = "Refer";
        private const string NAME = "Name";
        private const string ENEABLED = "Enabled";

        private const string REGEX_LOWWORLD = "^[a-z].*$";

        #endregion

        #region 字段

        private string pName;
        private string pRefer;

        #endregion

        #region 属性

        public string Name
        {
            get
            {
                return pName;
            }
        }

        public string Refer
        {
            get
            {
                return pRefer;
            }
        }

        #endregion

        public AqiParam(string name) 
        {
            pName = name;
        }

        #region Factory

        /// <summary>
        /// 从 JSON配置文件 读取参数列表
        /// </summary>
        /// <param name="psc"></param>
        /// <param name="propertyname"></param>
        /// <returns></returns>
        public static List<AqiParam> CreateListFormJson(ISrcUrl psc, string propertyname)
        {
            List<AqiParam> listParam = new List<AqiParam>();

            //JSON路径
            string jsonPath = psc.IAW.getJsonFile();

            //读取JSON
            StreamReader sr = new StreamReader(jsonPath);
            string jsonText = sr.ReadToEnd();
            //转JSON Object
            JObject jo = JObject.Parse(jsonText);
            JToken jt = jo.SelectToken(psc.TAG + "." + propertyname);
            
            if (jt == null || !jt.HasValues)
            {
                return null;
            }
            else if (jt is JArray)
            {
                //读取集合
                JEnumerable<JToken> je = jt.Children();
                foreach (JToken j in je)
                {
                    listParam.Add(CreateParamFormJsonObject(j as JObject));
                }
            }
            else if (jt is JObject)
            {
                //读取对象
                listParam.Add(CreateParamFormJsonObject(jt as JObject));
            }

            return listParam;
        }

        /// <summary>
        /// 从 JSONObject对象 读取参数
        /// </summary>
        /// <param name="jObject"></param>
        /// <returns></returns>
        private static AqiParam CreateParamFormJsonObject(JObject jObject)
        {
            //检查4个属性
            //1开启
            JToken jt = jObject.GetValue(ENEABLED);
            if(jt == null)
            {
                return null;
            }
            else if (jt.ToObject<bool>() == false)
            {
                return null;
            }
            //2名称
            jt = jObject.GetValue(NAME);
            if(jt == null)
            {
                return null;
            }
            //缓存名称
            string name = jt.ToString();
            AqiParam ap = new AqiParam(name);
            //3参数
            jt = jObject.GetValue(PARAM);
            if (jt == null)
            {
                //没有Param属性
                //将所有其他非首字母大写的属性当作参数
                foreach (KeyValuePair<string, JToken> kv in jObject)
                {
                    if (Regex.IsMatch(kv.Key, REGEX_LOWWORLD))
                    {
                        ap.Add(kv.Key, kv.Value.ToString());
                    }
                }
            }
            else
            {
                //有Param属性
                if (jt.Type == JTokenType.String)
                {
                    ap.Add("", jt.ToString());
                }
                else if (jt.Type == JTokenType.Object)
                {
                    foreach (KeyValuePair<string, JToken> kv in jt as JObject)
                    {
                        if (Regex.IsMatch(kv.Key, REGEX_LOWWORLD))
                        {
                            ap.Add(kv.Key, kv.Value.ToString());
                        }
                    }
                }
            }

            //4参数参照
            jt = jObject.GetValue(REFER);
            if (jt != null)
            {
                ap.pRefer = jt.ToString();
            }

            if(ap.Count == 0){
                ap = null;
            }

            return ap;
        }

        #endregion

    }
}
