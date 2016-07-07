using AQI;
using AQI.Exception;
using AQI.Interface;
using jsair.Abstract;
using jsair.JSAQPPSERVICES;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jsair.JSAQPPSERVICES_DEBUG
{
    public class LSZDSB_Auto : jsairSrcUrl, IParseSrcUrlParam
    {

        #region 静态变量

        private static string tag = "LSZDSB_Auto";
        private static string name = "江苏站点污染物历史(24小时)";
        private static string url = "http://218.94.78.75:20001/JSAQPPSERVICES/REST/V100/STATION/{0}/{1}/{2}/{3}/{4}/Histroy?token={5}";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.DAY;
        private static List<string> pn = new List<string>(){
            "pollutant", "timestart", "timeend", "citycode", "stationcode"
        };
        private static AqiConstant.ParamSendType ps = AqiConstant.ParamSendType.GET;
        private static new AqiConstant.ParamSourceType pst = AqiConstant.ParamSourceType.ISrcUrl;

        #endregion

        #region 变量

        private ISrcUrl ParamISU = new StationAQIDayNow();

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
                return ps;
            }
        }
        public override AqiConstant.ParamSourceType ParamSourceType
        {
            get
            {
                return pst;
            }
        }

        #endregion

        #region 方法

        #region IMakeParam接口

        /// <summary>
        /// 拼接含参数Url
        ///     重写
        /// </summary>
        /// <param name="param">参数列表</param>
        /// <returns>完整URL</returns>
        public override string MakeUrl(AqiParam param)
        {
            return string.Format(Url, 
                param["pollutant"],
                param["timestart"], 
                param["timeend"], 
                param["citycode"],
                param["stationcode"],
                token);
        }

        #endregion

        #endregion

        #region IParseSrcUrlParam

        public ISrcUrl ParamSrcUrl
        {
            get
            {
                return ParamISU;
            }
        }

        public List<AqiParam> ParseParam(byte[] data)
        {
            List<AqiParam> list = AqiParam.CreateListFormJson(this, this.Tag, AqiParam.PARAMS);
            List<AqiParam> listParam = new List<AqiParam>();

            string json = Encoding.UTF8.GetString(data);

            JObject jo = JObject.Parse(json);
            JToken jdata = jo.GetValue("data");
            if (!(jdata is JArray))
            {
                throw new DataDifferentException("与预期的数据不一致(JSON对象应该包含data属性)，可能数据源已经发生变化");
            }
            JEnumerable<JToken> je = jdata.Children();
            foreach (JToken j in je)
            {
                if (!(j is JObject))
                {
                    throw new DataDifferentException("与预期的数据不一致(JSON数组子元素应该是对象)，可能数据源已经发生变化");
                }
                JObject joOne = j as JObject;
                JToken jcity = joOne.GetValue("xzqdm");
                if (jcity == null)
                {
                    throw new DataDifferentException("与预期的数据不一致(JSON数组对象应该包含xzqdm属性)，可能数据源已经发生变化");
                }
                JToken jstationname = joOne.GetValue("zdmc");
                if (jstationname == null)
                {
                    throw new DataDifferentException("与预期的数据不一致(JSON数组对象应该包含zdmc属性)，可能数据源已经发生变化");
                }
                JToken jstation = joOne.GetValue("zddm");
                if (jstation == null)
                {
                    throw new DataDifferentException("与预期的数据不一致(JSON数组对象应该包含zddm属性)，可能数据源已经发生变化");
                }

                foreach(AqiParam p in list)
                {
                    AqiParam ap = new AqiParam(p["pollutant"] + @"\" + jstation.ToString() + "-" + jstationname.ToString());
                    ap.Add("pollutant", p["pollutant"]);
                    ap.Add("timestart", DateTime.Now.AddDays(-1).ToString("yyyyMMddHH0000"));
                    ap.Add("timeend", DateTime.Now.ToString("yyyyMMddHH0000"));
                    ap.Add("citycode", jcity.ToString());
                    ap.Add("stationcode", jstation.ToString());
                    listParam.Add(ap);
                }
            }

            return listParam;
        }

        #endregion

    }
}
