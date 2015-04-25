using System;
using System.Collections.Generic;
using AQI.Abstract;
using System.Text;
using System.IO;
using System.Xml;
using AQI;
using Helper.Util.HTTP;
using System.Net;

namespace bjmemc.Abstract
{
    /// <summary>
    /// 北京数据接口
    ///     通用抽象类
    /// </summary>
    public abstract class bjmemcSrcUrl : AWcfSrcUrl
    {

        #region 属性

        /// <summary>
        /// 使用参数
        /// </summary>
        public override bool USEPARAM
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// 使用POST方式
        /// </summary>
        public override AQI.AqiConstant.ParamType PT
        {
            get
            {
                return AQI.AqiConstant.ParamType.POST;
            }
        }

        /// <summary>
        /// 无参数
        /// </summary>
        public override List<string> PL
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// 使用UTF8编码格式WCFBin
        /// </summary>
        public override Helper.WCFbin.WCFMessageUtil.WCFContentFormat CF
        {
            get
            {
                return Helper.WCFbin.WCFMessageUtil.WCFContentFormat.UTF8;
            }
        }

        #endregion

        #region 方法

        #region ISrcUrl接口

        /// <summary>
        /// 获取数据
        ///     重写
        /// </summary>
        /// <param name="dictParam"></param>
        /// <returns></returns>
        public override byte[] getDate(Dictionary<string, string> dictParam)
        {
            //得到responsebody
            byte[] responsebody = null;
            if (PT == AqiConstant.ParamType.POST)
            {
                //这里使用ContentType为application/soap+msbin1
                byte[] requestbody = makeRequestBody(dictParam);
                HttpWebResponse response = HttpUtilV2.createPostResponse(URL, 10000, "application/soap+msbin1", requestbody);
                responsebody = HttpUtilV2.getResponseBody(response);
            }
            else
            {
                string urlparam = makeUrl(dictParam);
                responsebody = HttpUtilV2.doGetRequest(urlparam);
            }

            //提取数据
            return extractData(responsebody);
        }

        #endregion

        #region WCF数据接口 通用方法

        /// <summary>
        /// 制作WCFMessage
        ///     实现
        /// ！ 生成的2进制xml,序列化时，效果不太一样
        /// </summary>
        /// <param name="dictParam"></param>
        /// <returns></returns>
        public override string makeWCFMsg(Dictionary<string, string> dictParam)
        {
            //名称
            string name = dictParam[""];

            Encoding utf8 = new UTF8Encoding(false);
            Stream ms = new MemoryStream();
            XmlTextWriter xw = new XmlTextWriter(ms, utf8);
            xw.Namespaces = true;
            
            xw.WriteStartElement("s:Envelope");
            xw.WriteAttributeString("xmlns:s", "http://www.w3.org/2003/05/soap-envelope");
            xw.WriteAttributeString("xmlns:a", "http://www.w3.org/2005/08/addressing");
            //Header
                xw.WriteStartElement("s:Header");
                    xw.WriteStartElement("a:Action");
                    xw.WriteAttributeString("s:mustUnderstand", "1");
                    xw.WriteString("urn:DataService/" + name);
                    xw.WriteEndElement();

                    xw.WriteStartElement("a:MessageID");
                    xw.WriteString("urn:uuid:eb38dd04-a5ad-424d-abaf-f46c984ee395");
                    xw.WriteEndElement();

                    xw.WriteStartElement("a:SequenceAcknowledgement");
                    xw.WriteStartElement("a:ReplyTo");
                    xw.WriteString("http://www.w3.org/2005/08/addressing/anonymous");
                    xw.WriteEndElement();
                    xw.WriteEndElement();

                    xw.WriteStartElement("a:To");
                    xw.WriteAttributeString("s:mustUnderstand", "1");
                    xw.WriteString("http://zx.bjmemc.com.cn/DataService.svc");
                    xw.WriteEndElement();
                xw.WriteEndElement();
            //body
                xw.WriteStartElement("s:Body");
                    xw.WriteStartElement(name);
                    xw.WriteWhitespace("");
                    xw.WriteEndElement();
                xw.WriteEndElement();
            xw.WriteEndElement();
            xw.Flush();

            byte[] bb = new byte[ms.Length];
            ms.Seek(0, SeekOrigin.Begin);
            ms.Read(bb, 0, (int)ms.Length);

            string strWCFMsg = utf8.GetString(bb);
            return strWCFMsg;
        }

        #endregion

        #endregion

    }
}
