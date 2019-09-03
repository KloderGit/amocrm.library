
using amocrm.library.DTO;
using amocrm.library.Tools;
using Crm.Service.Converters;
using Crm.Service.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Crm.Service.DTO
{
    [ParentForDtoAttribute(typeof(Contact))]
    public class ContactDTO
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = String.Empty;

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

        [JsonProperty(PropertyName = "company")]
        public CompanyField Company { get; set; }

        [JsonProperty(PropertyName = "customers")]
        public Customers Customers { get; set; }

        [JsonProperty(PropertyName = "leads")]
        public LeadsDto Leads { get; set; }

        [JsonConverter(typeof(ObjectOrArrayJsonConverter<TagDto>))]
        [JsonProperty(PropertyName = "tags")]
        public List<TagDto> Tags { get; set; } = new List<TagDto>();
        [JsonConverter(typeof(ObjectOrArrayJsonConverter<CustomFieldsDto>))]
        [JsonProperty(PropertyName = "custom_fields")]
        public List<CustomFieldsDto> CustomFields { get; set; } = new List<CustomFieldsDto>();
    }

    public class LeadsDto
    {
        public List<int> id { get; set; } = new List<int>();
    }

    public class Customers
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
