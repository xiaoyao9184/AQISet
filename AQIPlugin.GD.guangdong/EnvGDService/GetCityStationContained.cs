using System;
using System.Collections.Generic;
using System.Text;
using AQI;
using AQI.Abstract;
using guangdong.Abstract;

namespace guangdong.EnvGDService
{
    public class GetCityStationContained : guangdongSrcUrl
    {

        #region 静态变量

        private static string tag = "GetCityStationContained";
        private static string name = "广东城市站点列表";
        private static string url = "http://113.108.142.147:20011/GDPublishWCF/EnvGDService.svc";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.NONE;
        private static List<string> pn = new List<string>(){
            "Param."
        };
        private static AqiConstant.ParamSendType ps = AqiConstant.ParamSendType.POST;

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

        #endregion

    }
}
