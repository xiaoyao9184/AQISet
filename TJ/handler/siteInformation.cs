using System;
using AQI.Abstract;
using TJ.Abstract;

namespace TJ.handler
{
    public class siteInformation : TJSrcUrl
    {

        #region 静态变量

        private static string Tag = "siteInformation";
        private static string Name = "天津市1小时AQI";
        private static string Url = "http://air.tjemc.org.cn/handler/siteInformation.ashx";
        private static AQI.AqiConstant.SourceUpdataInterval Sui = AQI.AqiConstant.SourceUpdataInterval.HOUR;

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
