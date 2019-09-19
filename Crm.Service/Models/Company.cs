using amocrm.library.Interfaces;
using amocrm.library.Models.Fields;
using System;
using System.Collections.Generic;

namespace amocrm.library.Models
{
    public class Company : EntityMember, IValidate<Company>
    {
        public int UpdatedBy { get; set; }
        public IEnumerable<int> Leads { get; set; } = new List<int>();
        public IEnumerable<int> Contacts { get; set; } = new List<int>();
        public IEnumerable<int> Customers { get; set; } = new List<int>();

        public bool Validate(IValidateRules<Company> validateRules)
        {
            return validateRules.Validate(this);
        }
    }
}