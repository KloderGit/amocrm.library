using amocrm.library.Interfaces;
using System;

namespace amocrm.library.Tools
{
    public class ValidateRules<T> : IValidateRules<T>
    {
        Predicate<T> Predicate;

        public void AddRule(Predicate<T> predicate)
        {
            Predicate += predicate;
        }

        public bool Validate(T element)
        {
            return Predicate(element);
        }
    }
}
