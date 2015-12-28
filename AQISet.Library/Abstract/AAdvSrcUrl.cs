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

        public abstract string Tag{ get; }
        public abstract string Name { get; }
        public abstract string Url { get; }
        public abstract bool UseParam { get; }
        public abstract double UDI { get; }
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
        /// HTTP获取方式
        ///     扩展ISrcUrl
        /// </summary>
        public abstract AQI.AqiConstant.HttpType HttpType { get; }

        /// <summary>
        /// 是否忽略空参数
        ///     ISrcUrlParam
        /// </summary>
        public abstract bool ParamIgnoreEmpty { get; }
        /// <summary>
        /// 参数名列表
        ///     ISrcUrlParam
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
        public abstract List<AQI.AqiParam> ParamCache { get; }
        /// <summary>
        /// 参数来源
        ///     ICacheParam
        /// </summary>
        public abstract AQI.AqiConstant.ParamSourceType ParamSourceType { get; }
        /// <summary>
        /// 参数过滤
        ///     ICacheParam
        /// </summary>
        public abstract AQI.AqiConstant.ParamFilterType ParamFilterType { get; }

        /// <summary>
        /// Url参数形式
        ///     扩展IMakeParam
        /// </summary>
        public abstract AQI.AqiConstant.ParamUrlType ParamUrlType { get; }

        #endregion

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

        #endregion

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
        ///     可以重写
        /// </summary>
        /// <param name="param">参数列表</param>
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
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in param)
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
        public virtual byte[] ExtractData(byte[] data)
        {
            return data;
        }

        #endregion

        #endregion

    }
}
