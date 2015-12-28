using AQI;
using AQI.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace YNAS.realDataAction
{
    public class queryCTDetail_HISTORY : AParamSrcUrl
    {

        #region 静态变量

        private static string tag = "queryCTDetail_HISTORY";
        private static string name = "云南站点1小时污染物历史(1天内)";
        private static string url = "http://61.166.240.109:6013/YNAS/realDataAction!queryCTDetail";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.DAY;
        private static List<string> pn = new List<string>(){
            ".fact_code", ".stat_code"
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
