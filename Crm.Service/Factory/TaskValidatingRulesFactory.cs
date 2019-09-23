using amocrm.library.Interfaces;
using amocrm.library.Models;
using amocrm.library.Tools;
using System;

namespace amocrm.library.Factory
{
    internal class TaskValidatingRulesFactory : IValidationRulesFactory<Task>
    {
        public IValidateRules<Task> CreateAdd()
        {
            var rules = new ValidateRules<Task>();
            rules.AddRule(x => x.ElementId != 0, "ElementId field must be set");
            rules.AddRule(x => x.ElementType != 0, "ElementType field must be set");
            rules.AddRule(x => x.TaskType != 0, "TaskType field must be set");
            rules.AddRule(x => !String.IsNullOrEmpty(x.Text), "Text field can't be empty");
            rules.AddRule(x => x.CompleteTillAt != DateTime.MinValue, "CompleteTillAt field must be set");

            return rules;
        }

        public IValidateRules<Task> CreateUpdate()
        {
            var rules = new ValidateRules<Task>();
            rules.AddRule(x => x.Id != 0, "Id field must have a value");
            rules.AddRule(x => x.UpdatedAt != DateTime.MinValue, "UpdatedAt field must be set");
            rules.AddRule(x => !String.IsNullOrEmpty(x.Text), "Text field can't be empty");

            return rules;
        }
    }
}
