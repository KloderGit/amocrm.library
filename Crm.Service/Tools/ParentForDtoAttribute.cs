using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.Tools
{
    public class ParentForDtoAttribute : Attribute
    {
        public Type Master { get; set; }
        public ParentForDtoAttribute()
        { }
        public ParentForDtoAttribute(Type type)
        {
            Master = type;
        }
    }
}
