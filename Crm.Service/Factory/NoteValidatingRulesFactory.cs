using amocrm.library.Interfaces;
using amocrm.library.Models;
using amocrm.library.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.Factory
{
    internal class NoteValidatingRulesFactory : IValidationRulesFactory<Note>
    {
        public IValidateRules<Note> CreateAdd()
        {
            var rules = new ValidateRules<Note>();
            rules.AddRule(x => x.ElementId != 0, "ElementId field must be set");
            rules.AddRule(x => x.ElementType != 0, "ElementType field must be set");
            rules.AddRule(x => x.NoteType != 0, "NoteType field must be set");
            rules.AddRule(x => !String.IsNullOrEmpty(x.Text), "Text field can't be empty");

            return rules;
        }

        public IValidateRules<Note> CreateUpdate()
        {
            var rules = new ValidateRules<Note>();
            rules.AddRule(x => x.Id != 0, "Id field must have a value");
            rules.AddRule(x => x.UpdatedAt != DateTime.MinValue, "UpdatedAt field must be set");

            return rules;
        }
    }
}
