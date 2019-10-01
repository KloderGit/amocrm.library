using amocrm.library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.Interfaces
{
    public interface ICustomField
    {
        List<Field> Fields { get; set; }
        Field GetField(int fieldId);
        void SetField(int fieldId, string value, int @enum = 0, bool add = false);
    }
}
