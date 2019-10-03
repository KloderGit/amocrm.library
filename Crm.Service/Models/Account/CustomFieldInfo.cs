using Newtonsoft.Json;
using System.Collections.Generic;

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
