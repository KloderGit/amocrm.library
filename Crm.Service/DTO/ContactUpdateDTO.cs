using amocrm.library.Models;
using amocrm.library.Tools;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace amocrm.library.DTO
{
    [SelectDtoAttribute(typeof(Contact), ActionEnum.Update)]
    public class ContactUpdateDTO
    {
        [Required]
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "updated_at")]
        public int UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty(PropertyName = "created_by")]
        public int CreatedBy { get; set; }

        [JsonProperty(PropertyName = "responsible_user_id")]
        public int ResponsibleUserId { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public string Tags { get; set; }

        [JsonProperty(PropertyName = "company_name")]
        public string CompanyName { get; set; }

        [JsonProperty(PropertyName = "company_id")]
        public int CompanyId { get; set; }

        [JsonProperty(PropertyName = "leads_id")]
        public List<int> Leads { get; set; }

        [JsonProperty(PropertyName = "customers_id")]
        public List<int> Customers { get; set; }

        [JsonProperty(PropertyName = "custom_fields")]
        public List<CustomFieldsDto> CustomFields { get; set; }
    }

    public class UnlinkFromContact
    {
        [JsonProperty(PropertyName = "leads_id")]
        public List<int> Leads { get; set; }
        [JsonProperty(PropertyName = "customers_id")]
        public List<int> Customers { get; set; }
        [JsonProperty(PropertyName = "company_id")]
        public int Company { get; set; }
    }
}
