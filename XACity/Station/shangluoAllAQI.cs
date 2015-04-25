using System;
using AQI.Abstract;
using SX.Abstract;

namespace SX.Station
{
    public class shangluoAllAQI : SXSrcUrl
    {

        #region 静态变量

        private static string Tag = "shangluoAllAQI";
        private static string Name = "商洛市站点24小时AQI";
        private static string Url = "http://113.140.66.226:8024/sxAQIWeb/swfPage/shangluoAllAQI.xml";
        private static AQI.AqiConstant.SourceUpdataInterval Sui = AQI.AqiConstant.SourceUpdataInterval.DAY;

        #endregion

        #region 属性

        public override string TAG
        {
            get
            {
                return Tag;
            }
        }
        public override string NAME
        {
            get
            {
                return Name;
            }
        }
        public override string URL
        {
            get
            {
                return Url;
            }
        }
        public override AQI.AqiConstant.SourceUpdataInterval SUI
        {
            get
            {
                return Sui;
            }
        }

        #endregion

    }
}
