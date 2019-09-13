using amocrm.library.Models;
using System;

namespace amocrm.library.Tools
{
    public class SelectDtoAttribute : Attribute
    {
        public Type Entity { get; set; }
        public ActionEnum Action { get; set; }

        public SelectDtoAttribute(Type type, ActionEnum action)
        {
            Entity = type;
            Action = action;
        }
    }
}
