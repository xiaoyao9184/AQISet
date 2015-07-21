using AQI;
using AQI.Abstract;
using AQI.Exception;
using AQI.Interface;
using Helper.Util.HTTP;
using Newtonsoft.Json.Linq;
using SD.Abstract;
using SD.AirQuality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace SD.Images
{
    public class Images : AirQuality_GET, IParseSrcUrlParam, IDataType
    {

        #region 静态变量

        private static string tag = "Images";
        private static string name = "山东AQI站点浓度照片";
        private static string url = "http://60.208.91.115:6600/Images";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.HOUR;
        private static List<string> pnList = new List<string>(){
            ""
        };
        private static AqiConstant.ParamSendType ppst = AqiConstant.ParamSendType.GET;
        private static new AqiConstant.ParamSourceType pst = AqiConstant.ParamSourceType.ISrcUrl;
        private static new AqiConstant.ParamUrlType put = AqiConstant.ParamUrlType.PATH;

        private static AqiConstant.DataType dat = AqiConstant.DataType.NONE;

        #endregion

        #region 变量

        private ISrcUrl ParamISU = new GetNjdValue();

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
            JObject joOne = JObject.Parse(json);
            JToken jtimg = joOne.GetValue("VisibleImage");
            if (jtimg == null)
            {
                throw new DataDifferentException("与预期的数据不一致(JSON数组对象应该包含VisibleImage属性)，可能数据源已经发生变化");
            }
            if(String.IsNullOrEmpty(jtimg.ToString()))
            {
                return listParam;
            }
            string name = jtimg.ToString();

            AqiParam ap = new AqiParam(name);
            ap.Unique = true;
            ap.Add("", jtimg.ToString());
            listParam.Add(ap);

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
