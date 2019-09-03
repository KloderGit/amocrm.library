using Crm.Domain;
using Crm.Service.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Service.DTO
{
    public class ParentAttribute : Attribute
    {
        public Type Master { get; set; }
        public ParentAttribute()
        { }
        public ParentAttribute(Type type)
        {
            Master = type;
        }
    }

    [Parent(typeof(Contact))]
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
        public Company Company { get; set; }

        [JsonProperty(PropertyName = "customers")]
        public Customers Customers { get; set; }

        [JsonProperty(PropertyName = "leads")]
        public Leads Leads { get; set; }

        [JsonConverter(typeof(ObjectOrArrayJsonConverter<Tag>))]
        [JsonProperty(PropertyName = "tags")]
        public List<Tag> Tags { get; set; } = new List<Tag>();
        [JsonConverter(typeof(ObjectOrArrayJsonConverter<Custom_Fields>))]
        [JsonProperty(PropertyName = "custom_fields")]
        public List<Custom_Fields> CustomFields { get; set; } = new List<Custom_Fields>();
    }

    public class Company
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    public class Leads
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

    public class Tag
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    public class Custom_Fields
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "values")]
        public Values[] Values { get; set; }

        [JsonProperty(PropertyName = "is_system")]
        public bool? isSystem { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
    }

    public class Values
    {
        [JsonProperty(PropertyName = "value")]
        public string @Value { get; set; }

        [JsonProperty(PropertyName = "_enum")]
        public int @Enum { get; set; }
    }

}
