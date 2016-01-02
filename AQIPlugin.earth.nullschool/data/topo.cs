using AQI;
using AQI.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace earth.data
{
    public class topo : AParamSrcUrl
    {

        #region 静态变量

        private static string tag = "topo";
        private static string name = "nullschool的全球风图topo";
        private static string url = "http://earth.nullschool.net/data/earth-topo.json";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.HOUR;
        private static List<string> ParamsList = new List<string>(){
            ".v3",
        };
        private static new AqiConstant.ParamSendType pst = AqiConstant.ParamSendType.GET;
        private static new AqiConstant.ParamUrlType put = AqiConstant.ParamUrlType.KEY_VALUE;

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
                return ParamsList;
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
        public override AqiConstant.ParamFilterType ParamFilterType
        {
            get
            {
                return pft;
            }
        }

        #endregion

    }
}
