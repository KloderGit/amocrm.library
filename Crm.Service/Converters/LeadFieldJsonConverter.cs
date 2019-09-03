
using Crm.Service.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Crm.Service.Converters
{
    internal class LeadFieldJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            IEnumerable<string> result = ((List<Lead>)value).Select(y => y.Id.ToString());

            serializer.Serialize(writer, result);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object result = new Object();

            LeadField instance = (LeadField)serializer.Deserialize(reader, typeof(LeadField));

            if (instance?.IDs == null) { result = null; }
            else { result = instance.IDs.Select(x => new Lead { Id = x }); }

            return result;
        }

        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }

    internal class LeadField
    {
        public IEnumerable<int> IDs { get; set; }
    }
}
