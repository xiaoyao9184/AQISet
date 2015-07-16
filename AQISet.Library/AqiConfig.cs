using AQI.Exception;
using AQI.Interface;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AQI
{
    /// <summary>
    /// 配置
    /// </summary>
    public class AqiConfig
    {
        
        #region 常用字符串

        private const string CUSTOM = "Custom";
        private const string NAME = "Name";
        private const string ENEABLED = "Enabled";

        #endregion

        #region 字段

        private string cName;
        private bool cEnabled;
        private bool cCustom;

        #endregion

        #region 属性

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get
            {
                return cName;
            }
        }

        /// <summary>
        /// 参照
        /// </summary>
        public bool Enabled
        {
            get
            {
                return cEnabled;
            }
            set
            {
                cEnabled = value;
            }
        }

        /// <summary>
        /// 自定义
        /// </summary>
        public bool Custom
        {
            get
            {
                return cCustom;
            }
            set
            {
                cCustom = value;
            }
        }

        #endregion

        #region Factory

        /// <summary>
        /// 读取更新时间
        ///     从 JSON 文件 
        /// </summary>
        /// <param name="icc">ICacheConfig</param>
        /// <returns></returns>
        public static DateTime ReadWriteTimeFormJson(ICacheConfig icc)
        {
            try
            {
                //JSON路径
                string jsonPath = icc.GetJsonFile();
                FileInfo fi = new FileInfo(jsonPath);
                return fi.LastWriteTime;
            }
            catch (System.Exception ex)
            {
                throw new ConfigException("读取配置文件错误", ex);
            }
        }

        /// <summary>
        /// 读取配置列表
        ///     从 JSON 文件
        /// </summary>
        /// <param name="icc">ICacheConfig</param>
        /// <param name="listProperty">(可选)属性列表</param>
        /// <returns></returns>
        public static List<AqiConfig> CreateListFormJson(ICacheConfig icc, params string[] listProperty)
        {
            List<AqiConfig> listConfig = new List<AqiConfig>();
            string propertyPath = String.Join(".", listProperty);

            try
            {
                //JSON路径
                string jsonPath = icc.GetJsonFile();

                if(!File.Exists(jsonPath))
                {
                    return listConfig;
                }

                //读取JSON
                StreamReader sr = new StreamReader(jsonPath);
                string jsonText = sr.ReadToEnd();
                //转JSON Object
                JObject jo = JObject.Parse(jsonText);
                JToken jt = jo.SelectToken(propertyPath);

                if (jt == null || !jt.HasValues)
                {
                    return null;
                }
                else if (jt is JObject)
                {
                    //读取集合(任意个参数)
                    JEnumerable<JToken> je = jt.Children();
                    foreach (JToken j in je)
                    {
                        if(j is JProperty)
                        {
                            JProperty jp = j as JProperty;

                            //读取对象(仅一个配置)
                            AqiConfig ac = createConfigFormJsonObject(jp.Value as JObject);
                            ac.cName = jp.Name;
                            if (ac != null)
                                listConfig.Add(ac);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new ConfigException("配置创建错误", ex);
            }

            return listConfig;
        }

        /// <summary>
        /// 读取配置
        ///     自动识别Enabled、Custom
        /// </summary>
        /// <param name="jObject">JSONObject对象</param>
        /// <returns></returns>
        private static AqiConfig createConfigFormJsonObject(JObject jObject)
        {
            AqiConfig ac = new AqiConfig();

            //检查4个属性
            //1开启
            JToken jt = jObject.GetValue(ENEABLED);
            if (jt == null)
            {
                ac.cEnabled = false;
            }
            else if (jt.ToObject<bool>() == false)
            {
                ac.cEnabled = false;
            }
            else
            {
                ac.cEnabled = true;
            }
            
            //2名称
            //jt = jObject.GetValue(NAME);
            //if (jt == null)
            //{
            //    return null;
            //}
            //缓存名称
            //string name = jt.ToString();
            
            //3自定义
            jt = jObject.GetValue(CUSTOM);
            if (jt == null)
            {
                ac.cCustom = false;
            }
            else if (jt.ToObject<bool>() == false)
            {
                ac.cCustom = false;
            }
            else
            {
                ac.cCustom = true;
            }

            return ac;
        }

        #endregion

    }
}
