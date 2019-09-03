using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.DTO
{
    public class Values
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "_enum")]
        public int @Enum { get; set; }
    }
}
