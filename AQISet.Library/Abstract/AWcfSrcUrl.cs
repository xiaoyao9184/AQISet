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
    public abstract class AWcfSrcUrl : ISrcUrl, ISrcUrlParam, ICacheParam, IMakeParam, IExtractData
    {

        #region 字段

        /// <summary>
        /// IAqiWeb接口
        ///     ISrcUrl
        /// </summary>
        protected IAqiWeb iaw;

        /// <summary>
        /// 参数缓存时间戳
        ///     ICacheParam
        /// </summary>
        protected DateTime dtParamCacheTime = DateTime.MinValue;
        /// <summary>
        /// 参数缓存
        ///     ICacheParam
        /// </summary>
        protected List<AqiParam> listParamCache = new List<AqiParam>();
        /// <summary>
        /// 参数来源（默认JSON文件）
        ///     ICacheParam
        /// </summary>
        protected AqiConstant.ParamSourceType pst = AqiConstant.ParamSourceType.JSON;
        /// <summary>
        /// 参数过滤（默认不过滤）
        ///     ICacheParam
        /// </summary>
        protected AqiConstant.ParamFilterType pft = AqiConstant.ParamFilterType.NONE;

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
        /// <summary>
        /// IAqiWeb接口
        ///     实现ISrcUrl
        /// </summary>
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
        /// <summary>
        /// 更新间隔
        ///     实现ISrcUrl
        /// </summary>
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
        /// HTTP获取方式
        ///     扩展ISrcUrl
        /// </summary>
        public abstract AQI.AqiConstant.HttpType HttpType { get; }

        /// <summary>
        /// 常用更新间隔
        /// </summary>
        public abstract AQI.AqiConstant.SourceUpdataInterval SUI { get; }

        /// <summary>
        /// 参数名列表
        ///     IMakeParam
        /// </summary>
        public abstract List<string> ParamName { get; }
        /// <summary>
        /// 参数发送类型(HTTP获取方式)
        ///     IMakeParam
        /// </summary>
        public abstract AQI.AqiConstant.ParamSendType ParamSendType { get; }

        /// <summary>
        /// 参数缓存列表
        ///     ICacheParam
        /// </summary>
        public virtual List<AQI.AqiParam> ParamCache
        {
            get
            {
                return listParamCache;
            }
        }
        /// <summary>
        /// 参数来源
        ///     实现ICacheParam
        /// </summary>
        public virtual AQI.AqiConstant.ParamSourceType ParamSourceType 
        {
            get
            {
                return pst;
            }
        }
        /// <summary>
        /// 参数过滤
        ///     实现ICacheParam
        /// </summary>
        public virtual AQI.AqiConstant.ParamFilterType ParamFilterType
        {
            get
            {
                return pft;
            }
        }

        /// <summary>
        /// WCF Content Binary(WCF二进制内容)编码格式
        /// </summary>
        public abstract Helper.WCFbin.WCFMessageUtil.WCFContentFormat WCFContentFormat { get; }
        
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
        protected virtual string MakeKeyValueUrl(Dictionary<string, string> dictParam)
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

        #region ISrcUrl接口

        /// <summary>
        /// 获取内容
        ///     可以重写 
        /// </summary>
        /// <returns></returns>
        public virtual byte[] GetDate()
        {
            //得到responsebody
            byte[] responsebody = null;
            if (HttpType == AqiConstant.HttpType.POST)
            {
                responsebody = HttpUtilV2.doPostRequest(Url, null);
            }
            else
            {
                responsebody = HttpUtilV2.doGetRequest(Url);
            }

            return ExtractData(responsebody);
        }

        #endregion

        #region ISrcUrlParam接口

        /// <summary>
        /// 枚举参数
        ///     可以重写
        /// </summary>
        /// <returns></returns>
        public virtual List<AqiParam> EnumParams()
        {
            if (IsParamsExpired())
            {
                LoadParams();
            }
            return FilterParams();
        }

        /// <summary>
        /// 获取内容
        ///     可以重写
        /// </summary>
        /// <param name="param">参数列表</param>
        /// <returns></returns>
        public virtual byte[] GetDate(AqiParam param)
        {
            //得到responsebody
            byte[] responsebody = null;
            if (ParamSendType == AqiConstant.ParamSendType.POST)
            {
                byte[] requestbody = MakeRequestBody(param);
                responsebody = HttpUtilV2.doPostRequest(Url, requestbody);
            }
            else
            {
                string urlparam = MakeUrl(param);
                responsebody = HttpUtilV2.doGetRequest(urlparam);
            }

            //提取数据
            return ExtractData(responsebody);
        }

        #endregion

        #region ICacheParam接口

        /// <summary>
        /// 参数路径
        ///     可以重写
        /// </summary>
        /// <returns></returns>
        public virtual string GetJsonFile()
        {
            //JSON文件
            string exeFile = this.GetType().Assembly.Location;
            int p = exeFile.LastIndexOf('\\');
            string dllPath = exeFile.Substring(0, p);
            string jsonFile = dllPath + "\\JSON\\" + this.iaw.Tag + ".json";

            return jsonFile;
        }

        /// <summary>
        /// 检查过期
        ///     可以重写
        /// </summary>
        /// <returns>true过期；false未过期</returns>
        public virtual bool IsParamsExpired()
        {
            DateTime dtNewWriteTime = AqiParam.ReadWriteTimeFormJson(this);
            if (dtNewWriteTime > this.dtParamCacheTime)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 加载参数
        ///     可以重写
        /// </summary>
        /// <returns></returns>
        public virtual bool LoadParams()
        {
            this.listParamCache = AqiParam.CreateListFormJson(this, this.Tag, AqiParam.PARAMS);
            this.dtParamCacheTime = AqiParam.ReadWriteTimeFormJson(this);
            return true;
        }

        /// <summary>
        /// 过滤参数
        ///     可以重写
        /// </summary>
        /// <returns></returns>
        public virtual List<AqiParam> FilterParams()
        {
            return this.listParamCache;
        }

        #endregion

        #region IMakeParam接口

        /// <summary>
        /// 拼接含参数Url
        ///     可以重写
        /// </summary>
        /// <param name="param">参数列表</param>
        public virtual string MakeUrl(AqiParam param)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Url);
            sb.Append(MakeKeyValueUrl(param));
            return Uri.EscapeUriString(sb.ToString());
        }

        /// <summary>
        /// 拼接请求体
        ///     可以重写
        /// </summary>
        /// <param name="param">参数列表</param>
        /// <returns></returns>
        public virtual byte[] MakeRequestBody(AqiParam param)
        {
            string wcfmessage = MakeWCFMsg(param);

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
            byte[] wcfbin = WCFMessageUtil.getWCFBinByWCFMsg(strWCFMsg, Tag, WCFContentFormat);

            return wcfbin;
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
