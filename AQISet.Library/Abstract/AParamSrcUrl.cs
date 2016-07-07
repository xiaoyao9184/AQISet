using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Helper.Util.HTTP;
using AQI.Interface;
using AQI.Exception;

namespace AQI.Abstract
{
    /// <summary>
    /// 带参数的数据接口
    ///     抽象类
    /// </summary>
    public abstract class AParamSrcUrl : ISrcUrl, ISrcUrlParam, ICacheParam, IMakeParam
    {

        #region 字段

        /// <summary>
        /// IAqiWeb接口
        ///     .ISrcUrl使用
        /// </summary>
        protected IAqiWeb iaw;

        /// <summary>
        /// 参数缓存时间戳
        ///     .ICacheParam使用
        /// </summary>
        protected DateTime dtParamCacheTime = DateTime.MinValue;
        /// <summary>
        /// 参数过滤标识（不同标识记录状态）
        ///     .ICacheParam使用
        /// </summary>
        protected long iParamCycleFlag = 0;
        /// <summary>
        /// 参数缓存
        ///     .ICacheParam使用
        /// </summary>
        protected List<AqiParam> listParamCache = new List<AqiParam>();
        /// <summary>
        /// 参数来源（默认JSON文件）
        ///     .ICacheParam
        /// </summary>
        protected AqiConstant.ParamSourceType pst = AqiConstant.ParamSourceType.JSON;
        /// <summary>
        /// 参数过滤（默认不过滤）
        ///     .ICacheParam使用
        /// </summary>
        protected AqiConstant.ParamFilterType pft = AqiConstant.ParamFilterType.NONE;
        
        /// <summary>
        /// Url参数形式（默认键值对形式）
        ///     .IMakeParam扩展使用
        /// </summary>
        protected AqiConstant.ParamUrlType put = AqiConstant.ParamUrlType.KEY_VALUE;
        /// <summary>
        /// HttpBody参数形式（默认Form表单形式）
        ///     .IMakeParam扩展使用
        /// </summary>
        protected AqiConstant.ParamBodyType pbt = AqiConstant.ParamBodyType.HTTP_FORM;

        #endregion

        #region 属性

        /// <summary>
        /// 内部标签
        ///     .抽象实现ISrcUrl
        /// </summary>
        public abstract string Tag{ get; }
        /// <summary>
        /// 名称
        ///     .抽象实现ISrcUrl
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// 数据接口地址
        ///     .抽象实现ISrcUrl
        /// </summary>
        public abstract string Url { get; }
        /// <summary>
        /// 是否使用参数
        ///     .实现ISrcUrl
        /// </summary>
        public virtual bool UseParam
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// IAqiWeb接口
        ///     .实现ISrcUrl
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
        ///     .实现ISrcUrl
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
        /// 常用更新间隔
        ///     .扩展ISrcUrl
        /// </summary>
        public abstract AQI.AqiConstant.SourceUpdataInterval SUI { get; }

        /// <summary>
        /// 不可忽略空参数
        ///     .实现ISrcUrlParam
        /// </summary>
        public virtual bool ParamIgnoreEmpty
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// 参数名列表
        ///     抽象实现ISrcUrlParam
        /// </summary>
        public abstract List<string> ParamName { get; }

        /// <summary>
        /// 参数发送类型(HTTP获取方式)
        ///     .抽象实现IMakeParam
        /// </summary>
        public abstract AQI.AqiConstant.ParamSendType ParamSendType { get; }
        /// <summary>
        /// 参数缓存列表
        ///     .实现ICacheParam
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
        ///     .实现ICacheParam
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
        ///     .实现ICacheParam
        /// </summary>
        public virtual AQI.AqiConstant.ParamFilterType ParamFilterType
        {
            get
            {
                return pft;
            }
        }

        /// <summary>
        /// Url参数形式
        ///     .扩展IMakeParam
        /// </summary>
        public virtual AQI.AqiConstant.ParamUrlType ParamUrlType
        {
            get
            {
                return put;
            }
        }
        /// <summary>
        /// HttpBody参数形式
        ///     .扩展IMakeParam
        /// </summary>
        public virtual AQI.AqiConstant.ParamBodyType ParamBodyType
        {
            get
            {
                return pbt;
            }
        }

        #endregion

        #region 方法

        #region ISrcUrl接口

