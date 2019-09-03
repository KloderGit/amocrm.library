using Crm.Domain.Fields;
using System;
using System.Collections.Generic;

namespace Crm.Domain
{
    public class Company : IEntityId
    {
        public Int32 Id { get; set; }

        public Int32 ResponsibleUserId { get; set; }

        public Int32 CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = default;

        public DateTime UpdatedAt { get; set; } = default;

        public Int32 AccountId { get; set; }

        public Int32 GroupId { get; set; }

        public string Name { get; set; } = String.Empty;

        public DateTime ClosestTaskAt { get; set; } = default;

        public int UpdatedBy { get; set; }

        public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();

        public IEnumerable<Field> Fields { get; set; } = new List<Field>();

        public IEnumerable<Lead> Leads { get; set; } = new List<Lead>();

        public IEnumerable<Contact> Contacts { get; set; } = new List<Contact>();
    }
}