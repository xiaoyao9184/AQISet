using System;
using System.Collections.Generic;
using AQI;
using AQI.Abstract;

namespace sichuan.smartadmin.forecast
{
    // TODO 参数应该自动生成
    public class getCityAuditResult : AParamSrcUrl
    {

        #region 静态变量

        private static string tag = "getCityAuditResult";
        private static string name = "四川城市预报";
        private static string url = "http://www.scnewair.cn:3389/smartadmin/forecast/getCityAuditResult";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.NONE;
        private static List<string> pn = new List<string>(){
            "timePoint"
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
