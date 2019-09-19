using amocrm.library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.Interfaces
{
    public interface IValidate<T>
    {
        bool Validate(IValidateRules<T> validateRules);
    }
}
