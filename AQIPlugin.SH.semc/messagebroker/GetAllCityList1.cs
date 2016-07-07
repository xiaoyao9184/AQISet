using semc.Abstract;

namespace semc.messagebroker
{
    public class GetAllCityList1 : semcSrcUrl
    {

        #region 静态变量

        private static string tag = "GetAllCityList1";
        private static string name = "城市24小时历史AQI?";
        private static string url = "http://www.semc.gov.cn/aqi/Gateway.aspx";
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
