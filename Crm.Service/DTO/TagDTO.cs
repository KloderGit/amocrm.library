using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.DTO
{
    public class TagDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
