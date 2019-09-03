using Crm.Domain.Fields;
using System;

namespace Crm.Domain
{
    public class Task : IEntityId
    {
        public Int32 Id { get; set; }

        public Int32? ResponsibleUserId { get; set; }

        public Int32? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Int32? AccountId { get; set; }

        public Int32? GroupId { get; set; }

        public bool? IsCompleted { get; set; }

        public DateTime? CompleteTillAt { get; set; }

        public int? TaskType { get; set; }

        public string Text { get; set; }

        public Int32? ElementId { get; set; }

        public int? ElementType { get; set; }

        public Result Result { get; set; }
    }
}
