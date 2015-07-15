using System;
using System.Net;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using Helper.Util.HTTP;
using Helper.WCFbin;
using AQI.Interface;

namespace AQI.Abstract
{
    /// <summary>
    /// WCF数据接口
    ///     抽象类
    /// </summary>
    public abstract class AWcfSrcUrl : ISrcUrl, IMakeParam , IExtractData
    {

        #region 字段

        /// <summary>
        /// IAqiWeb接口
        /// </summary>
        protected IAqiWeb iaw;
        /// <summary>
        /// 参数缓存
        /// </summary>
        protected List<AqiParam> listParamCache;
        /// <summary>
        /// 参数时间戳
        /// </summary>
        protected DateTime dtParamLastTime = DateTime.MinValue;
        /// <summary>
        /// WCF HTTP传输
        /// </summary>
        protected WCFMessageHelper mh;

        #endregion

        #region 属性

        public abstract string Tag { get; }
        public abstract string Name { get; }
        public abstract string Url { get; }
        public abstract bool UseParam { get; }

        public virtual IAqiWeb IAW
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
        public virtual double UDI
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
        /// 参数发送类型(HTTP获取方式)
        /// </summary>
        public abstract AQI.AqiConstant.ParamSendType ParamSendType { get; }
        /// <summary>
        /// 参数名列表
        /// </summary>
        public abstract List<string> ParamName { get; }
        /// <summary>
        /// 参数列表
        /// </summary>
        public virtual List<AQI.AqiParam> P
        {
            get
            {
                return listParamCache;
            }
        }

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

        #region 内部方法

        /// <summary>
        /// 拼接Url参数：值对
        /// </summary>
        /// <param name="dictParam"></param>
        /// <returns></returns>
        protected virtual string MakeKeyValueurl(Dictionary<string, string> dictParam)
        {
            StringBuilder sb = new StringBuilder();
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

        #endregion

        #region IMakeParam接口

        /// <summary>
        /// 加载参数
        ///     可以重写
        /// </summary>
        /// <returns></returns>
        public virtual List<AqiParam> EnumParams()
        {
            //过期判断：文件时间
            DateTime dtNewWriteTime = AqiParam.ReadWriteTimeFormJson(this);
            if (dtNewWriteTime > dtParamLastTime)
            {
                //文件更新
                listParamCache = AqiParam.CreateListFormJson(this, AqiParam.PARAMS);
            }

            return listParamCache;
        }

        /// <summary>
        /// 拼接含参数Url
        ///     可以重写
        /// </summary>
        /// <param name="dictParam">参数列表</param>
        public virtual string MakeUrl(Dictionary<string, string> dictParam)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Url);
            sb.Append(MakeKeyValueurl(dictParam));
            return Uri.EscapeUriString(sb.ToString());
        }

        /// <summary>
        /// 拼接请求体
        ///     可以重写
        /// </summary>
        /// <param name="dictParam">参数列表</param>
        /// <returns></returns>
        public virtual byte[] MakeRequestBody(Dictionary<string, string> dictParam)
        {
            string wcfmessage = MakeWCFMsg(dictParam);

            byte[] requestBody = mh.GetWcfBinaryMessageAsBinary(wcfmessage);

            return requestBody;
        }

        #endregion

        #region IExtractData接口

        /// <summary>
        /// 数据提取
        ///     可以重写
        /// </summary>
        /// <see cref="getData"/>
        /// <param name="requestbody"></param>
        /// <returns></returns>
        public virtual byte[] ExtractData(byte[] responsebody)
        {
            //获取WCF Message
            string strWCFMsg = mh.GetWcfBinaryMessageAsText(responsebody);

            //获取WCF Content Binary（=WCF Message Body）
            byte[] wcfbin = WCFMessageUtil.getWCFBinByWCFMsg(strWCFMsg, Tag, CF);

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
        public virtual byte[] GetDate(Dictionary<string, string> dictParam)
        {
            //得到responsebody
            byte[] responsebody = null;
            if (ParamSendType == AqiConstant.ParamSendType.POST)
            {
                byte[] requestbody = MakeRequestBody(dictParam);
                responsebody = HttpUtilV2.doPostRequest(Url, requestbody);
            }
            else
            {
                string urlparam = MakeUrl(dictParam);
                responsebody = HttpUtilV2.doGetRequest(urlparam);
            }

            //提取数据
            return ExtractData(responsebody);
        }

        /// <summary>
        /// 获取内容
        ///     可以重写 
        /// </summary>
        /// <returns></returns>
        public virtual byte[] GetDate()
        {
            //得到responsebody
            byte[] responsebody = null;
            if(ParamSendType == AqiConstant.ParamSendType.POST)
            {
                responsebody = HttpUtilV2.doPostRequest(Url, null);
            }
            else
            {
                responsebody = HttpUtilV2.doGetRequest(Url);
            }

            //提取数据
            return ExtractData(responsebody);
        }

        #endregion

        #region WCF数据接口 通用方法

        /// <summary>
        /// 拼接WCFMessage
        ///     必须重写
        /// </summary>
        /// <see cref="MakeRequestBody"/>
        /// <param name="dict">参数列表</param>
        /// <returns></returns>
        public abstract string MakeWCFMsg(Dictionary<string, string> dictParam);

        #endregion

        #endregion

    }
}
