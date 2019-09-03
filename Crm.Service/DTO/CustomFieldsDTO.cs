using Newtonsoft.Json;
using System.Collections.Generic;

namespace amocrm.library.DTO
{
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
}
