using System;
using System.Net;
using Helper.Util.HTTP;
using AQI.Abstract;

namespace tjemc.Abstract
{
    /// 天津数据接口
    ///     通用抽象类
    /// </summary>
    public abstract class tjemcSrcUrl : ABaseSrcUrl
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

        #region 重写方法

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public override byte[] GetDate()
        {
            HttpWebRequest req = HttpUtilV2.createPostRequest(Url);
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
