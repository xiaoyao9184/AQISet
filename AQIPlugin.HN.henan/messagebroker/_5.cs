using System.Collections.Generic;
using AQI;
using AQI.Abstract;
using AQI.Interface;
using Helper.Util.HTTP;

namespace henan.messagebroker
{
    public class _5 : AAmfSrcUrl, ICacheData
    {

        #region 静态变量

        private static string tag = "_5";
        private static string name = "DSId请求";
        private static string url = "http://222.143.24.250:100/airgis_dp/messagebroker/amf";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.NONE;

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
            get
            {
                return null;
            }
        }

        #endregion

        #region ICacheData

        public HttpData Data { get; set; }

        #endregion

    }
}
