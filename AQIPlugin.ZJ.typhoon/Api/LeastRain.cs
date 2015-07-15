using System;
using System.Collections.Generic;
using AQI;
using AQI.Abstract;

namespace typhoon.Api
{
    public class LeastRain : AParamSrcUrl
    {

        #region 静态变量

        private static string tag = "LeastRain";
        private static string name = "浙江台风当前雨图";
        private static string url = "http://typhoon.zjwater.gov.cn/Api/LeastRain";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.HOUR;
        private static List<string> pn = new List<string>(){
            ""
        };
        private static new AqiConstant.ParamSendType pst = AqiConstant.ParamSendType.GET;
        private static new AqiConstant.ParamUrlType put = AqiConstant.ParamUrlType.PATH;

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

    }
}
