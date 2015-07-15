using System;
using AQI.Abstract;
using tjemc.Abstract;

namespace tjemc.handler
{
    public class Warning : tjemcSrcUrl
    {

        #region 静态变量

        private static string tag = "Warning";
        private static string name = "天津市24小时污染物警告";
        private static string url = "http://air.tjemc.org.cn/handler/Warning.ashx";
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
