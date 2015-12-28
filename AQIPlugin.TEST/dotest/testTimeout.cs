using System;
using System.Net;
using Helper.Util.HTTP;
using AQI.Interface;
using AQI.Abstract;

namespace TEST.dotest
{
    public class testTimeout : ABaseSrcUrl
    {

        #region 静态变量

        private static string tag = "testTimeout";
        private static string name = "超时";
        private static string url = "http://www.baidu.com";
        private static AQI.AqiConstant.SourceUpdataInterval sui = AQI.AqiConstant.SourceUpdataInterval.MINUTE;

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

        #region 方法

        /// <summary>
        /// 超时测试
        /// </summary>
        /// <returns></returns>
        public override byte[] GetData()
        {
            //得到responsebody
            
            HttpWebResponse res = HttpUtilV2.createGetResponse(Url,10);

            byte[] bResponseBody = HttpUtilV2.getResponseBody(res);
            return bResponseBody;
        }

        #endregion

    }
}
