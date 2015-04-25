using System;
using AQI.Abstract;
using AQI.Interface;
using Helper.Util.HTTP;
using System.Net;

namespace TEST.dotest
{
    public class testTimeout : ABaseSrcUrl
    {

        #region 静态变量

        private static string Tag = "testTimeout";
        private static string Name = "超时";
        private static string Url = "http://www.baidu.com";
        private static AQI.AqiConstant.SourceUpdataInterval Sui = AQI.AqiConstant.SourceUpdataInterval.MINUTE;

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

        #region 方法

        /// <summary>
        /// 超时测试
        /// </summary>
        /// <returns></returns>
        public override byte[] getDate()
        {
            //得到responsebody
            
            HttpWebResponse res = HttpUtilV2.createGetResponse(URL,10);

            byte[] bResponseBody = HttpUtilV2.getResponseBody(res);
            return bResponseBody;
        }

        #endregion

    }
}
