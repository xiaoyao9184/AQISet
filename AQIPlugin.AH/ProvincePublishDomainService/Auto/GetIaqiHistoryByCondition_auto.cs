﻿using System;
using AQI.Abstract;
using AH.Abstract;
using AQI;
using System.Collections.Generic;
using AQI.Interface;
using AH.ProvincePublishDomainService;
using System.Xml.Linq;
using System.IO;

namespace AH.ProvincePublishDomainService.Auto
{
    public class GetIaqiHistoryByCondition_Auto : AHSrcUrl_Param, IParseSrcUrlParam
    {

        #region 静态变量

        private static string tag = "GetIaqiHistoryByCondition_Auto";
        private static string name = "安徽站点24小时历史浓度";
        private static string url = "http://www.ahemc.cn:8016/ClientBin/Env-Publish-Province-RiaService-ProvincePublishDomainService.svc/binary/GetIaqiHistoryByCondition";
        private static AQI.AqiConstant.SourceUpdataInterval sui = AQI.AqiConstant.SourceUpdataInterval.DAY;
        private static List<string> ParamsList = new List<string>(){
            ".stationCode"
        };
        private static AqiConstant.ParamSendType ps = AqiConstant.ParamSendType.GET;

        private static new AqiConstant.ParamSourceType pst = AqiConstant.ParamSourceType.ISrcUrl;

        #endregion

        #region 变量

        private ISrcUrl ParamISU = new GetAQIDataByCityName();

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
                return ParamsList;
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

            //XNamespace b = "http://schemas.datacontract.org/2004/07/Env.Publish.Province.DAL";
            //XDocument xd = XDocument.Load(new MemoryStream(data));
            //IEnumerable<XElement> elements = xd.Descendants(XName.Get("AQICityStation", b.ToString()));

            //foreach (XElement node in elements)
            //{
            //    string name = node.Element(XName.Get("PositionName", b.ToString())).Value;
            //    string id = node.Element(XName.Get("StationID", b.ToString())).Value;
            //    string cityName = node.Element(XName.Get("CityName", b.ToString())).Value;

            //    AqiParam ap = new AqiParam(id + "_" + name);
            //    ap.Add("stationCode", id);
            //    listParam.Add(ap);
            //}
            XNamespace b = "http://schemas.datacontract.org/2004/07/Env.Publish.Province.DAL";
            XDocument xd = XDocument.Load(new MemoryStream(data));
            IEnumerable<XElement> elements = xd.Descendants(XName.Get("AQIDataPublishLive", b.ToString()));

            foreach (XElement node in elements)
            {
                string name = node.Element(XName.Get("PositionName", b.ToString())).Value;
                string id = node.Element(XName.Get("StationCode", b.ToString())).Value;
                string cityName = node.Element(XName.Get("Area", b.ToString())).Value;

                AqiParam ap = new AqiParam(id + "_" + name);
                ap.Add("stationCode", id);
                listParam.Add(ap);
            }
            return listParam;
        }

        #endregion

    }
}
