using System;
using System.Collections.Generic;
using System.Text;
using AQI.Interface;
using AQI.Exception;
using FluorineFx.IO;
using Helper.AMF;

namespace AQI.Abstract
{
    /// <summary>
    /// AMF数据接口
    ///     抽象类
    /// </summary>
    public abstract class AAmfSrcUrl : AParamSrcUrl, IExtractData
    {

        #region 字段

        /// <summary>
        /// AMF HTTP传输
        /// </summary>
        protected AMFMessageHelper _mh;

        #endregion

        #region 属性

        /// <summary>
        /// 使用POST方式
        /// </summary>
        public override AQI.AqiConstant.ParamSendType ParamSendType
        {
            get
            {
                return AQI.AqiConstant.ParamSendType.POST;
            }
        }

        #endregion

        protected AAmfSrcUrl()
        {
            _mh = new AMFMessageHelper();
        }

        #region 方法

        #region IMakeParam接口

        /// <summary>
        /// 拼接请求头
        ///     .可以重写
        /// </summary>
        /// <remarks>
        /// 读取参数，若不存在‘Content-Type’则添加默认‘application/x-amf’
        /// </remarks>
        /// <param name="param"></param>
        /// <returns></returns>
        public override Dictionary<string, string> MakeRequestHeader(AqiParam param)
        {
            Dictionary<string, string> header = base.MakeRequestHeader(param);
            if (!header.ContainsKey("Content-Type"))
            {
                header.Add("Content-Type", @"application/x-amf");
            }
            return header;
        }

        /// <summary>
        /// 拼接请求体
        ///     .可以重写
        /// </summary>
        /// <remarks>
        /// 读取参数 messageType、message ，根据 messageType 进行处理
        ///     1、 messageType 为 base64，将 message 作为 base64 字符串转为字节数组；
        ///     2、 messageType 为 json，将 message 作为 json 字符串解析为字节数组；
        ///     3、 messageType 不存在或为 code 或为空，若实例实现 IMakeAMFMessage 接口，
        ///         将调用 MakeAMFMsg 处理并将返回的AMFMessage对象 序列化为字节数组；
        /// </remarks>
        /// <param name="param">参数列表</param>
        /// <returns></returns>
        public override byte[] MakeRequestBody(AqiParam param)
        {
            string type = "base64";
            string message = null;
            byte[] requestBody = null;
            //check
            if (param.ContainsKey("messageType") &&
                !String.IsNullOrEmpty(param["messageType"]))
            {
                type = param["messageType"];
            }
            else if (this is IMakeAMFMessage)
            {
                IMakeAMFMessage iMakeAmfMsg = this as IMakeAMFMessage;
                AMFMessage amfmessage = iMakeAmfMsg.MakeAMFMsg(param);
                return _mh.LoadAmfMessageIntoBinMessage(amfmessage);
            }
            if (param.ContainsKey("message") &&
                !String.IsNullOrEmpty(param["message"]))
            {
                message = param["message"];
            }
            else
            {
                throw new ParamException("所需message参数丢失");
            }

            try
            {
                switch (type)
                {
                    case "base64":
                        requestBody = Convert.FromBase64String(message);
                        break;
                    case "json":
                        requestBody = _mh.GetAmfBinaryMessageAsBinary(message);
                        break;
                    case "code":
                        if (this is IMakeAMFMessage)
                        {
                            IMakeAMFMessage iMakeAmfMsg = this as IMakeAMFMessage;
                            AMFMessage amfmessage = iMakeAmfMsg.MakeAMFMsg(param);
                            return _mh.LoadAmfMessageIntoBinMessage(amfmessage);
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                        break;
                    default:
                        throw new NotImplementedException();
                        break;
                }
            }
            catch (System.Exception ex)
            {
                throw new ParamException("参数格式错误",ex);
            }
            
            return requestBody;
        }

        #endregion

        #region IExtractData接口

        /// <summary>
        /// 数据提取
        ///     .可以重写
        /// </summary>
        /// <remarks>
        /// 提取Bin形式的AMFMessge为JSON形式的AMFMessage
        /// </remarks>
        /// <param name="responsebody"></param>
        /// <returns></returns>
        public virtual byte[] ExtractData(byte[] responsebody)
        {
            //获取AMF Message
            string strAMFMsg = _mh.GetAmfBinaryMessageAsText(responsebody);

            byte[] amfbin = Encoding.UTF8.GetBytes(strAMFMsg);
            
            return amfbin;
        }

        #endregion

        #endregion

    }
}
