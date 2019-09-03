using System;
using System.Collections.Generic;

namespace Crm.Service.Models
{
    public class EntityMember : EntityCore
    {
        public string Name { get; set; } = String.Empty;

        public DateTime ClosestTaskAt { get; set; } = default;

        public List<Tag> Tags { get; set; } = new List<Tag>();

        public List<Field> Fields { get; set; } = new List<Field>();
    }
}
