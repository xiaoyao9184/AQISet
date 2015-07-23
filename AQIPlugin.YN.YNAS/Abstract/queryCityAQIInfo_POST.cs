using AQI;
using AQI.Abstract;
using Helper.Util.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace YNAS.Abstract
{
    public abstract class queryCityAQIInfo_POST : AParamSrcUrl
    {

        #region 重写方法

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public override byte[] GetDate(AqiParam param)
        {
            //得到responsebody
            byte[] responsebody = null;
            switch (ParamSendType)
            {
                case AqiConstant.ParamSendType.GET:
                    string urlparam = MakeUrl(param);
                    responsebody = HttpUtilV2.doGetRequest(urlparam);
                    break;
                case AqiConstant.ParamSendType.POST:
                    byte[] requestbody = MakeRequestBody(param);
                    //需要设置ContentType才可
                    HttpWebResponse res = HttpUtilV2.createPostResponse(Url, -1, "application/x-www-form-urlencoded; charset=UTF-8", requestbody);
                    responsebody = HttpUtilV2.getResponseBody(res);
                    break;
                default:
                    responsebody = HttpUtilV2.doGetRequest(Url);
                    break;
            }

            return responsebody;
        }

        #endregion

    }
}
