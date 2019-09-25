using amocrm.library.Models.Fields;
using System;
using System.Collections.Generic;
using System.Linq;

namespace amocrm.library.Models
{
    public class EntityMember : EntityCore
    {
        public string Name { get; set; } = String.Empty;

        public DateTime ClosestTaskAt { get; set; } = default;

        public List<SimpleObject> Tags { get; set; } = new List<SimpleObject>();

        public List<Field> Fields { get; set; } = new List<Field>();

        public Field GetField(int fieldId)
        {
            if (fieldId == 0 || this.Fields == null) return null;

            return this.Fields.FirstOrDefault(x => x.Id == fieldId);
        }

    }
}
