using System;
using FiddlerAmfParser.Flex.Messaging.IO;
using FluorineFx.AMF3;

namespace FiddlerAmfParser.Flex.Messaging.Messages
{
    /// <summary>
    /// This type is transplant form BlazeDS
    /// </summary>
    public class AsyncMessageExt : AsyncMessage, IExternalizable, IClassAlias
    {
        public const String CLASS_ALIAS = "DSA";
        private AsyncMessage _message;

        public AsyncMessageExt()
        {
        }

        public AsyncMessageExt(AsyncMessage message): base()
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
                ((AbstractMessage) _message).WriteExternal(output);
            else
                ((AbstractMessage) this).WriteExternal(output);
        }

    }
}
