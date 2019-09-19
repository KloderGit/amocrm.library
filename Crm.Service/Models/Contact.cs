using amocrm.library.Interfaces;
using amocrm.library.Models.Fields;
using System.Collections.Generic;

namespace amocrm.library.Models
{
    public class Contact : EntityMember, IValidate<Contact>
    {
        public int UpdatedBy { get; set; }

        public IEnumerable<int> Leads { get; set; } = new List<int>();

        public SimpleObject Company { get; set; }

        public IEnumerable<int> Customers { get; set; } = new List<int>();

        public bool Validate(IValidateRules<Contact> validateRules)
        {
            return validateRules.ValidateBool(this);
        }
    }
}