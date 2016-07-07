using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AQI;
using AQI.Abstract;
using AQI.Exception;
using AQI.Interface;
using AQI.Util;
using Helper.Util.HTTP;
using semc.messagebroker;
using Newtonsoft.Json.Linq;

namespace semc.Abstract
{
    /// <summary>
    /// 上海数据接口
    ///     通用抽象类
    /// </summary>
    public abstract class semcSrcUrl : AAmfSrcUrl, IParseSrcUrlParam
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

        #region ICacheParam接口

        /// <summary>
        /// 检查过期
        ///     可以重写
        /// </summary>
        /// <remarks>
        /// 判断是否需要重新设置Cookie
        /// </remarks>
        /// <returns>true过期；false未过期</returns>
        public override bool IsParamsExpired()
        {
            if (ParamCache == null || ParamCache.Count == 0)
            {
                return true;
            }
            IParseSrcUrlParam ipp = this as IParseSrcUrlParam;
            AqiParam.CreateListFormSrcUrl(ipp, ipp.ParamSrcUrl);

            HttpData data = ((ICacheData)ipp.ParamSrcUrl).Data;
            if (data.Header.ContainsKey("Set-Cookie"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 加载参数
        ///     可以重写
        /// </summary>
        /// <remarks>
        /// 获取DSId与Cookie
        /// </remarks>
        /// <returns></returns>
        public override bool LoadParams()
        {
            bool result = base.LoadParams();

            if (result)
            {
                IParseSrcUrlParam ipp = this as IParseSrcUrlParam;
                AqiParam dsidAqiParam = AqiParam.CreateListFormSrcUrl(ipp, ipp.ParamSrcUrl)[0];
                HttpData data = ((ICacheData)ipp.ParamSrcUrl).Data;

                foreach (AqiParam param in ParamCache)
                {
                    param["DSId"] = dsidAqiParam["DSId"];
                    if(data.Header.ContainsKey("Set-Cookie"))
                    {
                        param.Header["Cookie"] = data.Header["Set-Cookie"];
                    }
                }
            }

            return result;          
        }

        #endregion

        #region IMakeParam接口

        /// <summary>
        /// 拼接请求体
        ///     .可以重写
        /// </summary>
        /// <remarks>
        /// DSId必须要与Cookie对应，需要通过 <see cref="_5"/> 动态获取，DSId将以字节方式替换旧的DSId；替换cityCode
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

            if (param.ContainsKey("stationCode"))
            {
                byte[] newCode1 = Encoding.ASCII.GetBytes(param["cityCode"]);
                byte[] newCode2 = Encoding.ASCII.GetBytes(param["stationCode"]);
                byte[] newCode = new byte[newCode1.Length + newCode2.Length + 2];
                Array.Copy(newCode1,newCode,newCode1.Length);
                Array.Copy(newCode2, 0, newCode, newCode1.Length+2, newCode2.Length);
                newCode[newCode1.Length] = 0x06;
                newCode[newCode1.Length+1] = 0x05;
                byte[] oldCode1 = Encoding.ASCII.GetBytes(param["replaceCityCode"]);
                byte[] oldCode2 = Encoding.ASCII.GetBytes("01");
                byte[] oldCode = new byte[oldCode1.Length + oldCode2.Length + 2];
                Array.Copy(oldCode1, oldCode, oldCode1.Length);
                Array.Copy(newCode2, 0, oldCode, oldCode1.Length + 2, oldCode2.Length);
                newCode[oldCode1.Length] = 0x06;
                newCode[oldCode1.Length + 1] = 0x05;
                requestbody = requestbody.ReplaceBytes(oldCode, newCode);
            }
            else if (param.ContainsKey("cityCode"))
            {
                byte[] newCode = Encoding.ASCII.GetBytes(param["cityCode"]);
                byte[] oldCode = Encoding.ASCII.GetBytes(param["replaceCityCode"]);
                requestbody = requestbody.ReplaceBytes(oldCode, newCode);
            }
            else if (param.ContainsKey("pollutantCode"))
            {
                byte[] arrOutput = { 0x09, 0x03, 0x01, 0x06, 0x03, 0x38, 0x01 };
                byte[] arrOutput2 = { 0x09, 0x03, 0x01, 0x06, 0x03, 0x38, 0x01 };
                arrOutput2[5] = (byte)param["pollutantCode"].ElementAt(0); 
                requestbody = requestbody.ReplaceBytes(arrOutput, arrOutput2);
            }

            return requestbody;
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
