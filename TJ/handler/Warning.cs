using System;
using AQI.Abstract;
using TJ.Abstract;

namespace TJ.handler
{
    public class Warning : TJSrcUrl
    {

        #region 静态变量

        private static string Tag = "Warning";
        private static string Name = "天津市24小时污染物警告";
        private static string Url = "http://air.tjemc.org.cn/handler/Warning.ashx";
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
