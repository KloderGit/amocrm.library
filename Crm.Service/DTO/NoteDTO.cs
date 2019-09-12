using amocrm.library.Models;
using amocrm.library.Tools;
using Newtonsoft.Json;

namespace amocrm.library.DTO
{
    [ParentForDtoAttribute(typeof(Note))]
    public class NoteDTO
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

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

        [JsonProperty(PropertyName = "group_id")]
        public int GroupId { get; set; }

        [JsonProperty(PropertyName = "is_editable")]
        public bool? IsEditable { get; set; }

        [JsonProperty(PropertyName = "element_id")]
        public int ElementId { get; set; }

        [JsonProperty(PropertyName = "element_type")]
        public int ElementType { get; set; }

        [JsonProperty(PropertyName = "attachment")]
        public string Attachment { get; set; }

        [JsonProperty(PropertyName = "note_type")]
        public int NoteType { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "params")]
        public ParamDTO @Params { get; set; }
    }

    public class Params2
    {
        public int STATUS_NEW { get; set; }
        public int STATUS_OLD { get; set; }
        public string TEXT { get; set; }
        public int PIPELINE_ID_OLD { get; set; }
        public int PIPELINE_ID_NEW { get; set; }
        public int LOSS_REASON_ID { get; set; }
    }

    public class ParamDTO
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        //public string HTML { get; set; }

        [JsonProperty(PropertyName = "service")]
        public string Service { get; set; }
        //public string phone { get; set; }        
    }

}
