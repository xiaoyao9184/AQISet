using System;
using System.Collections.Generic;
using System.Text;
using AQI;
using AQI.Abstract;
using AQI.Exception;
using AQI.Interface;
using AQI.Util;
using Helper.Util.HTTP;
using Newtonsoft.Json.Linq;
using ZJ.messagebroker;

namespace ZJ.Abstract
{
    /// <summary>
    /// 浙江数据接口
    ///     通用抽象类
    /// </summary>
    public abstract class ZJSrcUrl : AAmfSrcUrl, IParseSrcUrlParam
    {

        #region 变量

        private readonly ISrcUrl _paramISU = new _5();

        #endregion

        #region 属性

        /// <summary>
        /// 设置到依赖中
        /// </summary>
        public override IAqiWeb IAW
        {
            get
            {
                return iaw;
            }
            set
            {
                base.iaw = value;
                this._paramISU.IAW = value;
            }
        }

        /// <summary>
        /// 无参数
        /// </summary>
        public override List<string> ParamName
        {
            get
            {
                return null;
            }
        }

        #endregion

        #region IMakeParam接口

        /// <summary>
        /// 拼接请求体
        ///     .可以重写
        /// </summary>
        /// <remarks>
        /// DSId必须要与Cookie对应，需要通过 <see cref="_5"/> 动态获取，DSId将以字节方式替换旧的DSId
        /// </remarks>
        /// <param name="param">参数列表</param>
        /// <returns></returns>
        public override byte[] MakeRequestBody(AqiParam param)
        {
            byte[] requestbody = base.MakeRequestBody(param);
            byte[] newDSId = Encoding.ASCII.GetBytes(param["DSId"]);
            byte[] oldDSId = Encoding.ASCII.GetBytes(param["replaceDSId"]);

            while (requestbody.FindBytes(oldDSId) >= 0)
            {
                requestbody = requestbody.ReplaceBytes(oldDSId, newDSId);
            }
            
            return requestbody;
        }

        /// <summary>
        /// 拼接请求头
        ///     .可以重写
        /// </summary>
        /// <remarks>
        /// DSId必须要与Cookie对应，需要通过 _5 动态获取，Cookie加入返回，DSId加入参数
        /// </remarks>
        /// <param name="param"></param>
        /// <returns></returns>
        public override Dictionary<string, string> MakeRequestHeader(AqiParam param)
        {
            Dictionary<string, string> header = base.MakeRequestHeader(param);

            IParseSrcUrlParam ipp = this as IParseSrcUrlParam;
            AqiParam dsidAqiParam = AqiParam.CreateListFormSrcUrl(ipp, ipp.ParamSrcUrl)[0];
            param["DSId"] = dsidAqiParam["DSId"];

            HttpData data = ((ICacheData)ipp.ParamSrcUrl).Data;
            if (data.Header.ContainsKey("Set-Cookie"))
            {
                header["Cookie"] = data.Header["Set-Cookie"];
            }

            return header;
        }

        #endregion
        
        #region IParseSrcUrlParam

        public ISrcUrl ParamSrcUrl
        {
            get { return _paramISU; }
        }

        public List<AqiParam> ParseParam(byte[] data)
        {
            List<AqiParam> listParam = new List<AqiParam>();

            string json = Encoding.UTF8.GetString(data);
            JObject ja = JObject.Parse(json);
            JToken jt = ja.SelectToken("Bodies.[0].Content.headers.DSId");

            if (jt == null)
            {
                throw new DataDifferentException("与预期的数据不一致(Bodies.[0].Content.headers.DSId应有数据)，可能数据源已经发生变化");
            }
            AqiParam ap = new AqiParam("DSId");
            ap.Add("DSId", jt.ToString());

            listParam.Add(ap);
            return listParam;
        }
        
        #endregion

    }
}
