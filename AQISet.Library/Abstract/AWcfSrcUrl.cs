using System;
using System.Net;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using Helper.Util.HTTP;
using Helper.WCFbin;
using AQI.Interface;
using AQI.Exception;

namespace AQI.Abstract
{
    /// <summary>
    /// WCF数据接口
    ///     抽象类
    /// </summary>
    public abstract class AWcfSrcUrl : AParamSrcUrl, IExtractData
    {

        #region 字段

        /// <summary>
        /// WCF HTTP传输
        /// </summary>
        protected WCFMessageHelper _mh;

        #endregion

        #region 属性

        /// <summary>
        /// HTTP获取方式
        ///     .扩展ISrcUrl
        /// </summary>
        public abstract AQI.AqiConstant.HttpType HttpType { get; }

        /// <summary>
        /// 仅提取WCF内容（WCF Content）
        ///     .扩展IExtractData
        /// </summary>
        public abstract bool ExtractWCFContent { get; }
        /// <summary>
        /// WCF内容编码格式（WCF Content即WCF Message Body，提取为WCF Content Binary(WCF二进制内容)）
        ///     .扩展IExtractData
        /// </summary>
        public abstract Helper.WCFbin.WCFMessageUtil.WCFContentFormat WCFContentFormat { get; }
        
        #endregion

        protected AWcfSrcUrl()
        {
            _mh = new WCFMessageHelper();
        }

        #region 方法

        #region ISrcUrl接口

        /// <summary>
        /// 获取内容
        ///     .可以重写
        /// </summary>
        /// <returns></returns>
        public override byte[] GetData()
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

        #region IMakeParam接口

        /// <summary>
        /// 拼接请求体
        ///     .可以重写
        /// </summary>
        /// <remarks>
        /// 将XML形式的WCFMessage转为Bin形式的WCFMessage
        /// </remarks>
        /// <param name="param">参数列表</param>
        /// <returns></returns>
        public override byte[] MakeRequestBody(AqiParam param)
        {
            string wcfmessage = MakeWCFMsg(param);

            byte[] requestBody = _mh.GetWcfBinaryMessageAsBinary(wcfmessage);

            return requestBody;
        }

        #endregion

        #region IExtractData接口

        /// <summary>
        /// 数据提取
        ///     .可以重写
        /// </summary>
        /// <remarks>
        /// 提取Bin形式的WCFMessge为XML形式的WCFMessage，根据属性ExtractWCFContent、WCFContentFormat提取WCFContent
        /// </remarks>
        /// <param name="requestbody"></param>
        /// <returns></returns>
        public virtual byte[] ExtractData(byte[] responsebody)
        {
            //获取WCF Message
            string strWCFMsg = _mh.GetWcfBinaryMessageAsText(responsebody);

            byte[] wcfbin = null;
            if (ExtractWCFContent)
            {
                //从WCF Message提取WCF Message Body，转化为WCF Content Binary
                //获取WCF Content Binary
                wcfbin = WCFMessageUtil.getWCFBinByWCFMsg(strWCFMsg, Tag, WCFContentFormat);
            }
            else
            {
                wcfbin = Encoding.UTF8.GetBytes(strWCFMsg);
            }
            
            return wcfbin;
        }

        #endregion

        #region WCF数据接口 通用方法

        /// <summary>
        /// 拼接WCFMessage
        ///     .必须重写
        /// </summary>
        /// <see cref="MakeRequestBody"/>
        /// <param name="dictParam">参数列表</param>
        /// <returns></returns>
        public abstract string MakeWCFMsg(Dictionary<string, string> dictParam);

        #endregion

        #endregion

    }
}
