using System;

namespace Crm.Service.Models
{
    public class Note : IEntityId
    {
        public Int32 Id { get; set; }

        public Int32? ResponsibleUserId { get; set; }

        public Int32? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Int32? AccountId { get; set; }

        public Int32? GroupId { get; set; }

        public string Text { get; set; }

        public Int32? ElementId { get; set; }

        public int? ElementType { get; set; }

        public bool? IsEditable { get; set; }

        public string Attachment { get; set; }

        public int? NoteType { get; set; }
    }
}
