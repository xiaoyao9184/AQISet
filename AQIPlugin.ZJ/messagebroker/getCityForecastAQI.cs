using ZJ.Abstract;

namespace ZJ.messagebroker
{
    public class getCityForecastAQI : ZJSrcUrl
    {

        #region 静态变量

        private static string tag = "getCityForecastAQI";
        private static string name = "城市3天预报";
        private static string url = "http://218.108.43.220:8099/aqi/messagebroker/amf";
        private static AQI.AqiConstant.SourceUpdataInterval sui = AQI.AqiConstant.SourceUpdataInterval.DAY;

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
