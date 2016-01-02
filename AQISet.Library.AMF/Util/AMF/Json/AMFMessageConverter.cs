using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FluorineFx;
using FluorineFx.AMF3;
using FluorineFx.IO;
using FluorineFx.Messaging.Messages;
using Newtonsoft.Json;

namespace AQI.Util.AMF.Json
{
    public class AMFMessageConverter : JsonConverter 
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (typeof (AMFMessage).IsAssignableFrom(objectType))
            {
                return ReadMessage(reader, objectType, existingValue, serializer);
                
            }
            if (typeof(AMFBody).IsAssignableFrom(objectType))
            {
                return ReadBody(reader, objectType, existingValue, serializer);
            }
            if (typeof(MessageBase).IsAssignableFrom(objectType))
            {
                return ReadMessaging(reader, objectType, existingValue, serializer);
            }
            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(AMFMessage).IsAssignableFrom(objectType) ||
                typeof(AMFBody).IsAssignableFrom(objectType) ||
                typeof(MessageBase).IsAssignableFrom(objectType);  
        }


        private AMFMessage ReadMessage(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartObject)
                throw new JsonReaderException("AMFMessage must be a JSON Object");

            AMFMessage message = new AMFMessage();

            for (reader.Read(); reader.TokenType != JsonToken.EndObject; reader.Read())
            {
                if (reader.TokenType != JsonToken.PropertyName)
                    throw new JsonReaderException("JSON format error, JSON Object must have property");

                string propertyName = (string)reader.Value;
                switch (propertyName)
                {
                    case "Version":
                        reader.Read();
                        if (reader.TokenType != JsonToken.Integer)
                            throw new JsonReaderException("AMFMessage 'Version' must be JSON Number");
                        message = new AMFMessage(Convert.ToUInt16(reader.Value));
                        break;
                    case "Bodies":
                        reader.Read();
                        if (reader.TokenType != JsonToken.StartArray)
                            throw new JsonReaderException("AMFMessage 'Bodies' must be JSON Array");
                        for (reader.Read(); reader.TokenType != JsonToken.EndArray; reader.Read())
                        {
                            AMFBody body = serializer.Deserialize<AMFBody>(reader);
                            message.AddBody(body);
                        }
                        break;
                    default:
                        throw new NotSupportedException("AMFMessage dont support property " + propertyName + ", please report this");
                        break;
                }
            }
            return message;
        }

        private AMFBody ReadBody(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartObject)
                throw new JsonReaderException("AMFBody must be a JSON Object");

            AMFBody body = new AMFBody();

            for (reader.Read(); reader.TokenType != JsonToken.EndObject; reader.Read())
            {
                if (reader.TokenType != JsonToken.PropertyName)
                    throw new JsonReaderException("JSON format error, JSON Object must have property");

                string propertyName = (string)reader.Value;
                switch (propertyName)
                {
                    case "Target":
                        reader.Read();
                        if (reader.TokenType != JsonToken.String)
                            throw new JsonReaderException("AMFBody 'Target' must be JSON String");
                        body.Target = (string) reader.Value;
                        break;
                    case "Response":
                        reader.Read();
                        if (reader.TokenType != JsonToken.String)
                            throw new JsonReaderException("AMFBody 'Response' must be JSON String");
                        body.Response = (string)reader.Value;
                        break;
                    case "Content":
                        reader.Read();
                        if (reader.TokenType != JsonToken.StartArray)
                            throw new JsonReaderException("AMFBody 'Response' must be JSON String");

                        List<MessageBase> list = new List<MessageBase>();
                        for (reader.Read(); reader.TokenType != JsonToken.EndArray; reader.Read())
                        {
                            MessageBase ds = serializer.Deserialize<MessageBase>(reader);
                            list.Add(ds);
                        }
                        body.Content = list;
                        break;
                    default:
                        throw new NotSupportedException("AMFBody dont support property " + propertyName + ", please report this");
                        break;
                }
            }
            return body;
        }

        private MessageBase ReadMessaging(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartObject)
                throw new JsonReaderException("Messaging Message must be a JSON Object");

            MessageBase msg = new MessageBase();

            for (reader.Read(); reader.TokenType != JsonToken.EndObject; reader.Read())
            {
                if (reader.TokenType != JsonToken.PropertyName)
                    throw new JsonReaderException("JSON format error, JSON Object must have property");

                string propertyName = (string)reader.Value;
                switch (propertyName)
                {
                    case "destination":
                        reader.Read();
                        if (reader.TokenType != JsonToken.String)
                            throw new JsonReaderException("Messaging Message 'destination' must be JSON String");
                        msg.destination = (string)reader.Value;
                        break;
                    case "messageId":
                         reader.Read();
                         if (reader.TokenType != JsonToken.String)
                             throw new JsonReaderException("Messaging Message 'messageId' must be JSON String");
                         msg.messageId = (string)reader.Value;
                        break;
                    case "timestamp":
                        reader.Read();
                        if (reader.TokenType != JsonToken.Integer)
                            throw new JsonReaderException("Messaging Message 'timestamp' must be JSON Number");
                        msg.timestamp = (long)reader.Value;
                        break;
                    case "timeToLive":
                        reader.Read();
                        if (reader.TokenType != JsonToken.Integer)
                            throw new JsonReaderException("Messaging Message 'timeToLive' must be JSON Number");
                        msg.timeToLive = (long)reader.Value;
                        break;
                    case "headers":
                        reader.Read();
                        if (reader.TokenType != JsonToken.StartObject)
                            throw new JsonReaderException("Messaging Message headers must be object");
                        Dictionary<string, object> h = serializer.Deserialize<Dictionary<string, object>>(reader);
                        msg.headers = h;
                        break;
                    case "clientId":
                        reader.Read();
                        //cant definite clientId just a GUID string  
                        switch (reader.TokenType)
                        {
                            case JsonToken.String:
                                Guid guid = new Guid();
                                if (Guid.TryParse((string)reader.Value, out guid))
                                {
                                    msg.clientId = reader.Value;
                                }
                                else
                                {
                                    //maybe not appear
                                    ByteArray array = new ByteArray();
                                    byte[] bytes = Encoding.Default.GetBytes((string)reader.Value);
                                    array.WriteBytes(bytes, 0, bytes.Length);
                                    msg.clientId = array;
                                }
                                break;
                            case JsonToken.Null:
                                msg.clientId = reader.Value;
                                break;
                            default:
                                throw new NotSupportedException("Messaging Message clientId only support GUID JSON String, please report this");
                                break;
                        }

                        break;
                    case "body":
                        reader.Read();
                        switch (reader.TokenType)
                        {
                            case JsonToken.StartArray:
                                ArrayList list = new ArrayList();
                                for (reader.Read(); reader.TokenType != JsonToken.EndArray; reader.Read())
                                {
                                    switch (reader.TokenType)
                                    {
                                        case JsonToken.Null:
                                        case JsonToken.Boolean:
                                        case JsonToken.Integer:
                                        case JsonToken.Float:
                                        case JsonToken.String:
                                            list.Add(reader.Value);
                                            break;
                                        default:
                                            throw new NotSupportedException("Messaging Message body[] only support JSON Boolean/Number/String, please report this");
                                    }
                                }
                                msg.body = list.ToArray();
                                break;
                            case JsonToken.StartObject:
                                reader.Read();
                                if (reader.TokenType != JsonToken.EndObject)
                                    throw new NotSupportedException("Messaging Message body{} only support Empty JSON Object, please report this");
                                msg.body = new ASObject();
                                break;
                            default:
                                throw new NotSupportedException("Messaging Message body only support JSON Array/Object, please report this");
                                break;
                        }
                        break;

                }
            }
            return msg;
        }
    }
}
