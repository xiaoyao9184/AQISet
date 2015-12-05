using System;
using AQI.Abstract;
using NX.Abstract;
using AQI;
using System.Collections.Generic;

namespace NX.ProvincePublishDomainService
{
    public class GetIaqiHistoryByCondition : NXSrcUrl_Param
    {

        #region 静态变量

        private static string tag = "GetIaqiHistoryByCondition";
        private static string name = "宁夏站点24小时历史浓度";
        private static string url = "http://119.60.12.114:8080/ClientBin/Env-Publish-Province-RiaService-ProvincePublishDomainService.svc/binary/GetIaqiHistoryByCondition";
        private static AQI.AqiConstant.SourceUpdataInterval sui = AQI.AqiConstant.SourceUpdataInterval.DAY;
        private static List<string> pn = new List<string>(){
            ".stationCode"
        };
        private static AqiConstant.ParamSendType ps = AqiConstant.ParamSendType.GET;

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

        #endregion

    }
}
