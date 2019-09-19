using amocrm.library.Factory;
using amocrm.library.Interfaces;
using amocrm.library.Models;
using amocrm.library.Tools;
using System;
using System.Collections.Generic;

namespace amocrm.library.Tools
{
    public class ValidateRulesManager : IValidationRulesManager
    {
        private IDictionary<Type, object> factories = new Dictionary<Type, object>();

        public ValidateRulesManager()
        {
            factories.Add(typeof(Lead), new LeadValidatingRulesFactory());
            factories.Add(typeof(Contact), new ContactValidatingRulesFactory());
            factories.Add(typeof(Company), new CompanyValidatingRulesFactory());
            factories.Add(typeof(Note), new NoteValidatingRulesFactory());
            factories.Add(typeof(Task), new TaskValidatingRulesFactory());
        }

        public IValidationRulesFactory<T> GetFactory<T>()
        {
            return factories[typeof(T)] as IValidationRulesFactory<T>;
        }
    }
}






