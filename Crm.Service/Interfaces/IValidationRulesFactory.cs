using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.Interfaces
{
    public interface IValidationRulesFactory<T>
    {
        IValidateRules<T> CreateUpdate();
        IValidateRules<T> CreateAdd();
    }
}
