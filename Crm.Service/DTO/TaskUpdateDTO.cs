using amocrm.library.Interfaces;
using amocrm.library.Models;
using amocrm.library.Tools;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace amocrm.library.DTO
{
    [SelectDtoAttribute(typeof(Task), ActionEnum.Update )]
    public class TaskUpdateDTO : IValidate
    {
        [Required]
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "updated_at")]
        public int UpdatedAt { get; set; }

        [Required]
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "element_type")]
        public string ElementType { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty(PropertyName = "element_id")]
        public int ElementId { get; set; }

        [JsonProperty(PropertyName = "complete_till_at")]
        public int CompleteTillAt { get; set; }

        [JsonProperty(PropertyName = "is_completed")]
        public bool? IsCompleted { get; set; }

        [JsonProperty(PropertyName = "task_type")]
        public int TaskType { get; set; }

        [JsonProperty(PropertyName = "responsible_user_id")]
        public int ResponsibleUserId { get; set; }

        [JsonProperty(PropertyName = "created_by")]
        public int CreatedBy { get; set; }

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
}
