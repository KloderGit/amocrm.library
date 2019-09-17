using amocrm.library.Converters;
using amocrm.library.Interfaces;
using amocrm.library.Models;
using amocrm.library.Tools;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace amocrm.library.DTO
{
    [SelectDtoAttribute(typeof(Company), ActionEnum.Update)]
    public class CompanyUpdateDTO : IValidate
    {
        [Required]
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

        [Required]
        [JsonProperty(PropertyName = "updated_at")]
        public int UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public string Tags { get; set; }

        [JsonProperty(PropertyName = "leads_id")]
        public List<int> Leads { get; set; }

        [JsonProperty(PropertyName = "customers_id")]
        public List<int> Customers { get; set; }

        [JsonProperty(PropertyName = "contacts_id")]
        public List<int> Contacts { get; set; }

        [JsonProperty(PropertyName = "custom_fields")]
        public List<CustomFieldsDto> CustomFields { get; set; }

        public bool Validate()
        {
            var results = new List<ValidationResult>();

            var context = new ValidationContext(this);

            if (!Validator.TryValidateObject(this, context, results, true))
            {
                throw new AmoCrmModelException(results);
            }

            return true;
        }
    }

    public class UnlinkFromCompany
    {
        [JsonProperty(PropertyName = "leads_id")]
        public List<int> Leads { get; set; }
        [JsonProperty(PropertyName = "customers_id")]
        public List<int> Customers { get; set; }
        [JsonProperty(PropertyName = "contacts_id")]
        public int Contacts { get; set; }
    }
}
