using AQI;
using jsair.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jsair.JSAQPPSERVICES
{
    public class StationPM10Now : jsairSrcUrl
    {

        #region 静态变量

        private static string tag = "StationPM10Now";
        private static string name = "江苏所有站点1小时PM10";
        private static string url = "http://218.94.78.75:20001/JSAQPPSERVICES/REST/V100/STATION/{0}/PM10/NOW?token={1}";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.HOUR;
        private static List<string> pn = new List<string>(){
            "area"
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

        #endregion

    }
}
