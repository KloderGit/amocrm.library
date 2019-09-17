using amocrm.library.Configurations;

namespace amocrm.library.Models
{
    public class Note : EntityCore
    {
        public string Text { get; set; } = string.Empty;
        public int ElementId { get; set; }
        public ElementTypeEnum ElementType { get; set; }
        public bool? IsEditable { get; set; }
        public string Attachment { get; set; }
        public int NoteType { get; set; }
        public Params @Params { get; set; }
    }

    public class Params
    {
        public string Text { get; set; }
        public string Service { get; set; }
    }
}
