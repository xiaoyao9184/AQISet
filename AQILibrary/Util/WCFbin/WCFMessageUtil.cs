using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Helper.WCFbin
{
    /// <summary>
    /// WCF消息工具
    /// xiaoyao9184
    /// 1.0 2015-01-27
    /// </summary>
    public class WCFMessageUtil
    {

        /// <summary>
        /// WCF Content Binary(WCF二进制内容)编码格式
        ///     编码到WCF Message里面用到的文本格式
        /// </summary>
        public enum WCFContentFormat
        {
            NONE, BASE64, UTF8
        }

        /// <summary>
        /// 提取WCF Content Binary
        /// </summary>
        /// <param name="strWCFMsg">WCF Message</param>
        /// <param name="strTag">WCF Message内容标签</param>
        /// <param name="wcfCT">WCF Content编码格式</param>
        /// <returns></returns>
        public static byte[] getWCFBinByWCFMsg(string strWCFMsg, string strTag, WCFContentFormat wcfCF)
        {
            //提取WCF Message Body
            XmlDocument document = new XmlDocument();
            document.LoadXml(strWCFMsg);
            XmlNodeList xnl = document.GetElementsByTagName(strTag + "Result");
            string strWCFMsgBody = xnl[0].InnerXml;
            //转为WCF Content Binary
            switch (wcfCF)
            {
                case WCFContentFormat.BASE64:
                    return Convert.FromBase64String(strWCFMsgBody);
                case WCFContentFormat.UTF8:
                default:
                    return Encoding.UTF8.GetBytes(strWCFMsgBody);
            }
        }
    }
}
