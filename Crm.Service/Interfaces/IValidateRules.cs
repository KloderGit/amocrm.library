using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace amocrm.library.Interfaces
{
    public interface IValidateRules<T>
    {
        void AddRule(Expression<Predicate<T>> predicate, string message);
        bool ValidateBool(T element);
        IEnumerable<ValidationResult> ValidateResults(T element);
    }
}