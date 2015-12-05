using System;
using System.Collections.Generic;
using AQI;
using AQI.Abstract;
using AQI.Interface;

namespace LN.AirQualityService
{
    public class GetReportPointAQI : ABaseSrcUrl
    {

        #region 静态变量

        private static string tag = "GetReportPointAQI";
        private static string name = "城市列表";
        private static string url = "http://211.137.19.74:8089/AirQualityService.asmx";
        private static AQI.AqiConstant.SourceUpdataInterval sui = AQI.AqiConstant.SourceUpdataInterval.NONE;
        
        private static AqiConstant.HttpType ht = AqiConstant.HttpType.GET;

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

        public override AqiConstant.HttpType HT
        {
            get { return ht; }
        }

        #endregion

    }
}
