using System.Collections.Generic;
using AQI.Abstract;
using AQI.Interface;
using Helper.Util.HTTP;

namespace ZJ.messagebroker
{
    public class _5 : AAmfSrcUrl, ICacheData
    {

        #region 静态变量

        private static string tag = "_5";
        private static string name = "??";
        private static string url = "http://218.108.43.220:8099/aqi/messagebroker/amf";
        private static AQI.AqiConstant.SourceUpdataInterval sui = AQI.AqiConstant.SourceUpdataInterval.NONE;

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
