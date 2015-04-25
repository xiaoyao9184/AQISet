using System;
using System.Net;
using AQI.Abstract;
using Helper.Util.HTTP;

namespace TJ.Abstract
{
    /// <summary>
    /// 天津数据接口
    ///     通用抽象类
    /// </summary>
    public abstract class TJSrcUrl : ABaseSrcUrl
    {

        #region 属性

        /// <summary>
        /// 使用POST方式
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

        public override byte[] getDate()
        {
            HttpWebRequest req = HttpUtilV2.createPostRequest(URL);
            req.Timeout = 10000;
            req.ContentLength = 0;
            req.ContentType = "text/plain;charset=UTF-8";
            req.Headers["X-Requested-With"] = "XMLHttpRequest";

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            byte[] bResponseBody = HttpUtilV2.getResponseBody(res);
            return bResponseBody;
        }

        #endregion

    }
}
