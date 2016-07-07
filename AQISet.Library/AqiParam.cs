using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json.Linq;
using AQI.Interface;
using AQI.Abstract;
using AQI.Exception;
using Newtonsoft.Json;

namespace AQI
{
    /// <summary>
    /// 参数
    /// </summary>
    public class AqiParam : Dictionary<string,string>
    {

        #region 常用字符串

        private const string HEADER = "Header";
        private const string BODY = "Body";
        public const string PARAMS = "Params";
        private const string PARAM = "Param";
        private const string PERMUTATION = "Permutation";
        private const string REFER = "Refer";
        private const string GROUP = "Group";
        private const string NAME = "Name";
        private const string ENEABLED = "Enabled";
        private const string TEMPLATE = "Template";
        private const string REGEX_LOWWORLD = "^[a-z].*$";

        //ParamCycle.OnceAgain使用
        public const string ONCE = "ONCE";
        public const string AGAIN = "AGAIN";
        //Body使用
        public const string BODY_TYPE = "Type";
        public const string BODY_CONTENT = "Content";

        #endregion

        #region 字段

        private string pName;
        private bool pTemplate;
        private string pRefer;
        private string pGroup;
        /// <summary>
        /// TODO 添加置换参数
        /// </summary>
        private bool bPermutation;
        private bool pUnique;
        private Dictionary<string, string> pHeader;
        private byte[] pBody; 

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
        /// 模板
        /// </summary>
        public bool IsTemplate
        {
            get
            {
                return pTemplate;
            }
            set
            {
                pTemplate = value;
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

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string,string> Header
        {
            get
            {
                return pHeader;
            }
            set
            {
                pHeader = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public byte[] Body
        {
            get
            {
                return pBody;
            }
            set
            {
                pBody = value;
            }
        }


        #endregion

        public AqiParam(string name) 
        {
            pName = name;
        }

        public AqiParam(string name, AqiParam aqiParam)
        {
            pName = name;
            if (aqiParam != null)
            {
                pRefer = aqiParam.pRefer;
                pGroup = aqiParam.pGroup;
                pRefer = aqiParam.pRefer;
                bPermutation = aqiParam.bPermutation;
                pUnique = aqiParam.pUnique;
                pHeader = aqiParam.pHeader;
                pBody = aqiParam.pBody;

                foreach (var kv in aqiParam)
                {
                    base.Add(kv.Key, kv.Value);
                }
            }
        }

        public AqiParam(AqiParam aqiParam, Dictionary<string,string> map)
        {
            pName = aqiParam.pName;
            pRefer = aqiParam.pRefer;
            pGroup = aqiParam.pGroup;
            pRefer = aqiParam.pRefer;
            bPermutation = aqiParam.bPermutation;
            pUnique = aqiParam.pUnique;
            foreach (var kv in map)
            {
                this.Add(kv.Key, kv.Value);
                pName = pName.Replace("{" + kv.Key + "}", kv.Value);
            }
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
                    AqiParam baseAP = null;
                    foreach (JToken j in je)
                    {
                        AqiParam ap = createParamFormJsonObject(j as JObject, baseAP);
                        if (ap != null) 
                        {
                            if (ap.IsTemplate)
                            {
                                baseAP = ap;
                            }
                            else
                            {
                                listParam.Add(ap); 
                            }
                        }
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
        /// <param name="baseAqiParam">模板AqiParam</param>
        /// <returns></returns>
        private static AqiParam createParamFormJsonObject(JObject jObject, AqiParam baseAqiParam = null)
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
            AqiParam ap = null;
            //2名称
            jt = jObject.GetValue(TEMPLATE);
            if (jt != null && jt.ToObject<bool>() == true)
            {
                //模板
                ap = new AqiParam(TEMPLATE);
                ap.IsTemplate = true;
            }
            else
            {
                jt = jObject.GetValue(NAME);
                if (jt == null)
                {
                    return null;
                }
                //缓存名称
                string name = jt.ToString();
                ap = new AqiParam(name, baseAqiParam);
            }

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
                        //TODO 是否使用ap[]= 代替可以忽略相同键错误
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

            //6置换
            jt = jObject.GetValue(PERMUTATION);
            if (jt != null)
            {
                ap.pGroup = jt.ToString();
            }

            //7Header
            jt = jObject.GetValue(HEADER);
            if (jt != null)
            {
                ap.pHeader = JsonConvert.DeserializeObject<Dictionary<string, string>>(jt.ToString());
            }

            //8Body
            jt = jObject.GetValue(BODY);
            if (jt != null)
            {
                AqiConstant.BodyFormatType bft = AqiConstant.BodyFormatType.NONE;
                string content = null;
                JToken jtsub = jt.SelectToken(BODY_TYPE);
                if (jtsub != null)
                {
                    if(Enum.TryParse(jtsub.ToString(), out bft))
                    {
                        jtsub = jt.SelectToken(BODY_CONTENT);
                        if (jtsub != null)
                        {
                            content = jtsub.ToString();
                        }
                    }
                    else
                    {
                        throw new NotSupportedException("参数Body.Type=" + jtsub.ToString() + "是不被支持的！");
                    }
                }

                if (!String.IsNullOrEmpty(content))
                {
                    switch (bft)
                    {
                        case AqiConstant.BodyFormatType.Hex:
                            ap.pBody = Enumerable.Range(0, content.Length)
                                .Where(x => x % 2 == 0)
                                .Select(x => Convert.ToByte(content.Substring(x, 2), 16))
                                .ToArray();
                            break;
                        case AqiConstant.BodyFormatType.Base64:
                            ap.pBody = Convert.FromBase64String(content);
                            break;
                        case AqiConstant.BodyFormatType.Text:
                            ap.pBody = Encoding.UTF8.GetBytes(content);
                            break;
                        case AqiConstant.BodyFormatType.NONE:
                        default:
                            break;
                    }
                }
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

            //TODO 应该将 runner的处理过程公开，交由Runner处理，公用代码，考虑将Process处理函数静态化
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
                        byte[] data = data = isup.GetData(ap);
                        List<AqiParam> aps = iParseSrcUrlParam.ParseParam(data);
                        listParam.AddRange(aps);
                    }
                }
                else
                {
                    byte[] data = relySrcUrl.GetData();
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
