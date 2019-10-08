using amocrm.library.Filters;
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

        public IValidateRules<NoteFilter> CreateGet()
        {
            var rules = new ValidateRules<NoteFilter>();
            rules.AddRule(f => string.IsNullOrEmpty(f.Element), "An element for note is not specified");
            rules.AddRule(f => f.LimitOffset != 0 && f.LimitRows == 0, "Specify the LimitRows");

            return rules;
        }

        public IValidateRules<TFilter> CreateGet<TFilter>()
        {
            throw new NotImplementedException();
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
