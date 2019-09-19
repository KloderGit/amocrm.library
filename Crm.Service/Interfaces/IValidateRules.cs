using System;

namespace amocrm.library.Interfaces
{
    public interface IValidateRules<T>
    {
        void AddRule(Predicate<T> predicate);
        bool Validate(T element);
    }
}
