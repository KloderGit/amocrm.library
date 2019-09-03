using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Service.Converters
{
    internal class ObjectOrArrayJsonConverter<T> : JsonConverter 
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var obj = (List<T>)value;

            if (obj.Count == 0)
            {
                serializer.Serialize(writer, new { });
            }
            else
            {
                serializer.Serialize(writer, value);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object retVal = new Object();

            if (reader.TokenType == JsonToken.StartObject)
            {
                object instance = serializer.Deserialize(reader, typeof(object));

                retVal = new List<T>();
            }
            else if (reader.TokenType == JsonToken.StartArray)
            {
                retVal = serializer.Deserialize(reader, objectType);
            }
            return retVal;
        }

        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
}
