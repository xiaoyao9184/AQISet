using AQI;
using AQI.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace xizang.ashx
{
    public class GetCityRTData : AParamSrcUrl
    {

        #region 静态变量

        private static string tag = "GetCityRTData";
        private static string name = "西藏城市站点1小时浓度";
        private static string url = "http://111.11.241.103:9001/ashx/GetCityRTData.ashx";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.HOUR;
        private static List<string> pn = new List<string>(){
            ".type", ".cityId"
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
                return ps;
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
