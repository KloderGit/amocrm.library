using amocrm.library.Models;
using amocrm.library.Tools;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace amocrm.library.DTO
{
    [SelectDtoAttribute(typeof(Lead), ActionEnum.Add)]
    internal class LeadAddDTO
    {
        [Required(ErrorMessage = "Lead Name field is required, but it has missed")]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "responsible_user_id")]
        public int ResponsibleUserId { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public int UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "pipeline_id")]
        public int PipelineId { get; set; }

        [JsonProperty(PropertyName = "status_id")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "sale")]
        public int Price { get; set; }

        [JsonProperty(PropertyName = "company")]
        public int Company { get; set; }
        
        [JsonProperty(PropertyName = "tags")]
        public string Tags { get; set; }

        [JsonProperty(PropertyName = "custom_fields")]
        public List<CustomFieldPostDto> CustomFields { get; set; }

        [JsonProperty(PropertyName = "contacts_id")]
        public List<int> Contacts { get; set; }
    }
}
