using System;
using AQI.Abstract;
using AQI.Interface;

namespace TEST.dotest
{
    public class testNone : ABaseSrcUrl
    {

        #region 静态变量

        private static string tag = "testNone";
        private static string name = "不存在";
        private static string url = "http://127.0.0.1/test";
        private static AQI.AqiConstant.SourceUpdataInterval sui = AQI.AqiConstant.SourceUpdataInterval.MINUTE30;

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
        /// <summary>
        /// 使用GET方式
        /// </summary>
        public override AQI.AqiConstant.HttpType HT
        {
            get
            {
                return AQI.AqiConstant.HttpType.POST;
            }
        }

        #endregion

    }
}
