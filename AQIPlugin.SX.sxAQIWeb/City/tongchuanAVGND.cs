using System;
using AQI.Abstract;
using sxAQIWeb.Abstract;

namespace sxAQIWeb.City
{
    public class tongchuanAVGND : sxAQIWebSrcUrl
    {

        #region 静态变量

        private static string tag = "tongchuanAVGND";
        private static string name = "铜川市24小时浓度";
        private static string url = "http://113.140.66.226:8024/sxAQIWeb/swfPage/tongchuanAVGND.xml";
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
