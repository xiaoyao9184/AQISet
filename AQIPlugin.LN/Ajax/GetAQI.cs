using System;
using System.Collections.Generic;
using AQI;
using AQI.Abstract;
using AQI.Interface;

namespace LN.Ajax
{
    public class GetAQI : AParamSrcUrl
    {

        #region 静态变量

        private static string tag = "GetAQI";
        private static string name = "站点24小时AQI";
        private static string url = "http://211.137.19.74:8089/Ajax/GetAQI";
        private static AQI.AqiConstant.SourceUpdataInterval sui = AQI.AqiConstant.SourceUpdataInterval.HOUR;
        private static List<string> pn = new List<string>(){
            "stationCode"
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
            get { return pn; }
        }

        public override AqiConstant.ParamSendType ParamSendType
        {
            get { return ps; }
        }

        #endregion

    }
}
