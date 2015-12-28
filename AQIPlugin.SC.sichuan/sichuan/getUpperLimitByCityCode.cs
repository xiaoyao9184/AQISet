using AQI;
using AQI.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace sichuan.publish
{
    public class getUpperLimitByCityCode : AParamSrcUrl
    {

        #region 静态变量

        private static string tag = "getUpperLimitByCityCode";
        private static string name = "四川城市信息";
        private static string url = "http://221.237.179.45:5100/publish/getUpperLimitByCityCode";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.NONE;
        private static List<string> pn = new List<string>(){
            ".cityCode"
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
