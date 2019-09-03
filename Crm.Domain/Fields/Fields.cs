using System;
using System.Collections.Generic;

namespace Crm.Domain.Fields
{
    public class Field
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public List<FieldValue> Values { get; set; } = new List<FieldValue>();

        public bool? IsSystem { get; set; }
    }

    public class FieldValue
    {
        public string Value { get; set; } = String.Empty;

        public Int32 @Enum { get; set; }
    }
}
