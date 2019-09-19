using amocrm.library.Interfaces;
using amocrm.library.Models;
using amocrm.library.Tools;
using System;

namespace amocrm.library.Factory
{
    public class TaskValidatingRulesFactory : IValidationRulesFactory<Task>
    {
        public IValidateRules<Task> CreateAdd()
        {
            var rules = new ValidateRules<Task>();
            rules.AddRule(x => x.ElementId != 0);
            rules.AddRule(x => x.ElementType != 0);
            rules.AddRule(x => x.TaskType != 0);
            rules.AddRule(x => !String.IsNullOrEmpty(x.Text));
            rules.AddRule(x => x.CompleteTillAt != DateTime.MinValue);

            return rules;
        }

        public IValidateRules<Task> CreateUpdate()
        {
            var rules = new ValidateRules<Task>();
            rules.AddRule(x => x.Id != 0);
            rules.AddRule(x => x.UpdatedAt != DateTime.MinValue);
            rules.AddRule(x => !String.IsNullOrEmpty(x.Text));

            return rules;
        }
    }
}
