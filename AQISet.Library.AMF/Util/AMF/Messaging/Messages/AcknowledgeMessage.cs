using System;
using FluorineFx.AMF3;
using FluorineFx.Messaging.Messages;

namespace FiddlerAmfParser.Flex.Messaging.Messages
{
    /// <summary>
    /// This type Copy form FluorineFx AcknowledgeMessage, and add IExternalizable method
    /// </summary>
    public class AcknowledgeMessage : AsyncMessage
    {
        #region CopyFormFluorineFx

        /// <summary>
        /// Initializes a new instance of the AcknowledgeMessage class.
        /// </summary>
        public AcknowledgeMessage()
        {
            _messageId = Guid.NewGuid().ToString("D");
            _timestamp = System.Environment.TickCount;
        }

        protected override MessageBase CopyImpl(MessageBase clone)
        {
            // Instantiate the clone, if a derived type hasn't already.
            if (clone == null) clone = new FluorineFx.Messaging.Messages.AcknowledgeMessage();
            return base.CopyImpl(clone);
        }
        
        #endregion

        #region IExternalizable

        public new void ReadExternal(IDataInput input)
        {
            base.ReadExternal(input);

            short[] flagsArray = ReadFlags(input);
            for (int i = 0; i < flagsArray.Length; i++)
            {
                short flags = flagsArray[i];
                short reservedPosition = 0;

                // For forwards compatibility, read in any other flagged objects
                // to preserve the integrity of the input stream...
                if ((flags >> reservedPosition) != 0)
                {
                    for (short j = reservedPosition; j < 6; j++)
                    {
                        if (((flags >> j) & 1) != 0)
                        {
                            input.ReadObject();
                        }
                    }
                }
            }
        }

        public new void WriteExternal(IDataOutput output)
        {
            base.WriteExternal(output);

            short flags = 0;
            output.WriteByte((byte)flags);
        }

        #endregion
    }
}
