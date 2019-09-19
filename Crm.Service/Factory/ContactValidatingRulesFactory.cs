﻿using amocrm.library.Interfaces;
using amocrm.library.Models;
using amocrm.library.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.Factory
{
    public class ContactValidatingRulesFactory : IValidationRulesFactory<Contact>
    {
        public IValidateRules<Contact> CreateAdd()
        {
            var rules = new ValidateRules<Contact>();
            rules.AddRule(x => !String.IsNullOrEmpty(x.Name));

            return rules;
        }

        public IValidateRules<Contact> CreateUpdate()
        {
            var rules = new ValidateRules<Contact>();
            rules.AddRule(x => x.Id != 0);
            rules.AddRule(x => x.UpdatedAt != DateTime.MinValue);

            return rules;
        }
    }
}