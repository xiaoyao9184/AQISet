using FiddlerAmfParser.Flex.Messaging.IO;
using FluorineFx.AMF3;

namespace FiddlerAmfParser.Flex.Messaging.Messages
{
    /// <summary>
    /// This type is transplant form BlazeDS
    /// </summary>
    public class CommandMessageExt : CommandMessage, IExternalizable, IClassAlias
    {
        public const string CLASS_ALIAS = "DSC";
        private CommandMessage _message;
        public CommandMessageExt()
        {
            
        }

        public CommandMessageExt(CommandMessage message):base()
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
