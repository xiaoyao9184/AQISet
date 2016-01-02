using System;
using FiddlerAmfParser.Flex.Messaging.IO;
using FluorineFx.AMF3;

namespace FiddlerAmfParser.Flex.Messaging.Messages
{
    /// <summary>
    /// This type is transplant form BlazeDS
    /// </summary>
    public class AcknowledgeMessageExt : AcknowledgeMessage, IExternalizable, IClassAlias
    {
        public const String CLASS_ALIAS = "DSK";
        private AcknowledgeMessage _message;

        public AcknowledgeMessageExt()
        {
            
        }

        public AcknowledgeMessageExt(AcknowledgeMessage message):base()
        {
            _message = message;
        }

        public string getAlias()
        {
            return CLASS_ALIAS;
        }

        public new void WriteExternal(IDataOutput output)
        {
            if (_message != null)
                _message.WriteExternal(output);
            else
                base.WriteExternal(output);
        }

    }
}
