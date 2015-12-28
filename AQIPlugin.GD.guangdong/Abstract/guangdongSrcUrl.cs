using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Net;
using Helper.Util.HTTP;
using AQI;
using AQI.Abstract;
using System.Xml.Linq;

namespace guangdong.Abstract
{
    /// <summary>
    /// 广东数据接口
    ///     通用抽象类
    /// </summary>
    public abstract class guangdongSrcUrl : AParamSrcUrl
    {

        #region 属性

        /// <summary>
        /// 无参数
        /// </summary>
        public override List<string> ParamName
        {
            get
            {
                return null;
            }
        }

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

        #region 方法

        #region ISrcUrlParam接口

        /// <summary>
        /// 获取数据
        ///     重写
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public override byte[] GetData(AqiParam param)
        {
            //得到responsebody
            byte[] responsebody = null;
            if (ParamSendType == AqiConstant.ParamSendType.POST)
            {
                //添加2个Header
                //SOAPAction: "http://tempuri.org/IEnvCriteriaAqiService/GetAllAQIPublish"
                //Content-Type: text/xml; charset=utf-8
                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("SOAPAction", @"http://tempuri.org/IEnvCriteriaAqiService/" + this.Tag);
                header.Add("Content-Type", @"text/xml; charset=utf-8");

                byte[] requestbody = MakeRequestBody(param);
                HttpWebResponse response = HttpUtilV2.createPostResponse(Url, -1, header, requestbody);
                responsebody = HttpUtilV2.getResponseBody(response);
            }
            else
            {
                string urlparam = MakeUrl(param);
                responsebody = HttpUtilV2.doGetRequest(urlparam);
            }

            //提取数据
            return responsebody;
        }

        #endregion

        #region 重写方法

        /// <summary>
        /// 拼接请求体
        /// </summary>
        /// <param name="param">参数列表</param>
        /// <returns></returns>
        public override byte[] MakeRequestBody(AqiParam param)
        {
            XDocument doc = new XDocument();

            XNamespace nsS = XNamespace.Get("http://schemas.xmlsoap.org/soap/envelope/");
            XElement eEnvelope = new XElement(XName.Get("Envelope", nsS.NamespaceName),
                new XAttribute(XNamespace.Xmlns + "s", nsS));
            XElement eBody = new XElement(XName.Get("Body", nsS.NamespaceName));

            XNamespace ns = XNamespace.Get("http://tempuri.org/");
            XElement eName = new XElement(XName.Get(this.Tag, ns.NamespaceName));

            eBody.Add(eName);
            eEnvelope.Add(eBody);
            doc.Add(eEnvelope);

            MemoryStream ms = new MemoryStream();
            //StreamWriter w = new StreamWriter(ms, Encoding.UTF8);
            XmlWriterSettings xws = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Encoding = Encoding.UTF8
            };
            XmlWriter writer2 = XmlWriter.Create(ms, xws);
            using (writer2)
            {
                doc.WriteTo(writer2);
                writer2.Flush();
            }

            byte[] requestBody = ms.ToArray();

            return requestBody;
        }

        #endregion
        
        #endregion

    }
}
