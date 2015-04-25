using System;
using AQI.Interface;
using Helper.WCFbin;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using Helper.Util.HTTP;
using System.Net;

namespace AQI.Abstract
{
    /// <summary>
    /// WCF数据接口
    ///     抽象类
    /// </summary>
    public abstract class AWcfSrcUrl : ISrcUrl, IMakeParam , IExtractData
    {

        #region 字段

        private IAqiWeb iaw;

        protected WCFMessageHelper mh;   //WCF HTTP传输

        #endregion

        #region 属性

        public abstract string TAG { get; }
        public abstract string NAME { get; }
        public abstract string URL { get; }
        public abstract bool USEPARAM { get; }
        
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
        public double UDI
        {
            get
            {
                switch (SUI)
                {
                    case AqiConstant.SourceUpdataInterval.DAY7:
                        return AqiConstant.DAY7;
                    case AqiConstant.SourceUpdataInterval.DAY:
                        return AqiConstant.DAY;
                    case AqiConstant.SourceUpdataInterval.HOUR12:
                        return AqiConstant.HOUR12;
                    case AqiConstant.SourceUpdataInterval.HOUR:
                        return AqiConstant.HOUR;
                    case AqiConstant.SourceUpdataInterval.MINUTE30:
                        return AqiConstant.MINUTE30;
                    case AqiConstant.SourceUpdataInterval.MINUTE:
                        return AqiConstant.MINUTE;
                    default:
                        return -1;
                }
            }
        }

        /// <summary>
        /// 常用更新间隔
        /// </summary>
        public abstract AQI.AqiConstant.SourceUpdataInterval SUI { get; }
        /// <summary>
        /// 参数承载类型(HTTP获取方式)
        /// </summary>
        public abstract AQI.AqiConstant.ParamType PT { get; }
        /// <summary>
        /// 参数名列表
        /// </summary>
        public abstract List<string> PL { get; }
        /// <summary>
        /// WCF Content Binary(WCF二进制内容)编码格式
        /// </summary>
        public abstract Helper.WCFbin.WCFMessageUtil.WCFContentFormat CF { get; }
        
        #endregion

        public AWcfSrcUrl()
        {
            this.mh = new WCFMessageHelper();
        }

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
            string wcfmessage = makeWCFMsg(dictParam);

            byte[] requestBody = mh.GetWcfBinaryMessageAsBinary(wcfmessage);

            return requestBody;
        }

        #endregion

        #region IExtract接口

        /// <summary>
        /// 数据提取
        ///     可以重写
        /// </summary>
        /// <see cref="getData"/>
        /// <param name="requestbody"></param>
        /// <returns></returns>
        public virtual byte[] extractData(byte[] responsebody)
        {
            //获取WCF Message
            string strWCFMsg = mh.GetWcfBinaryMessageAsText(responsebody);

            //获取WCF Content Binary（=WCF Message Body）
            byte[] wcfbin = WCFMessageUtil.getWCFBinByWCFMsg(strWCFMsg, TAG, CF);

            return wcfbin;
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
            if (PT == AqiConstant.ParamType.POST)
            {
                byte[] requestbody = makeRequestBody(dictParam);
                responsebody = HttpUtilV2.doPostRequest(URL, requestbody);
            }
            else
            {
                string urlparam = makeUrl(dictParam);
                responsebody = HttpUtilV2.doGetRequest(urlparam);
            }

            //提取数据
            return extractData(responsebody);
        }

        /// <summary>
        /// 获取内容
        ///     可以重写 
        /// </summary>
        /// <returns></returns>
        public virtual byte[] getDate()
        {
            //得到responsebody
            byte[] responsebody = null;
            if(PT == AqiConstant.ParamType.POST)
            {
                responsebody = HttpUtilV2.doPostRequest(URL, null);
            }
            else
            {
                responsebody = HttpUtilV2.doGetRequest(URL);
            }

            //提取数据
            return extractData(responsebody);
        }

        #endregion

        #region WCF数据接口 通用方法

        /// <summary>
        /// 拼接WCFMessage
        ///     必须重写
        /// </summary>
        /// <see cref="makeRequestBody"/>
        /// <param name="dict">参数列表</param>
        /// <returns></returns>
        public abstract string makeWCFMsg(Dictionary<string, string> dictParam);

        #endregion

        #endregion

    }
}
