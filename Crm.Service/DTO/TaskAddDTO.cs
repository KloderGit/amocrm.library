using amocrm.library.Models;
using amocrm.library.Tools;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace amocrm.library.DTO
{
    [SelectDtoAttribute(typeof(Task), ActionEnum.Add )]
    public class TaskAddDTO
    {
        [Required]
        [JsonProperty(PropertyName = "element_id")]
        public int ElementId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "element_type")]
        public int ElementType { get; set; }

        [Required]
        [JsonProperty(PropertyName = "complete_till_at")]
        public int CompleteTillAt { get; set; }

        [Required]
        [JsonProperty(PropertyName = "task_type")]
        public int TaskType { get; set; }

        [Required]
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public int UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "is_completed")]
        public bool? IsCompleted { get; set; }

        [JsonProperty(PropertyName = "responsible_user_id")]
        public int ResponsibleUserId { get; set; }

        [JsonProperty(PropertyName = "created_by")]
        public int CreatedBy { get; set; }
    }
}
