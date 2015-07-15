using System;
using AQI.Abstract;
using tjemc.Abstract;

namespace tjemc.handler
{
    public class systemSetting : tjemcSrcUrl
    {

        #region 静态变量

        private static string tag = "systemSetting";
        private static string name = "天津市界面设置";
        private static string url = "http://air.tjemc.org.cn/handler/systemSetting.ashx";
        private static AQI.AqiConstant.SourceUpdataInterval sui = AQI.AqiConstant.SourceUpdataInterval.NONE;

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
