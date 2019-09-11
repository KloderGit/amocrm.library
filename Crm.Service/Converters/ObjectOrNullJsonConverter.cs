using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace amocrm.library.Converters
{
    public class ObjectOrNullJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var instance = (JToken)serializer.Deserialize(reader, typeof(object));

            if (instance == null || !instance.HasValues) return null;

            return instance.ToObject(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                serializer.Serialize(writer, new { });
            }
            else
            {
                serializer.Serialize(writer, value);
            }
        }
    }
}
