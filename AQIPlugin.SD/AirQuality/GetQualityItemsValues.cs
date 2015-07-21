using AQI;
using AQI.Abstract;
using AQI.Exception;
using AQI.Interface;
using Helper.Util.HTTP;
using Newtonsoft.Json.Linq;
using SD.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace SD.AirQuality
{
    public class GetQualityItemsValues : AirQuality_POST, IParseSrcUrlParam, IDataType
    {

        #region 静态变量

        private static string tag = "GetQualityItemsValues";
        private static string name = "山东AQI站点AQI&浓度";
        private static string url = "http://58.56.98.78:8801/AirDeploy.web/Ajax/AirQuality/AirQuality.ashx";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.HOUR;
        private static List<string> pnList = new List<string>(){
            ""
        };
        private static AqiConstant.ParamSendType ppst = AqiConstant.ParamSendType.POST;
        private static new AqiConstant.ParamSourceType pst = AqiConstant.ParamSourceType.ISrcUrl;
        private static new AqiConstant.ParamUrlType put = AqiConstant.ParamUrlType.KEY_VALUE;

        private static AqiConstant.DataType dat = AqiConstant.DataType.JSON;

        #endregion

        #region 变量

        private ISrcUrl ParamISU = new GetStationMarkOnMap();

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
                return pnList;
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
            }
        }

        public List<AqiParam> ParseParam(byte[] data)
        {
            List<AqiParam> listParam = new List<AqiParam>();

            string json = Encoding.UTF8.GetString(data);
            JObject jo = JObject.Parse(json);
            JToken jt = jo.SelectToken("items");
            if (!(jt is JArray))
            {
                throw new DataDifferentException("与预期的数据不一致(items属性应该是JSON数组)，可能数据源已经发生变化");
            }

            JArray ja = jt as JArray;
            JEnumerable<JToken> je = ja.Children();
            foreach (JToken j in je)
            {
                if (!(j is JObject))
                {
                    throw new DataDifferentException("与预期的数据不一致(JSON数组子元素应该是对象)，可能数据源已经发生变化");
                }
                JObject joOne = j as JObject;
                JToken jtcode = joOne.GetValue("subid");
                if (jtcode == null)
                {
                    throw new DataDifferentException("与预期的数据不一致(JSON数组对象应该包含tfid属性)，可能数据源已经发生变化");
                }
                string name = jtcode.ToString() + "号站点";

                //名称
                JToken jtname = joOne.GetValue("pname");
                if (jtname != null)
                {
                    name = name + "-" + jtname;
                }
                JToken jtcity = joOne.GetValue("cityName");
                if (jtcity != null)
                {
                    name = name + "-" + jtcity;
                }

                AqiParam ap = new AqiParam(name);
                ap.Add("Method", "GetQualityItemsValues");
                ap.Add("StationID", jtcode.ToString());
                listParam.Add(ap);
            }

            return listParam;
        }

        #endregion

        #region IDataType

        public virtual AqiConstant.DataType DAT
        {
            get
            {
                return dat;
            }
        }

        #endregion

    }
}
