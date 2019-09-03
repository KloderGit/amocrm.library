using amocrm.library.Models.Fields;
using System;
using System.Collections.Generic;

namespace Crm.Service.Models
{
    public class Lead : EntityCore
    {
        public string Name { get; set; }

        public int Status { get; set; }

        public int Price { get; set; }

        public int LossReason { get; set; }

        public DateTime ClosestTaskAt { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime ClosedAt { get; set; }

        public List<SimpleObject> Tags { get; set; }

        public List<Field> Fields { get; set; }

        public SimpleObject Company { get; set; }

        public IdArray Contacts { get; set; }

        public IdSingle MainContact { get; set; }

        public IdSingle Pipeline { get; set; }

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