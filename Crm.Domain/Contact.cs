using Crm.Domain.Fields;
using Crm.Domain.Parent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Crm.Domain
{
    public class Contact : EntityMember
    {
        public int UpdatedBy { get; set; }

        public List<Lead> Leads { get; set; } = new List<Lead>();

        public Company Company { get; set; }

        public Action<Contact> ChangeValueDelegate;

        public Contact GetChanges()
        {
            var contactWithChangedFields = new Contact();
            contactWithChangedFields.Id = this.Id;

            if (ChangeValueDelegate == null) throw new NullReferenceException($"Изменений в {this.GetType().Name} не было");

            ChangeValueDelegate.Invoke(contactWithChangedFields);

            return contactWithChangedFields;
        }

        public void SetGuid(string value)
        {
            if (String.IsNullOrEmpty(value)) return;

            Fields = Fields ?? new List<Field>();
            if (!Fields.Any(x => x.Id == 571611)) Fields.Add( new Field { Id = 571611 } );

            Fields.FirstOrDefault(x => x.Id == 571611).Values = new List<FieldValue> { new FieldValue { Value = value } };
        }


    }
}