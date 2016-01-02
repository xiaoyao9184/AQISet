using ZJ.Abstract;

namespace ZJ.messagebroker
{
    public class getAreaUsedToRealTime : ZJSrcUrl
    {

        #region 静态变量

        private static string tag = "getAreaUsedToRealTime";
        private static string name = "城市1小时列表";
        private static string url = "http://218.108.43.220:8099/aqi/messagebroker/amf";
        private static AQI.AqiConstant.SourceUpdataInterval sui = AQI.AqiConstant.SourceUpdataInterval.HOUR;

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

        #endregion

    }
}
