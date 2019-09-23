using amocrm.library.Models;
using amocrm.library.Tools;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace amocrm.library.DTO
{
    [SelectDtoAttribute(typeof(Note), ActionEnum.Update)]
    internal class NoteUpdateDTO
    {
        [Required]
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "element_id")]
        public int ElementId { get; set; }

        [JsonProperty(PropertyName = "element_type")]
        public string ElementType { get; set; }

        [JsonProperty(PropertyName = "note_type")]
        public int NoteType { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public int CreatedAt { get; set; }

        [Required]
        [JsonProperty(PropertyName = "updated_at")]
        public int UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "created_by")]
        public int CreatedBy { get; set; }

        [JsonProperty(PropertyName = "responsible_user_id")]
        public int ResponsibleUserId { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}
