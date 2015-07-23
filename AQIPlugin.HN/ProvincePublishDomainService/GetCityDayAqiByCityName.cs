using System;
using AQI.Abstract;
using HN.Abstract;
using AQI;
using System.Collections.Generic;

namespace HN.ProvincePublishDomainService
{
    public class GetCityDayAqiByCityName : HNSrcUrl_Param
    {

        #region 静态变量

        private static string tag = "GetCityDayAqiByCityName";
        private static string name = "湖南城市24小时AQI";
        private static string url = "http://222.247.51.155:8025/ClientBin/Env-Publish-Province-RiaService-ProvincePublishDomainService.svc/binary/GetCityDayAqiByCityName";
        private static AQI.AqiConstant.SourceUpdataInterval sui = AQI.AqiConstant.SourceUpdataInterval.DAY;
        private static List<string> pn = new List<string>(){
            ".cityName"
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
