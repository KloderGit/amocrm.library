using amocrm.library.Models.Fields;
using System;
using System.Collections.Generic;

namespace amocrm.library.Models
{
    public class EntityMember : EntityCore
    {
        public string Name { get; set; } = String.Empty;

        public DateTime ClosestTaskAt { get; set; } = default;

        public List<SimpleObject> Tags { get; set; } = new List<SimpleObject>();

        public List<Field> Fields { get; set; } = new List<Field>();
    }
}
