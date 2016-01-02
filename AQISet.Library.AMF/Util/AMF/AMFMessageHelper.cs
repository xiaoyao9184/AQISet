using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AQI.Util.AMF.Json;
using FiddlerAmfParser.Flex.Messaging.Messages;
using FluorineFx.Configuration;
using FluorineFx.IO;
using Newtonsoft.Json;

namespace Helper.AMF
{
    /// <summary>
    /// this is a Plug-in for FiddlerAmfParser
    /// </summary>
    public class AMFMessageHelper
    {
        /// <summary>
        /// FluorineFx can read any Type in Assembly if we use add mapping in FluorineConfiguration.
        /// When we need AMFDeserializer to read AMFMessage, AMFReader use class name to create a Object.
        /// The Object create by ObjectFactory, ObjectFactory find and load dll file in current path.
        /// </summary>
        static AMFMessageHelper()
        {
            //register DSMessage Type to FluorineFx
            var classMap = FluorineConfiguration.Instance.FluorineSettings.ClassMappings;
            classMap.Add(typeof(AcknowledgeMessageExt).FullName, "DSK");
            classMap.Add(typeof(AsyncMessageExt).FullName, "DSA");
            classMap.Add(typeof(CommandMessageExt).FullName, "DSC");

            //use this can fix FiddlerScriptOutputProcessor.ProcessAmfBody self referencing loop error 
            Newtonsoft.Json.JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }


        #region Binary2String

        private AMFMessage LoadBinMessageIntoAmfMessage(byte[] encodedMessage)
        {
            AMFMessage message = null;
            byte[] buffer = encodedMessage;
            MemoryStream stream = new MemoryStream(buffer);
            try
            {
                message = new AMFDeserializer(stream).ReadAMFMessage();
            }
            catch (DecoderFallbackException)
            {
                stream.Position = 0;
                object content = new AMFReader(stream) { FaultTolerancy = true }.ReadAMF3Data();
                message = new AMFMessage(3);
                message.AddBody(new AMFBody(string.Empty, string.Empty, content));
            }

            return message;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="encodedMessage"></param>
        /// <returns></returns>
        public string GetAmfBinaryMessageAsText(byte[] encodedMessage)
        {
            AMFMessage message = this.LoadBinMessageIntoAmfMessage(encodedMessage);
            return JsonConvert.SerializeObject(message);
        }

        #endregion
        
        #region Binary2String

        public byte[] LoadAmfMessageIntoBinMessage(AMFMessage message)
        {
            byte[] buffer = null;
            MemoryStream stream = new MemoryStream();

            AMFSerializer amfSerializers = new AMFSerializer(stream);
            amfSerializers.WriteMessage(message);
            amfSerializers.Flush();
            buffer = new byte[amfSerializers.BaseStream.Length];
            stream.Position = 0;
            stream.Read(buffer, 0, buffer.Length);

            return buffer;
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="uncodedMessage"></param>
        /// <returns></returns>
        public byte[] GetAmfBinaryMessageAsBinary(string uncodedMessage)
        {
            AMFMessage message = JsonConvert.DeserializeObject<AMFMessage>(uncodedMessage,new AMFMessageConverter());
//             AMFMessage message = JsonConvert.DeserializeObject<AMFMessage>(uncodedMessage,new JsonSerializerSettings()
//             {
//                 MissingMemberHandling = MissingMemberHandling.Error
//             });
            byte[] bytes = this.LoadAmfMessageIntoBinMessage(message);
            return bytes;
        }

        #endregion
    }
}
