using amocrm.library.Configurations;
using amocrm.library.Interfaces;
using amocrm.library.Models.Fields;
using System;
using System.Collections.Generic;
using System.Linq;

namespace amocrm.library.Models
{
    public class EntityMember : EntityCore, ICustomField
    {
        public string Name { get; set; } = String.Empty;

        public DateTime ClosestTaskAt { get; set; } = default;

        public List<SimpleObject> Tags { get; set; } = new List<SimpleObject>();

        public List<Field> Fields { get; set; } = new List<Field>();

        public virtual Field GetField(int fieldId)
        {
            if (fieldId == 0 || this.Fields == null) return null;

            return this.Fields.FirstOrDefault(x => x.Id == fieldId);
        }

        public virtual void SetField(int fieldId, string value, int @enum = 0, bool add = false)
        {
            var array = InitFieldsArray();
            var currentField = InitCurrentField(fieldId);
            var values = add ? InitValuesOfField(currentField) : currentField.Values = new List<FieldValue>();

            values.Add(new FieldValue { Enum = @enum, Value = value });
        }

        protected virtual List<Field> InitFieldsArray()
        {
            return this.Fields = this.Fields ?? new List<Field>();
        }

        protected virtual Field InitCurrentField(int type)
        {
            if (!this.Fields.Any(fl => fl.Id == type))
                this.Fields.Add(new Field { Id = type });
            return this.Fields.First(x => x.Id == type);
        }

        protected virtual List<FieldValue> InitValuesOfField(Field field)
        {
            return field.Values ?? new List<FieldValue>();
        }

    }
}
