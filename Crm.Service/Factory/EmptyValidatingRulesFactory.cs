using amocrm.library.Interfaces;
using amocrm.library.Tools;

namespace amocrm.library.Factory
{
    public class EmptyValidatingRulesFactory<T> : IValidationRulesFactory<T>
    {
        public IValidateRules<T> CreateAdd()
        {
            var rules = new ValidateRules<T>();
            return rules;
        }

        public IValidateRules<T> CreateUpdate()
        {
            var rules = new ValidateRules<T>();

            return rules;
        }
    }
}
