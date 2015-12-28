using AQI;
using AQI.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace hljkq.find
{
    public class findbystationcode : AParamSrcUrl
    {

        #region 静态变量

        private static string tag = "findbystationcode";
        private static string name = "黑龙站点？？";
        private static string url = "http://111.40.0.99:8081/hljkq/findbystationcode";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.HOUR;
        private static List<string> pn = new List<string>(){
            ""
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
