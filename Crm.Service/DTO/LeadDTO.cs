using amocrm.library.Tools;
using Crm.Service.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.DTO
{
    [ParentForDtoAttribute(typeof(Lead))]
    public class LeadDTO
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

        [JsonProperty(PropertyName = "pipeline_id")]
        public int PipelineId { get; set; }

        [JsonProperty(PropertyName = "status_id")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "is_deleted")]
        public bool? IsDeleted { get; set; }

        [JsonProperty(PropertyName = "group_id")]
        public int GroupId { get; set; }

        [JsonProperty(PropertyName = "closed_at")]
        public int ClosedAt { get; set; }

        [JsonProperty(PropertyName = "closest_task_at")]
        public int ClosestTaskAt { get; set; }

        [JsonProperty(PropertyName = "sale")]
        public int Price { get; set; }

        [JsonProperty(PropertyName = "loss_reason_id")]
        public int LossReason { get; set; }


        [JsonProperty(PropertyName = "pipeline")]
        public PipelineField Pipeline { get; set; }

        [JsonProperty(PropertyName = "main_contact")]
        public MainContactField MainContact { get; set; }

        [JsonProperty(PropertyName = "company")]
        public CompanyField Company { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public List<TagDto> Tags { get; set; }

        [JsonProperty(PropertyName = "CustomFields")]
        public List<CustomFieldsDto> CustomFields { get; set; } = new List<CustomFieldsDto>();

        [JsonProperty(PropertyName = "contacts")]
        public ContactsField Contacts { get; set; }
    }

    public class MainContactField
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }

    public class ContactsField
    {
        [JsonProperty(PropertyName = "id")]
        public List<int> Id { get; set; }
    }

    public class PipelineField
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }


}
