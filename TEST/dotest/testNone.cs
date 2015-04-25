using System;
using AQI.Abstract;
using AQI.Interface;

namespace TEST.dotest
{
    public class testNone : ABaseSrcUrl
    {

        #region 静态变量

        private static string Tag = "testNone";
        private static string Name = "不存在";
        private static string Url = "http://127.0.0.1/test";
        private static AQI.AqiConstant.SourceUpdataInterval Sui = AQI.AqiConstant.SourceUpdataInterval.MINUTE30;

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
