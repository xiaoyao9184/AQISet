using AQI;
using AQI.Abstract;
using Helper.Util.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace SD.Abstract
{
    public abstract class AirQuality_POST : AParamSrcUrl
    {

        //#region 属性

        //public abstract string Tag { get; }
        //public abstract string Name { get; }
        //public abstract string Url { get; }
        //public abstract AqiConstant.SourceUpdataInterval SUI { get; }
        //public abstract List<string> ParamName { get; }
        //public abstract AqiConstant.ParamSendType ParamSendType { get; }
        //public abstract AqiConstant.ParamUrlType ParamUrlType { get; }

        //#endregion

        #region 重写方法

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public override byte[] GetData(AqiParam param)
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
                    HttpWebResponse res = HttpUtilV2.createPostResponse(Url, 10000, "application/x-www-form-urlencoded; charset=UTF-8", requestbody);
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
