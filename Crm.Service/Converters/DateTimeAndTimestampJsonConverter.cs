using Newtonsoft.Json;
using System;

namespace Crm.Service.Converters
{
    internal class DateTimeAndTimestampJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var date = ((DateTime)value).ToUniversalTime();
            long unixTime = ((DateTimeOffset)date).ToUnixTimeSeconds();

            if ((DateTime)value == DateTime.MinValue) unixTime = 0;

            serializer.Serialize(writer, unixTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.Integer)
            {
                throw new Exception(
                    String.Format("Ожидается Integer а пришло {0}.",
                    reader.TokenType));
            }

            long ticks = (long)reader.Value;

            if (ticks <= 0) return DateTime.MinValue;

            var startDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return startDate.AddSeconds(ticks).ToLocalTime();
        }

        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
}
