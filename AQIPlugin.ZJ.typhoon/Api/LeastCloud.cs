using System;
using AQI;
using AQI.Abstract;

namespace typhoon.Api
{
    public class LeastCloud : ABaseSrcUrl
    {

        #region 静态变量

        private static string tag = "LeastCloud";
        private static string name = "浙江台风当前云图";
        private static string url = "http://typhoon.zjwater.gov.cn/Api/LeastCloud";
        private static AqiConstant.SourceUpdataInterval sui = AqiConstant.SourceUpdataInterval.MINUTE30;
        private static AqiConstant.HttpType httpType = AqiConstant.HttpType.GET;

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
        public override AqiConstant.SourceUpdataInterval SUI
        {
            get
            {
                return sui;
            }
        }
        public override AqiConstant.HttpType HT
        {
            get
            {
                return httpType;
            }
        }

        #endregion

    }
}
