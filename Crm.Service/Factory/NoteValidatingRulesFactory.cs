using amocrm.library.Interfaces;
using amocrm.library.Models;
using amocrm.library.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.Factory
{
    public class NoteValidatingRulesFactory : IValidationRulesFactory<Note>
    {
        public IValidateRules<Note> CreateAdd()
        {
            var rules = new ValidateRules<Note>();
            rules.AddRule(x => x.ElementId != 0);
            rules.AddRule(x => x.ElementType != 0);
            rules.AddRule(x => x.NoteType != 0);
            rules.AddRule(x => !String.IsNullOrEmpty(x.Text));

            return rules;
        }

        public IValidateRules<Note> CreateUpdate()
        {
            var rules = new ValidateRules<Note>();
            rules.AddRule(x => x.Id != 0);
            rules.AddRule(x => x.UpdatedAt != DateTime.MinValue);

            return rules;
        }
    }
}
