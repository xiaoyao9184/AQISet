using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace Helper.WCFbin
{
    /// <summary>
    /// WCF序列化
    /// xiaoyao9184
    /// 1.0 2014-12-31 序列化/反序列化
    /// 移植自BinaryMessageFiddlerExtension.dll
    /// </summary>
    public class WCFMessageHelper
    {
        private static readonly XmlDictionary _wcfBinaryDictionary;

        static WCFMessageHelper()
        {
            _wcfBinaryDictionary = WcfBinaryDictionary.CreateWcfBinaryDictionary();
        }


        #region Binary2String

        private XmlDictionaryReader CreateReaderForMessage(byte[] encodedMessage)
        {
            return XmlDictionaryReader.CreateBinaryReader(encodedMessage, 0, encodedMessage.Length, _wcfBinaryDictionary, XmlDictionaryReaderQuotas.Max);
        }

        private XmlDocument LoadMessageIntoDocument(byte[] encodedMessage)
        {
            using (XmlDictionaryReader reader = this.CreateReaderForMessage(encodedMessage))
            {
                XmlDocument document = new XmlDocument();
                document.Load(reader);
                return document;
            }
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="encodedMessage"></param>
        /// <returns></returns>
        public string GetWcfBinaryMessageAsText(byte[] encodedMessage)
        {
            XmlDocument document = this.LoadMessageIntoDocument(encodedMessage);
            return this.WriteDocumentToString(document);
        }

        #endregion

        #region String2Binary

        private byte[] LoadDocumentIntoMessage(XmlDocument doc)
        {
            Stream ms = new MemoryStream();
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(ms, _wcfBinaryDictionary);

            doc.WriteContentTo(writer);
            writer.Flush();

            byte[] bb = new byte[ms.Length];
            ms.Seek(0, SeekOrigin.Begin);
            ms.Read(bb, 0, (int)ms.Length);

            return bb;
        }
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="uncodedMessage"></param>
        /// <returns></returns>
        public byte[] GetWcfBinaryMessageAsBinary(string uncodedMessage)
        {
            XmlDocument doc = WriteStringToDocument(uncodedMessage);
            byte[] bytes = this.LoadDocumentIntoMessage(doc);
            return bytes;
        }

        #endregion

        #region Document2String

        private string WriteDocumentToString(XmlDocument document)
        {
            StringWriter w = new StringWriter();
            using (XmlTextWriter writer2 = new XmlTextWriter(w))
            {
                writer2.Formatting = Formatting.None;
                writer2.Indentation = 1;
                document.WriteTo(writer2);
            }
            return w.ToString();
        }
        private XmlDocument WriteStringToDocument(string str)
        {
            StringReader r = new StringReader(str);
            XmlTextReader reader = new XmlTextReader(r);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            return doc;
        }

        #endregion

    }
}
