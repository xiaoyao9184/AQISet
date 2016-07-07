using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Helper.Util.HTTP;
using AQI.Interface;
using AQI.Exception;

namespace AQI.Abstract
{
    /// <summary>
    /// 高级数据接口
    ///     抽象类
    /// </summary>
    public abstract class AAdvSrcUrl : ISrcUrl, ISrcUrlParam, ICacheParam, IMakeParam, IExtractData
    {

        #region 字段

        /// <summary>
        /// IAqiWeb接口
        ///     ISrcUrl
        /// </summary>
        protected IAqiWeb iaw;

        #endregion

        #region 属性

        /// <summary>
        /// 内部标签
        ///     .ISrcUrl
        /// </summary>
        public abstract string Tag{ get; }
        /// <summary>
        /// 名称
        ///     .ISrcUrl
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// 数据接口地址
        ///     .ISrcUrl
        /// </summary>
        public abstract string Url { get; }
        /// <summary>
        /// 是否使用参数
        ///     .ISrcUrl
        /// </summary>
        public abstract bool UseParam { get; }
        /// <summary>
        /// 更新间隔
        ///     .ISrcUrl
        /// </summary>
        public abstract double UDI { get; }
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
        /// HTTP获取方式
        ///     .ISrcUrl
        /// </summary>
        public abstract AQI.AqiConstant.HttpType HttpType { get; }

        /// <summary>
        /// 是否忽略空参数
        ///     .ISrcUrlParam
        /// </summary>
        public abstract bool ParamIgnoreEmpty { get; }
        /// <summary>
        /// 参数名列表
        ///     .ISrcUrlParam
        /// </summary>
        public abstract List<string> ParamName { get; }
        /// <summary>
        /// 参数发送类型(HTTP获取方式)
        ///     .IMakeParam
        /// </summary>
        public abstract AQI.AqiConstant.ParamSendType ParamSendType { get; }
        /// <summary>
        /// 参数缓存列表
        ///     .ICacheParam
        /// </summary>
        public abstract List<AQI.AqiParam> ParamCache { get; }
        /// <summary>
        /// 参数来源
        ///     .ICacheParam
        /// </summary>
        public abstract AQI.AqiConstant.ParamSourceType ParamSourceType { get; }
        /// <summary>
        /// 参数过滤
        ///     .ICacheParam
        /// </summary>
        public abstract AQI.AqiConstant.ParamFilterType ParamFilterType { get; }

        /// <summary>
        /// Url参数形式
        ///     .IMakeParam
        /// </summary>
        public abstract AQI.AqiConstant.ParamUrlType ParamUrlType { get; }

        /// <summary>
        /// HttpBody参数形式
        ///     .IMakeParam
        /// </summary>
        public abstract AQI.AqiConstant.ParamBodyType ParamBodyType { get; }

        #endregion

        #region 方法

        #region ISrcUrl接口

        /// <summary>
        /// 获取内容
        ///     可以重写
        /// </summary>
        /// <returns></returns>
        public byte[] GetData()
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
        ///     不会被调用，已经被ICacheParam取代
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
        public virtual byte[] GetData(AqiParam param)
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
                    responsebody = HttpUtilV2.doPostRequest(Url, requestbody);
                    break;
                default:
                    responsebody = HttpUtilV2.doGetRequest(Url);
                    break;
            }

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
        ///     需要重写
        /// </summary>
        /// <returns>true过期；false未过期</returns>
        public abstract bool IsParamsExpired();

        /// <summary>
        /// 加载参数
        ///     需要重写
        /// </summary>
        /// <returns></returns>
        public abstract bool LoadParams();

        /// <summary>
        /// 过滤参数
        ///     需要重写
        /// </summary>
        /// <param name="listParam"></param>
        /// <returns></returns>
        public abstract List<AqiParam> FilterParams();

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
        /// <returns></returns>
        public virtual Dictionary<string, string> MakeRequestHeader(AqiParam param)
        {
            //允许null
            return param.Header;
        }

        /// <summary>
        /// 拼接请求体
        ///     .可以重写
        /// </summary>
        /// <remarks>
        /// 读取参数 所有 ，转为 html form 表单字符串，转为字节数组
        /// </remarks>
        /// <param name="param">参数列表</param>
        /// <returns>RequestBody字节数组</returns>
        public virtual byte[] MakeRequestBody(AqiParam param)
        {
            if (param.Body == null)
            {
                switch (ParamBodyType)
                {
                    case AqiConstant.ParamBodyType.NONE:
                        param.Body = new byte[0];
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

        #region IExtract接口

        /// <summary>
        /// 数据提取
        ///     可以重写
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public virtual byte[] ExtractData(byte[] data)
        {
            return data;
        }

        #endregion

        #endregion

    }
}
