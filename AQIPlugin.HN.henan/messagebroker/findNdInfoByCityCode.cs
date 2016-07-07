using henan.Abstract;

namespace henan.messagebroker
{
    public class findNdInfoByCityCode : henanSrcUrl
    {

        #region 静态变量

        private static string tag = "findNdInfoByCityCode";
        private static string name = "城市站点1小时浓度";
        private static string url = "http://222.143.24.250:100/airgis_dp/messagebroker/amf";
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
