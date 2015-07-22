using System;
using AQI.Abstract;
using QH.Abstract;
using AQI;
using System.Collections.Generic;
using AQI.Interface;
using System.Xml.Linq;
using System.IO;

namespace QH.ProvincePublishDomainService.Auto
{
    public class GetAqiHistoryByCondition_Auto : QHSrcUrl_Param, IParseSrcUrlParam
    {

        #region 静态变量

        private static string tag = "GetAqiHistoryByCondition_Auto";
        private static string name = "青海站点24小时历史AQI";
        private static string url = "http://221.207.21.89:8080/ClientBin/Env-Publish-Province-RiaService-ProvincePublishDomainService.svc/binary/GetAqiHistoryByCondition";
        private static AQI.AqiConstant.SourceUpdataInterval sui = AQI.AqiConstant.SourceUpdataInterval.DAY;
        private static List<string> pn = new List<string>(){
            ".stationCode"
        };
        private static AqiConstant.ParamSendType ps = AqiConstant.ParamSendType.GET;

        private static new AqiConstant.ParamSourceType pst = AqiConstant.ParamSourceType.ISrcUrl;

        #endregion

        #region 变量

        private ISrcUrl ParamISU = new GetAqiCityStation();

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
        public override AQI.AqiConstant.SourceUpdataInterval SUI
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
        public override AQI.AqiConstant.ParamSourceType ParamSourceType
        {
            get
            {
                return pst;
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

            XNamespace b = "http://schemas.datacontract.org/2004/07/Env.Publish.Province.DAL";
            XDocument xd = XDocument.Load(new MemoryStream(data));
            IEnumerable<XElement> elements = xd.Descendants(XName.Get("AQICityStation", b.ToString()));

            foreach (XElement node in elements)
            {
                string name = node.Element(XName.Get("PositionName", b.ToString())).Value;
                string id = node.Element(XName.Get("StationID", b.ToString())).Value;
                string cityName = node.Element(XName.Get("CityName", b.ToString())).Value;

                AqiParam ap = new AqiParam(id + "_" + name);
                ap.Add("stationCode", id);
                listParam.Add(ap);
            }
            return listParam;
        }

        #endregion

    }
}
