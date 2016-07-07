using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AQI.Interface;
using AQI.Exception;
using FluorineFx.Configuration;
using FluorineFx.IO;
using Helper.AMF;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AQI.Abstract
{
    /// <summary>
    /// AMF数据接口
    ///     抽象类
    /// </summary>
    public abstract class AAmfSrcUrl : AParamSrcUrl, IExtractData
    {

        #region 常量

        public const string PARAM_AMF = "amf";
        public const string PARAM_AMF_TYPE = "type";
        public const string PARAM_AMF_MSG = "message";

        #endregion

        #region 枚举

        /// <summary>
        /// 参数amf.type
        /// </summary>
        public enum AMFMessageParamType
        {
            NoUse,
            UseJson,
            UseXml,
            UseCode
        }

        #endregion
        
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
            pbt = AqiConstant.ParamBodyType.NONE;
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
        /// 读取参数 amf ，将 amf.type 解析为枚举 AMFMessageParamType 进行处理
        ///     1、 AMFMessageParamType 为 UseJson，将 amf.message 作为 json 字符串解析为字节数组；
        ///     2、 AMFMessageParamType 为 UseXml，将 amf.message 作为 xml 字符串解析为字节数组；
        ///     3、 AMFMessageParamType 为 UseCode 并且本实例实现 IMakeAMFMessage 接口，
        ///         将 amf.message 作为参数调用 IMakeAMFMessage接口 MakeAMFMsg方法生成 AMFMessage对象，序列化为字节数组；
        ///     4、AMFMessageParamType 为 NoUse，使用父类 MakeRequestBody。
        /// 若无参数 amf 则使用父类 MakeRequestBody
        /// </remarks>
        /// <param name="param">参数列表</param>
        /// <returns></returns>
        public override byte[] MakeRequestBody(AqiParam param)
        {
            if (param.ContainsKey(PARAM_AMF) &&
                !String.IsNullOrEmpty(param[PARAM_AMF]))
            {
                Dictionary<string, string> map = new Dictionary<string, string>();
                JObject jo = JObject.Parse(param[PARAM_AMF]);
                JToken jt = jo.SelectToken(PARAM_AMF_TYPE);
                map.Add(PARAM_AMF_TYPE,jt.ToString());
                jt = jo.SelectToken(PARAM_AMF_MSG);
                map.Add(PARAM_AMF_MSG, jt.ToString());
                
                if (map.ContainsKey(PARAM_AMF_TYPE) &&
                    !String.IsNullOrEmpty(map[PARAM_AMF_TYPE]) &&
                    map.ContainsKey(PARAM_AMF_MSG) &&
                    !String.IsNullOrEmpty(map[PARAM_AMF_MSG]))
                {
                    AMFMessageParamType ampt;
                    if (Enum.TryParse(map[PARAM_AMF_TYPE], out ampt))
                    {
                        switch (ampt)
                        {
                            case AMFMessageParamType.UseJson:
                                param.Body = _mh.GetAmfBinaryMessageAsBinary(map[PARAM_AMF_MSG]);
                                break;
                            case AMFMessageParamType.UseXml:
                                //TODO 尝试amfx
                                throw new NotSupportedException("不被支持的参数类型，amf.type=" + (int) ampt);
                            case AMFMessageParamType.UseCode:
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
                            case AMFMessageParamType.NoUse:
                                base.MakeRequestBody(param);
                                break;
                            default:
                                throw new NotSupportedException("不被支持的参数类型，amf.type=" + (int) ampt);
                        }
                    }
                    else
                    {
                        throw new NotSupportedException("参数amf.type=" + map[PARAM_AMF_TYPE] + "是不被支持的！");
                    }
                }
            }
            else
            {
                base.MakeRequestBody(param);
            }

            return param.Body;
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
