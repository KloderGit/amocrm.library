using amocrm.library.Interfaces;
using amocrm.library.Models;
using amocrm.library.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.Factory
{
    internal class ContactValidatingRulesFactory : IValidationRulesFactory<Contact>
    {
        public IValidateRules<Contact> CreateAdd()
        {
            var rules = new ValidateRules<Contact>();
            rules.AddRule(x => !String.IsNullOrEmpty(x.Name), "Name field can't be empty");

            return rules;
        }

        public IValidateRules<Contact> CreateUpdate()
        {
            var rules = new ValidateRules<Contact>();
            rules.AddRule(x => x.Id != 0, "Id field must have a value");
            rules.AddRule(x => x.UpdatedAt != DateTime.MinValue, "UpdatedAt field must be set");

            return rules;
        }
    }
}
