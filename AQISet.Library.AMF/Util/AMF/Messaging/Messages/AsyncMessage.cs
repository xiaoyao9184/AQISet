using System;
using FluorineFx.AMF3;
using FluorineFx.Messaging.Messages;

namespace FiddlerAmfParser.Flex.Messaging.Messages
{
    /// <summary>
    /// This type Copy form FluorineFx AsyncMessage, and add IExternalizable method
    /// </summary>
    public class AsyncMessage : AbstractMessage
    {
        #region CopyFormFluorineFx

        /// <summary>
        /// Messages sent by a MessageAgent with a defined subtopic property indicate their target subtopic in this header.
        /// </summary>
        public const string SubtopicHeader = "DSSubtopic";
        /// <summary>
        /// Correlation id for the AsyncMessage.
        /// </summary>
        protected string _correlationId;
        /// <summary>
        /// Initializes a new instance of the AsyncMessage class.
        /// </summary>
        public AsyncMessage()
        {
        }
        /// <summary>
        /// Gets or sets the correlation id of the message.
        /// </summary>
        /// <remarks>
        /// Used for acknowledgement and for segmentation of messages. The correlationId contains the messageId of the previous message that this message refers to.
        /// </remarks>
        public string correlationId
        {
            get { return _correlationId; }
            set { _correlationId = value; }
        }

        protected override MessageBase CopyImpl(MessageBase clone)
        {
            // Instantiate the clone, if a derived type hasn't already.
            if (clone == null) clone = new AsyncMessage();
            // Allow base type(s) to copy their state into the new clone.
            base.CopyImpl(clone);
            // Copy our state into the clone.
            ((AsyncMessage)clone)._correlationId = _correlationId;
            return clone;
        }
        /// <summary>
        /// Returns a string that represents the current AsyncMessage object fields.
        /// </summary>
        /// <param name="indentLevel">The indentation level used for tracing the message members.</param>
        /// <returns>A string that represents the current AsyncMessage object fields.</returns>
        protected override string ToStringFields(int indentLevel)
        {
            String sep = GetFieldSeparator(indentLevel);
            String value = sep + "clientId = " + clientId;
            value += sep + "correlationId = " + correlationId;
            value += sep + "destination = " + destination;
            value += sep + "messageId = " + messageId;
            value += sep + "timestamp = " + timestamp;
            value += sep + "timeToLive = " + timeToLive;
            value += sep + "body = " + BodyToString(body, indentLevel);
            value += base.ToStringFields(indentLevel);
            return value;
        }

        #endregion

        #region IExternalizable

        // Serialization constants
        private static byte CORRELATION_ID_FLAG = 1;
        private static byte CORRELATION_ID_BYTES_FLAG = 2;

        protected byte[] correlationIdBytes;
        public new void ReadExternal(IDataInput input)
        {
            base.ReadExternal(input);

            short[] flagsArray = ReadFlags(input);
            for (int i = 0; i < flagsArray.Length; i++)
            {
                short flags = flagsArray[i];
                short reservedPosition = 0;

                if (i == 0)
                {
                    if ((flags & CORRELATION_ID_FLAG) != 0)
                        correlationId = Convert.ToString(input.ReadObject());

                    if ((flags & CORRELATION_ID_BYTES_FLAG) != 0)
                    {
                        var obj = input.ReadObject();
                        if (obj is ByteArray)
                        {
                            correlationIdBytes = (obj as ByteArray).ToArray();
                        }
                        else
                        {
                            throw new InvalidCastException("AMF object is not ByteArray type cant convert to byte array.");
                        }
                        correlationId = new Guid(correlationIdBytes).ToString();
                    }

                    reservedPosition = 2;
                }

                // For forwards compatibility, read in any other flagged objects
                // to preserve the integrity of the input stream...
                if ((flags >> reservedPosition) != 0)
                {
                    for (short j = reservedPosition; j < 6; j++)
                    {
                        if (((flags >> j) & 1) != 0)
                            input.ReadObject();
                    }
                }
            }
        }

        public new void WriteExternal(IDataOutput output)
        {
            base.WriteExternal(output);

            if (correlationIdBytes == null && correlationId != null)
                correlationIdBytes = new Guid(correlationId).ToByteArray();

            byte flags = 0;

            if (correlationId != null && correlationIdBytes == null)
                flags |= CORRELATION_ID_FLAG;

            if (correlationIdBytes != null)
                flags |= CORRELATION_ID_BYTES_FLAG;

            output.WriteByte(flags);

            if (correlationId != null && correlationIdBytes == null)
                output.WriteObject(correlationId);

            if (correlationIdBytes != null)
                output.WriteObject(correlationIdBytes);
        }

        #endregion
    }
}
