using ZJ.Abstract;

namespace ZJ.messagebroker
{
    public class getHourlyDataForAllSites : ZJSrcUrl
    {

        #region 静态变量

        private static string tag = "getHourlyDataForAllSites";
        private static string name = "站点1小时AQI&浓度_站点24小时历史AQI";
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
