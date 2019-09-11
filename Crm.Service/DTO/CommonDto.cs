using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.DTO
{

    public class LinkedDataList
    {
        [JsonProperty(PropertyName = "id")]
        public List<int> Id { get; set; }
    }

    public class SimpleDtoObject
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    public class CustomFieldsDto
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

    public class Values
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "_enum")]
        public int @Enum { get; set; }
    }
}
