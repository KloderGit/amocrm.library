using amocrm.library.Interfaces;
using amocrm.library.Models;
using amocrm.library.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.Factory
{
    public class CompanyValidatingRulesFactory : IValidationRulesFactory<Company>
    {
        public IValidateRules<Company> CreateAdd()
        {
            var rules = new ValidateRules<Company>();
            rules.AddRule(x => !String.IsNullOrEmpty(x.Name));

            return rules;
        }

        public IValidateRules<Company> CreateUpdate()
        {
            var rules = new ValidateRules<Company>();
            rules.AddRule(x => x.Id != 0);
            rules.AddRule(x => x.UpdatedAt != DateTime.MinValue);

            return rules;
        }
    }
}
