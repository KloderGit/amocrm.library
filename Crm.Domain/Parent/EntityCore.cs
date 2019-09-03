using System;

namespace Crm.Domain.Parent
{
    public class EntityCore : IEntityId
    {
        public Int32 Id { get; set; }

        public Int32 ResponsibleUserId { get; set; }

        public Int32 CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = default;

        public DateTime UpdatedAt { get; set; } = default;

        public Int32 AccountId { get; set; }

        public Int32 GroupId { get; set; }
    }
}
