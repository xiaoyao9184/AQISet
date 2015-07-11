using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using AQI.Interface;
using Helper.Util.HTTP;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AQI.Abstract
{
    /// <summary>
    /// 高级数据接口
    ///     抽象类
    /// </summary>
    public abstract class AAdvSrcUrl : ISrcUrl, IMakeParam, IExtractData
    {

        #region 字段

        private IAqiWeb iaw;

        #endregion

        #region 属性

        public abstract string TAG{ get; }
        public abstract string NAME { get; }
        public abstract string URL { get; }
        public IAqiWeb IAW
        {
            get
            {
                return iaw;
            }
            set
            {
                iaw = value;
            }
        }
        public abstract double UDI { get; }
        public abstract bool USEPARAM { get; }
        
        /// <summary>
        /// HTTP获取方式
        /// </summary>
        public abstract AQI.AqiConstant.HttpType HT { get; }
        /// <summary>
        /// 参数承载类型(HTTP获取方式)
        /// </summary>
        public abstract AQI.AqiConstant.ParamType PT { get; }
        /// <summary>
        /// 参数名列表
        /// </summary>
        public abstract List<string> PL { get; }

        #endregion

        #region 方法

        #region IParam接口

        /// <summary>
        /// 枚举参数
        ///     可以重写
        /// </summary>
        /// <returns></returns>
        public virtual List<AqiParam> enumParams()
        {
            List<AqiParam> apList = AqiParam.CreateListFormJson(this, AqiParam.PARAMS);

            return apList;
        }

        /// <summary>
        /// 拼接含参数URL
        ///     可以重写
        /// </summary>
        /// <param name="dictParam">参数列表</param>
        public virtual string makeUrl(Dictionary<string, string> dictParam)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(URL);
            sb.Append("?");
            foreach (KeyValuePair<string, string> kv in dictParam)
            {
                sb.Append(kv.Key);
                if (String.IsNullOrEmpty(kv.Key) || String.IsNullOrEmpty(kv.Value))
                {

                }
                else
                {
                    sb.Append("=");
                }
                sb.Append(kv.Value);
                sb.Append("&");
            }

            string str = sb.ToString(0, sb.Length - 1);
            return Uri.EscapeUriString(str);
        }

        /// <summary>
        /// 拼接请求体
        ///     可以重写
        /// </summary>
        /// <param name="dictParam">参数列表</param>
        /// <returns></returns>
        public virtual byte[] makeRequestBody(Dictionary<string, string> dictParam)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in dictParam)
            {
                sb.Append(kv.Key);
                if (kv.Value != null)
                {
                    sb.Append("=");
                    sb.Append(kv.Value);
                }
                sb.Append("&");
            }

            string str = sb.ToString(0, sb.Length - 1);

            return Encoding.UTF8.GetBytes(str);
        }

        #endregion

        #region IExtract接口

        /// <summary>
        /// 数据提取
        ///     可以重写
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public virtual byte[] extractData(byte[] data)
        {
            return data;
        }

        #endregion

        #region ISrcUrl接口

        /// <summary>
        /// 获取内容
        ///     可以重写
        /// </summary>
        /// <param name="dictParam">参数列表</param>
        /// <returns></returns>
        public virtual byte[] getDate(Dictionary<string, string> dictParam)
        {
            //得到responsebody
            byte[] responsebody = null;
            switch (PT)
            {
                case AqiConstant.ParamType.GET:
                    string urlparam = makeUrl(dictParam);
                    responsebody = HttpUtilV2.doGetRequest(urlparam);
                    break;
                case AqiConstant.ParamType.POST:
                    byte[] requestbody = makeRequestBody(dictParam);
                    responsebody = HttpUtilV2.doPostRequest(URL, requestbody);
                    break;
                default:
                    responsebody = HttpUtilV2.doGetRequest(URL);
                    break;
            }

            return extractData(responsebody);
        }

        /// <summary>
        /// 获取内容
        ///     可以重写
        /// </summary>
        /// <returns></returns>
        public byte[] getDate()
        {
            //得到responsebody
            byte[] responsebody = null;
            if (HT == AqiConstant.HttpType.POST)
            {
                responsebody = HttpUtilV2.doPostRequest(URL, null);
            }
            else
            {
                responsebody = HttpUtilV2.doGetRequest(URL);
            }

            return extractData(responsebody);
        }

        #endregion

        #endregion

    }
}
