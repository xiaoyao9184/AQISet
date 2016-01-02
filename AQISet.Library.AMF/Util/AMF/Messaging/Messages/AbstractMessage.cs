using System;
using System.Reflection;
using System.Text;
using FluorineFx;
using FluorineFx.AMF3;
using FluorineFx.Messaging.Messages;

namespace FiddlerAmfParser.Flex.Messaging.Messages
{
    /// <summary>
    /// Extent FluorineFx MessageBase, and add IExternalizable method
    /// </summary>
    public class AbstractMessage : MessageBase
    {
        // Serialization constants
        protected const short HAS_NEXT_FLAG = 128;
        protected const short BODY_FLAG = 1;
        protected const short CLIENT_ID_FLAG = 2;
        protected const short DESTINATION_FLAG = 4;
        protected const short HEADERS_FLAG = 8;
        protected const short MESSAGE_ID_FLAG = 16;
        protected const short TIMESTAMP_FLAG = 32;
        protected const short TIME_TO_LIVE_FLAG = 64;
        protected const short CLIENT_ID_BYTES_FLAG = 1;
        protected const short MESSAGE_ID_BYTES_FLAG = 2;

        protected byte[] clientIdBytes;
        protected byte[] messageIdBytes;

        #region Message tracing

        static string[] IndentLevels = { "", "  ", "    ", "      ", "        ", "          " };
        internal static String GetIndent(int indentLevel)
        {
            if (indentLevel < IndentLevels.Length)
                return IndentLevels[indentLevel];
            StringBuilder sb = new StringBuilder();
            sb.Append(IndentLevels[IndentLevels.Length - 1]);
            indentLevel -= IndentLevels.Length - 1;
            for (int i = 0; i < indentLevel; i++)
                sb.Append("  ");
            return sb.ToString();
        }

        internal static String GetFieldSeparator(int indentLevel)
        {
            String indent = GetIndent(indentLevel);
            if (indentLevel > 0)
                indent = Environment.NewLine + indent;
            else
                indent = " ";
            return indent;
        }

        #endregion

        #region IExternalizable

