using System;
using AQI.Abstract;
using QH.Abstract;
using AQI;
using System.Collections.Generic;

namespace QH.ProvincePublishDomainService
{
    public class GetIaqiPublishEtyByCityName : QHSrcUrl_Param
    {

        #region 静态变量

        private static string tag = "GetIaqiPublishEtyByCityName";
        private static string name = "青海城市站点1小时AQI";
        private static string url = "http://221.207.21.89:8080/ClientBin/Env-Publish-Province-RiaService-ProvincePublishDomainService.svc/binary/GetIaqiPublishEtyByCityName";
        private static AQI.AqiConstant.SourceUpdataInterval sui = AQI.AqiConstant.SourceUpdataInterval.HOUR;
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
