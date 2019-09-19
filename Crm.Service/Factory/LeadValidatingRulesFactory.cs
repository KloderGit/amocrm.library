using amocrm.library.Interfaces;
using amocrm.library.Models;
using amocrm.library.Tools;
using System;

namespace amocrm.library.Factory
{
    class LeadValidatingRulesFactory : IValidationRulesFactory<Lead>
    {
        public IValidateRules<Lead> CreateAdd()
        {
            var rules = new ValidateRules<Lead>();
            rules.AddRule(x => !String.IsNullOrEmpty(x.Name), "Name field can't be empty");

            return rules;
        }

        public IValidateRules<Lead> CreateUpdate()
        {
            var rules = new ValidateRules<Lead>();
            rules.AddRule(x => x.Id != 0, "Id field must have a value");
            rules.AddRule(x => x.UpdatedAt != DateTime.MinValue, "UpdatedAt field must have a set");

            return rules;
        }
    }
}
