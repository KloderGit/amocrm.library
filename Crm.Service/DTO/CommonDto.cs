using Newtonsoft.Json;
using System.Collections.Generic;

namespace amocrm.library.DTO
{

    internal class LinkedDataList
    {
        [JsonProperty(PropertyName = "id")]
        public List<int> Id { get; set; }
    }

    internal class SimpleDtoObject
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    internal class CustomFieldsDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "values")]
        public List<Values> Values { get; set; }

        [JsonProperty(PropertyName = "is_system")]
        public bool? IsSystem { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
    }

    internal class Values
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "enum")]
        public int @Enum { get; set; }
    }
}
