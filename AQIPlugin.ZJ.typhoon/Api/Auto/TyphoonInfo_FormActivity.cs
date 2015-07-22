using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AQI;
using AQI.Interface;
using AQI.Abstract;
using AQI.Exception;

namespace typhoon.Api.Auto
{
    public class TyphoonInfo_FormActivity : AParamSrcUrl, IParseSrcUrlParam
    {

        #region 静态变量

        private static string tag = "TyphoonInfo_FormActivity";
        private static string name = "浙江台风详情";
        private static string url = "http://typhoon.zjwater.gov.cn/Api/TyphoonInfo";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.HOUR;
        private static bool pi = true;
        private static List<string> pn = new List<string>(){
            "ParamType."
        };
        private static AqiConstant.ParamSendType ppst = AqiConstant.ParamSendType.GET;

        private static new AqiConstant.ParamSourceType pst = AqiConstant.ParamSourceType.ISrcUrl;
        private static new AqiConstant.ParamFilterType pft = AqiConstant.ParamFilterType.NONE;
        private static new AqiConstant.ParamUrlType put = AqiConstant.ParamUrlType.PATH;

        #endregion

        #region 变量

        private ISrcUrl ParamISU = new TyhoonActivity();

        #endregion

        #region 属性

        public override string Tag
        {
            get
            {
                return tag;
            }
        }
        public override string Name
        {
            get
            {
                return name;
            }
        }
        public override string Url
        {
            get
            {
                return url;
            }
        }
        public override IAqiWeb IAW
        {
            get
            {
                return iaw;
            }
            set
            {
                base.iaw = value;
                this.ParamISU.IAW = value;
            }
        }
        public override AqiConstant.SourceUpdataInterval SUI
        {
            get
            {
                return sui;
            }
        }
        public override bool ParamIgnoreEmpty
        {
            get
            {
                return pi;
            }
        }
        public override List<string> ParamName
        {
            get
            {
                return pn;
            }
        }
        public override AqiConstant.ParamSendType ParamSendType
        {
            get
            {
                return ppst;
            }
        }
        public override AqiConstant.ParamSourceType ParamSourceType
        {
            get
            {
                return pst;
            }
        }
        public override AqiConstant.ParamFilterType ParamFilterType
        {
            get
            {
                return pft;
            }
        }
        public override AqiConstant.ParamUrlType ParamUrlType
        {
            get
            {
                return put;
            }
        }

        #endregion

        #region IParseSrcUrlParam

        public ISrcUrl ParamSrcUrl 
        {
            get
            {
                return ParamISU;
                //Dictionary<string, ISrcUrl> all = IAW.GetAllSrcUrl();
                //string key = typeof(TyphoonList).Fullname;
                //return all[key];
            }
        }

        public List<AqiParam> ParseParam(byte[] data)
        {
            List<AqiParam> listParam = new List<AqiParam>();

            string json = Encoding.UTF8.GetString(data);
            JArray ja = JArray.Parse(json);
            JEnumerable<JToken> je = ja.Children();
            foreach (JToken j in je)
            {
                if (!(j is JObject))
                {
                    throw new DataDifferentException("与预期的数据不一致(JSON数组子元素应该是对象)，可能数据源已经发生变化");
                }
                JObject joOne = j as JObject;
                JToken jttf = joOne.GetValue("tfid");
                if (jttf == null)
                {
                    throw new DataDifferentException("与预期的数据不一致(JSON数组对象应该包含tfid属性)，可能数据源已经发生变化");
                }
                AqiParam ap = new AqiParam(jttf.ToString() + "号台风");
                ap.Add("", jttf.ToString());
                listParam.Add(ap);

            }
            
            return listParam;
        }

        #endregion

    }
}
