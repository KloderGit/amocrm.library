using amocrm.library.Interfaces;
using amocrm.library.Models.Fields;
using System;
using System.Collections.Generic;

namespace amocrm.library.Models
{
    public class Lead : EntityMember, IValidate<Lead>
    {
        public int Status { get; set; }

        public int Price { get; set; }

        public int LossReason { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime ClosedAt { get; set; } = default;

        public int PipelineId { get; set; }

        public SimpleObject Company { get; set; }

        public List<int> Contacts { get; set; } = new List<int>();

        public int MainContact { get; set; }

        public int Pipeline { get; set; }

        public bool Validate(IValidateRules<Lead> validateRules)
        {
            return validateRules.ValidateBool(this);
        }
    }
}