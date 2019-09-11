
using amocrm.library.Converters;
using amocrm.library.Models;
using amocrm.library.Tools;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace amocrm.library.DTO
{
    [ParentForDtoAttribute(typeof(Contact))]
    public class ContactDTO
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "responsible_user_id")]
        public int ResponsibleUserId { get; set; }

        [JsonProperty(PropertyName = "created_by")]
        public int CreatedBy { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public int UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "account_id")]
        public int AccountId { get; set; }

        [JsonProperty(PropertyName = "updated_by")]
        public int UpdatedBy { get; set; }

        [JsonProperty(PropertyName = "group_id")]
        public int GroupId { get; set; }

        [JsonProperty(PropertyName = "closest_task_at")]
        public int ClosestTaskAt { get; set; }


        [JsonConverter(typeof(ObjectOrNullJsonConverter))]
        [JsonProperty(PropertyName = "company")]
        public SimpleDtoObject Company { get; set; }

        [JsonConverter(typeof(ObjectOrNullJsonConverter))]
        [JsonProperty(PropertyName = "customers")]
        public LinkedDataList Customers { get; set; }

        [JsonConverter(typeof(ObjectOrNullJsonConverter))]
        [JsonProperty(PropertyName = "leads")]
        public LinkedDataList Leads { get; set; }

        [JsonConverter(typeof(ObjectOrArrayJsonConverter<SimpleDtoObject>))]
        [JsonProperty(PropertyName = "tags")]
        public List<SimpleDtoObject> Tags { get; set; }

        [JsonConverter(typeof(ObjectOrArrayJsonConverter<CustomFieldsDto>))]
        [JsonProperty(PropertyName = "custom_fields")]
        public List<CustomFieldsDto> CustomFields { get; set; }
    }
}
