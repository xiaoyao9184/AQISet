using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using AQI.Interface;
using AQI.Abstract;
using AQI.Exception;

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
        private const string GROUP = "Group";
        private const string NAME = "Name";
        private const string ENEABLED = "Enabled";

        private const string REGEX_LOWWORLD = "^[a-z].*$";

        //ParamCycle.OnceAgain使用
        public const string ONCE = "ONCE";
        public const string AGAIN = "AGAIN";
        #endregion

        #region 字段

        private string pName;
        private string pRefer;
        private string pGroup;
        private bool pUnique;

        #endregion

        #region 属性

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get
            {
                return pName;
            }
        }

        /// <summary>
        /// 参照
        /// </summary>
        public string Refer
        {
            get
            {
                return pRefer;
            }
            set
            {
                pRefer = value;
            }
        }

        /// <summary>
        /// 分组
        /// </summary>
        public string Group
        {
            get
            {
                return pGroup;
            }
            set
            {
                pGroup = value;
            }
        }

        /// <summary>
        /// 唯一
        /// </summary>
        public bool Unique
        {
            get
            {
                return pUnique;
            }
            set
            {
                pUnique = value;
            }
        }

        #endregion

        public AqiParam(string name) 
        {
            pName = name;
        }

        #region Factory

        /// <summary>
        /// 读取更新时间
        ///     从 JSON 文件
        /// </summary>
        /// <param name="icp">ICacheParam</param>
        /// <returns></returns>
        public static DateTime ReadWriteTimeFormJson(ICacheParam icp)
        {
            try
            {
                //JSON路径
                string jsonPath = icp.GetJsonFile();
                FileInfo fi = new FileInfo(jsonPath);
                return fi.LastWriteTime;
            }
            catch (System.Exception ex)
            {
                throw new ParamException("读取参数文件错误", ex);
            }
        }

        /// <summary>
        /// 读取参数列表
        ///     从 JSON 文件
        /// </summary>
        /// <param name="icp">ICacheParam</param>
        /// <param name="listProperty">(可选)属性列表</param>
        /// <returns></returns>
        public static List<AqiParam> CreateListFormJson(ICacheParam icp, params string[] listProperty)
        {
            List<AqiParam> listParam = new List<AqiParam>();
            string propertyPath = String.Join(".", listProperty);

            try 
            { 
                //JSON路径
                string jsonPath = icp.GetJsonFile();
                if (!File.Exists(jsonPath))
                {
                    return listParam;
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
                else if (jt is JArray)
                {
                    //读取集合(任意个参数)
                    JEnumerable<JToken> je = jt.Children();
                    foreach (JToken j in je)
                    {
                        AqiParam ap = createParamFormJsonObject(j as JObject);
                        if (ap != null)
                            listParam.Add(ap);
                    }
                }
                else if (jt is JObject)
                {
                    //读取对象(仅一个参数)
                    AqiParam ap = createParamFormJsonObject(jt as JObject);
                    if(ap != null)
                        listParam.Add(ap);
                }
            }
            catch(System.Exception ex)
            {
                throw new ParamException("参数创建错误", ex);
            }

            return listParam;
        }

        /// <summary>
        /// 读取参数
        ///     自动识别Enabled、Name、Param、Refer、Group、各种小写
        /// </summary>
        /// <param name="jObject">JSONObject对象</param>
        /// <returns></returns>
        private static AqiParam createParamFormJsonObject(JObject jObject)
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

            //5分组
            jt = jObject.GetValue(GROUP);
            if (jt != null)
            {
                ap.pGroup = jt.ToString();
            }

            //if(ap.Count == 0){
            //    ap = null;
            //}

            return ap;
        }

        /// <summary>
        /// 读取参数列表
        ///     从 SrcUrl 接口
        /// </summary>
        /// <param name="iParseSrcUrlParam">实现IParseSrcUrlParam的SrcUrl</param>
        /// <param name="relySrcUrl">参数来源SrcUrl</param>
        /// <returns></returns>
        public static List<AqiParam> CreateListFormSrcUrl(IParseSrcUrlParam iParseSrcUrlParam, ISrcUrl relySrcUrl)
        {
            List<AqiParam> listParam = new List<AqiParam>();

            try 
            {
                if (relySrcUrl is ISrcUrlParam)
                {
                    ISrcUrlParam isup = relySrcUrl as ISrcUrlParam;
                    List<AqiParam> list = null;

                    if (isup is ICacheParam)
                    {
                        ICacheParam icp = isup as ICacheParam;
                        if (icp.IsParamsExpired())
                        {
                            icp.LoadParams();
                        }
                        list = icp.FilterParams();
                    }
                    else
                    {
                        list = isup.EnumParams();
                    }

                    if ((list == null) || (list.Count == 0))
                    {
                        throw new ParamException("缺少参数");
                    }

                    foreach (AqiParam ap in list)
                    {
                        byte[] data = data = isup.GetDate(ap);
                        List<AqiParam> aps = iParseSrcUrlParam.ParseParam(data);
                        listParam.AddRange(aps);
                    }
                }
                else
                {
                    byte[] data = relySrcUrl.GetDate();
                    List<AqiParam> aps = iParseSrcUrlParam.ParseParam(data);
                    listParam.AddRange(aps);
                }
            }
            catch (System.Exception ex)
            {
                throw new ParamException("参数创建错误", ex);
            }

            return listParam;
        }

        #endregion

    }
}
