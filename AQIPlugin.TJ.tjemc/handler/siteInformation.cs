using System;
using AQI.Abstract;
using tjemc.Abstract;

namespace tjemc.handler
{
    public class siteInformation : tjemcSrcUrl
    {

        #region 静态变量

        private static string tag = "siteInformation";
        private static string name = "天津市1小时AQI";
        private static string url = "http://air.tjemc.org.cn/handler/siteInformation.ashx";
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