        /// <summary>
        /// 获取内容
        ///     不会被调用，已经被ISrcUrlParam取代
        /// </summary>
        /// <returns>null</returns>
        public virtual byte[] GetData()
        {
            throw new NotSupportedException();
        }

        #endregion

        #region ISrcUrlParam接口

        /// <summary>
        /// 枚举参数
        ///     不会被调用，已经被ICacheParam取代
        /// </summary>
        /// <returns>null</returns>
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
        public virtual byte[] GetData(AqiParam param)
        {
            HttpWebResponse response = null;
            try
            {
                Dictionary<string, string> header = MakeRequestHeader(param);
                switch (ParamSendType)
                {
                    case AqiConstant.ParamSendType.GET:
                        string urlparam = MakeUrl(param);
                        response = HttpUtilV2.createGetResponse(urlparam, -1, header);
                        break;
                    case AqiConstant.ParamSendType.POST:
                        byte[] requestbody = MakeRequestBody(param);
                        response = HttpUtilV2.createPostResponse(Url, -1, header, requestbody);
                        break;
                    default:
                        throw new NotSupportedException("ParamSendType only for GET/POST");
                }
            }
            catch (System.Exception ex)
            {
                throw new DataUnHoldException("无法获取数据", ex);
            }

            HttpData data = HttpUtilV2.GetHttpData(response);

            //缓存数据
            if (this is ICacheData)
            {
                ((ICacheData)this).Data = data;
            }

            //提取数据
            if (this is IExtractData)
            {
                return ((IExtractData)this).ExtractData(data.Body);
            }
            return data.Body;
        }

        #endregion

        #region ICacheParam接口

        /// <summary>
        /// 参数路径
        ///     可以重写
        /// </summary>
        /// <returns>Json路径</returns>
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
            switch (ParamSourceType)
            {
                case AqiConstant.ParamSourceType.JSON:
                    DateTime dtNewWriteTime = AqiParam.ReadWriteTimeFormJson(this);
                    if (dtNewWriteTime > this.dtParamCacheTime)
                    {
                        return true;
                    }
                    break;
                case AqiConstant.ParamSourceType.ISrcUrl:
                    return true;
                default:
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
            switch (ParamSourceType)
            {
                case AqiConstant.ParamSourceType.JSON:
                    this.listParamCache = AqiParam.CreateListFormJson(this, this.Tag, AqiParam.PARAMS);
                    this.dtParamCacheTime = AqiParam.ReadWriteTimeFormJson(this);
                    break;
                case AqiConstant.ParamSourceType.ISrcUrl:
                    if (this is IParseSrcUrlParam) 
                    {
                        IParseSrcUrlParam ipp = this as IParseSrcUrlParam;
                        this.listParamCache = AqiParam.CreateListFormSrcUrl(ipp, ipp.ParamSrcUrl);
                        this.dtParamCacheTime = DateTime.Now;
                    }
                    else
                    {
                        throw new ParamException("参数来源类型(ISRCUrl)与接口(IParseParam)不匹配");
                    }
                    break;
                default:
                    throw new ParamException("参数来源类型(ParamSourceType)未知");
            }
            //TODO
            //验证参数是否匹配ParamName


            return true;
        }

        /// <summary>
        /// 过滤参数
        ///     可以重写
        /// </summary>
        /// <returns></returns>
        public virtual List<AqiParam> FilterParams()
        {
            //本次参数过滤
            List<AqiParam> apList = null;

            switch (ParamFilterType)
            {
                case AqiConstant.ParamFilterType.NONE:
                    apList = this.listParamCache;
                    break;
                case AqiConstant.ParamFilterType.InTurn:
                    //iParamCycleFlag代表号，从0开始
                    IEnumerable<IGrouping<string, AqiParam>> query = this.listParamCache.GroupBy(ap => ap.Group);
                    List<IGrouping<string, AqiParam>> listGroup = query.ToList<IGrouping<string, AqiParam>>();

                    if (this.iParamCycleFlag >= listGroup.Count)
                    {
                        //复位
                        this.iParamCycleFlag = 0;
                    }

                    int i = 0;
                    foreach (IGrouping<string, AqiParam> kv in listGroup)
                    {
                        if (this.iParamCycleFlag == i)
                        {
                            apList = kv.ToList<AqiParam>();
                            break;
                        }
                        i++;
                    }

                    this.iParamCycleFlag++;
                    break;
                case AqiConstant.ParamFilterType.OnceAgain:
                    //iParamCycleFlag 0代表ONCE；非0代表AGAIN
                    apList = listParamCache.FindAll(ap => ap.Group.Equals((this.iParamCycleFlag == 0) ? AqiParam.ONCE : AqiParam.AGAIN));
                    this.iParamCycleFlag = 1;
                    break;
            }

            return apList;
        }

