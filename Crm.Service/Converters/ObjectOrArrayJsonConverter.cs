using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace amocrm.library.Converters
{
    internal class ObjectOrArrayJsonConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jToken = (JToken)serializer.Deserialize(reader, typeof(object));

            if (jToken == null || !jToken.HasValues) return null;

            return jToken.ToObject(objectType);
        }

        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
}
