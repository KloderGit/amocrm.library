using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace amocrm.library.Models.Account
{
    public class CustomFieldInfo
    {
        [JsonProperty(PropertyName = "contacts")]
        public Dictionary<int, FieldInfo> Contact { get; set; }

        [JsonProperty(PropertyName = "leads")]
        public Dictionary<int, FieldInfo> Lead { get; set; }

        [JsonProperty(PropertyName = "companies")]
        public Dictionary<int, FieldInfo> Company { get; set; }

        //[JsonProperty(PropertyName = "customers")]
        //public Dictionary<int, FieldInfo> Customer { get; set; }

        [JsonProperty(PropertyName = "catalogs")]
        Dictionary<int, Dictionary<int, FieldInfo>> Catalog { get; set; }

        public object FindFildType(int id)
        {
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();

            foreach (var cont in Contact)
            {
                if(!keyValuePairs.ContainsKey(cont.Key)) keyValuePairs.Add(cont.Key, cont.Value.FieldType);
            }

            foreach (var comp in Company)
            {
                if (!keyValuePairs.ContainsKey(comp.Key)) keyValuePairs.Add(comp.Key, comp.Value.FieldType);
            }
            foreach (var led in Lead)
            {
                if (!keyValuePairs.ContainsKey(led.Key)) keyValuePairs.Add(led.Key, led.Value.FieldType);
            }

            int result;
            var getValue = keyValuePairs.TryGetValue(id, out result);

            return result;
        }
    }

    public class FieldInfo
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "field_type")]
        public int FieldType { get; set; }
        [JsonProperty(PropertyName = "sort")]
        public int Sort { get; set; }
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
        [JsonProperty(PropertyName = "is_multiple")]
        public bool IsMultiple { get; set; }
        [JsonProperty(PropertyName = "is_system")]
        public bool IsSystem { get; set; }
        [JsonProperty(PropertyName = "is_editable")]
        public bool IsEditable { get; set; }
        [JsonProperty(PropertyName = "is_required")]
        public bool IsRequired { get; set; }
        [JsonProperty(PropertyName = "is_deletable")]
        public bool IsDeletable { get; set; }
        [JsonProperty(PropertyName = "is_visible")]
        public bool IsVisible { get; set; }
        [JsonProperty(PropertyName = "params")]
        public object @Params { get; set; }
        [JsonProperty(PropertyName = "enums")]
        public Dictionary<int, string> @Enums { get; set; }
    }
}