        #endregion

        #region IMakeParam接口

        /// <summary>
        /// 拼接含参数Url
        ///     .可以重写
        /// </summary>
        /// <remarks>
        /// 读取参数 所有 ，根据实例属性ParamUrlType处理
        ///     1、 ParamUrlType 为 PATH ，将 所有 交由 MakePathUrl 方法处理，与 Url 属性合并为字符串；
        ///     2、 ParamUrlType 为 KEY_VALUE ，将 所有 交由 MakeKeyValueUrl 方法处理，与 Url 属性合并为字符串；
        /// </remarks>
        /// <param name="param">参数列表</param>
        /// <returns>完整URL</returns>
        public virtual string MakeUrl(AqiParam param)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Url);

            if (ParamUrlType == AqiConstant.ParamUrlType.PATH)
            {
                sb.Append(MakePathUrl(param.Values.ToList<string>()));
            }
            else if (ParamUrlType == AqiConstant.ParamUrlType.KEY_VALUE)
            {
                sb.Append(MakeKeyValueUrl(param));
            }
            else
            {
                throw new ParamException("使用了未知的ParamUrlType");
            }

            return sb.ToString();
        }

        /// <summary>
        /// 拼接请求头
        ///     .可以重写
        /// </summary>
        /// <remarks>
        /// 读取参数 Header ，将 Header 作为 Http Header
        /// TODO 考虑其他格式
        /// </remarks>
        /// <param name="param"></param>
        /// <returns>RequestHeader键值集合</returns>
        public virtual Dictionary<string, string> MakeRequestHeader(AqiParam param)
        {
            //TODO 允许null
            if (param.Header == null)
            {
                return new Dictionary<string, string>();
            }
            return param.Header;
        }

        /// <summary>
        /// 拼接请求体
        ///     .可以重写
        /// </summary>
        /// <remarks>
        /// 读取参数 Body ，转为字节数组
        /// </remarks>
        /// <param name="param">参数列表</param>
        /// <returns>RequestBody字节数组</returns>
        public virtual byte[] MakeRequestBody(AqiParam param)
        {
            switch (ParamBodyType)
            {
                case AqiConstant.ParamBodyType.NONE:
                    break;
                case AqiConstant.ParamBodyType.HTTP_FORM:
                    param.Body = MakeFromBody(param);
                    break;
                case AqiConstant.ParamBodyType.TEXT:
                    param.Body = MakeTextBody(param);
                    break;
                default:
                    throw new NotSupportedException("不被支持的参数类型，ParamBodyType=" + (int)ParamBodyType);
            }
            return param.Body;
        }

        #endregion

        #region IMakeParam接口内部扩展

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

        /// <summary>
        /// 拼接Url参数：路径
        /// </summary>
        /// <param name="listParam"></param>
        /// <returns></returns>
        protected virtual string MakePathUrl(List<string> listParam)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("/");
            foreach (string param in listParam)
            {
                sb.Append(param);
                sb.Append("/");
            }

            string str = sb.ToString(0, sb.Length - 1);
            return Uri.EscapeUriString(str);
        }

        /// <summary>
        /// 拼接HttpBody参数：Form表单
        /// </summary>
        /// <param name="dictParam"></param>
        /// <returns></returns>
        protected virtual byte[] MakeFromBody(Dictionary<string, string> dictParam)
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

        /// <summary>
        /// 拼接HttpBody参数：文本
        /// </summary>
        /// <param name="dictParam"></param>
        /// <returns></returns>
        protected virtual byte[] MakeTextBody(Dictionary<string, string> dictParam)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in dictParam.OrderBy(kv => kv.Key))
            {
                sb.Append(kv.Value);
            }
            return Encoding.UTF8.GetBytes(sb.ToString());
        }

        #endregion

        #endregion

    }
}
