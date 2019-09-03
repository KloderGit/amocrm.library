using Crm.Domain.Fields;
using Crm.Domain.Parent;
using System;
using System.Collections.Generic;

namespace Crm.Domain
{
    public class Lead : EntityCore
    {
        public string Name { get; set; }

        public Int32? Status { get; set; }

        public Int32? Price { get; set; }

        public Int32? LossReason { get; set; }

        public DateTime? ClosestTaskAt { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? ClosedAt { get; set; }

        public List<Tag> Tags { get; set; }

        public List<Field> Fields { get; set; }

        public Company Company { get; set; }

        public List<Contact> Contacts { get; set; }

        public Contact MainContact { get; set; }

        public Pipeline Pipeline { get; set; }

        public Action<Lead> ChangeValueDelegate;

        public Lead GetChanges()
        {
            var leadWithChangedFields = new Lead();
            leadWithChangedFields.Id = this.Id;

            if (ChangeValueDelegate == null) throw new NullReferenceException($"Изменений в {this.GetType().Name} не было");

            ChangeValueDelegate.Invoke(leadWithChangedFields);

            return leadWithChangedFields;
        }
    }
}