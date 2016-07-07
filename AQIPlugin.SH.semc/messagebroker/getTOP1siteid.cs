using semc.Abstract;

namespace semc.messagebroker
{
    public class getTOP1siteid : semcSrcUrl
    {

        #region 静态变量

        private static string tag = "getTOP1siteid";
        private static string name = "站点1小时最大AQI站点";
        private static string url = "http://www.semc.gov.cn/aqi/Gateway.aspx";
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