        /**
         *
         * 
         * While this class itself does not implement java.io.Externalizable,
         * SmallMessage implementations will typically use Externalizable to
         * serialize themselves in a smaller form. This method supports this
         * functionality by implementing Externalizable.readExternal(ObjectInput) to
         * deserialize the properties for this abstract base class.
         */
        public void ReadExternal(IDataInput input)
        {
            short[] flagsArray = ReadFlags(input);

            for (int i = 0; i < flagsArray.Length; i++)
            {
                short flags = flagsArray[i];
                short reservedPosition = 0;

                if (i == 0)
                {
                    if ((flags & BODY_FLAG) != 0)
                        ReadExternalBody(input);
        
                    if ((flags & CLIENT_ID_FLAG) != 0)
                        clientId = input.ReadObject();
        
                    if ((flags & DESTINATION_FLAG) != 0)
                        destination = Convert.ToString(input.ReadObject());

                    if ((flags & HEADERS_FLAG) != 0)
                    {
                        //headers = (Map)input.ReadObject();
                        var instance = input.ReadObject();

                        if (instance is ASObject)
                        {
                            _headers = instance as ASObject;
                        }
                        else
                        {
                            Type type = instance.GetType();
                            PropertyInfo[] pArray = type.GetProperties();
                            MemberInfo[] mArray = type.GetMembers();
                            FieldInfo[] fArray = type.GetFields();
                            foreach (var p in pArray)
                            {
                                _headers.Add(p.Name, p.GetValue(instance, BindingFlags.DeclaredOnly | BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance, null, null, null));
                            }
                        }
                    }
                    
                    if ((flags & MESSAGE_ID_FLAG) != 0)
                        messageId = Convert.ToString(input.ReadObject());

                    if ((flags & TIMESTAMP_FLAG) != 0)
                        timestamp =  Convert.ToInt64(input.ReadObject());
        
                    if ((flags & TIME_TO_LIVE_FLAG) != 0)
                        timeToLive = Convert.ToInt64(input.ReadObject());

                    reservedPosition = 7;
                }
                else if (i == 1)
                {
                    if ((flags & CLIENT_ID_BYTES_FLAG) != 0)
                    {
                        var obj = input.ReadObject();
                        if (obj is ByteArray)
                        {
                            clientIdBytes = (obj as ByteArray).ToArray();
                        }
                        else
                        {
                            throw new InvalidCastException("AMF object is not ByteArray type cant convert to byte array.");
                        }
                        
                        clientId = new Guid(clientIdBytes).ToString();
                    }
        
                    if ((flags & MESSAGE_ID_BYTES_FLAG) != 0)
                    {
                        var obj = input.ReadObject();
                        if (obj is ByteArray)
                        {
                            messageIdBytes = (obj as ByteArray).ToArray();
                        }
                        else
                        {
                            throw new InvalidCastException("AMF object is not ByteArray type cant convert to byte array.");
                        }

                        messageId = new Guid(messageIdBytes).ToString();
                    } 

                    reservedPosition = 2;
                }

                // For forwards compatibility, read in any other flagged objects to
                // preserve the integrity of the input stream...
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

        /**
         *
         * 
         * While this class itself does not implement java.io.Externalizable,
         * SmallMessage implementations will typically use Externalizable to
         * serialize themselves in a smaller form. This method supports this
         * functionality by implementing Externalizable.writeExternal(ObjectOutput)
         * to efficiently serialize the properties for this abstract base class.
         */
        public void WriteExternal(IDataOutput output)
        {
            short flags = 0;

            if (clientIdBytes == null && clientId != null && clientId is string)
                clientIdBytes = new Guid((string)clientId).ToByteArray();

            if (messageIdBytes == null && messageId != null)
                messageIdBytes = new Guid(messageId).ToByteArray();

            if (body != null)
                flags |= BODY_FLAG;

            if (clientId != null && clientIdBytes == null)
                flags |= CLIENT_ID_FLAG;

            if (destination != null)
                flags |= DESTINATION_FLAG;

            if (headers != null)
                flags |= HEADERS_FLAG;

            if (messageId != null && messageIdBytes == null)
                flags |= MESSAGE_ID_FLAG;

            if (timestamp != 0)
                flags |= TIMESTAMP_FLAG;

            if (timeToLive != 0)
                flags |= TIME_TO_LIVE_FLAG;

            if (clientIdBytes != null || messageIdBytes != null)
                flags |= HAS_NEXT_FLAG;

            output.WriteByte((byte)flags);

            flags = 0;

            if (clientIdBytes != null)
                flags |= CLIENT_ID_BYTES_FLAG;

            if (messageIdBytes != null)
                flags |= MESSAGE_ID_BYTES_FLAG;

            if (flags != 0)
                output.WriteByte((byte)flags);

            if (body != null)
                WriteExternalBody(output);

            if (clientId != null && clientIdBytes == null)
                output.WriteObject(clientId);

            if (destination != null)
                output.WriteObject(destination);

            if (headers != null)
                output.WriteObject(headers);

            if (messageId != null && messageIdBytes == null)
                output.WriteObject(messageId);

            if (timestamp != 0)
                output.WriteObject(timestamp);

            if (timeToLive != 0)
                output.WriteObject(timeToLive);

            if (clientIdBytes != null)
                output.WriteObject(clientIdBytes);

            if (messageIdBytes != null)
                output.WriteObject(messageIdBytes);
        }

        /**
         *
         * Used by the readExtenral method to read the body.
         *  
         * @param input Object input.
         * @throws IOException
         * @throws ClassNotFoundException
         */
        protected void ReadExternalBody(IDataInput input)
        {
            body = input.ReadObject();
        }

        /**
         *
         * To support efficient serialization for SmallMessage implementations,
         * this utility method reads in the property flags from an ObjectInput
         * stream. Flags are read in one byte at a time. Flags make use of
         * sign-extension so that if the high-bit is set to 1 this indicates that
         * another set of flags follows.
         * 
         * @return The array of property flags. 
         */
        protected short[] ReadFlags(IDataInput input)
        {
            bool hasNextFlag = true;
            short[] flagsArray = new short[2];
            int i = 0;

            while (hasNextFlag)
            {
                short flags = (short)input.ReadUnsignedByte();
                if (i == flagsArray.Length)
                {
                    short[] tempArray = new short[i*2];
                    Array.Copy(flagsArray, tempArray, flagsArray.Length);
                    flagsArray = tempArray;
                }

                flagsArray[i] = flags;

                hasNextFlag = (flags & HAS_NEXT_FLAG) != 0;

                i++;
            }

            return flagsArray;
        }

        /**
         *
         * Used by writeExternal method to write the body.
         * 
         * @param output The object output.
         * @throws IOException
         */
        protected void WriteExternalBody(IDataOutput output)
        {
            output.WriteObject(_body);
        }

        #endregion

    }
}
