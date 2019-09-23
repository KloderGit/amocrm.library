using amocrm.library.Models;
using amocrm.library.Tools;
using System;
using System.Linq;
using System.Reflection;

namespace amocrm.library.Extensions
{
    internal static class TypeExtensions
    {
        public static Type GetDtoType(this Type entity, ActionEnum dtoAction)
        {
            var asmbly = Assembly.GetExecutingAssembly();
            var typeList = asmbly.GetTypes().Where(
                    t => t.GetCustomAttributes(typeof(SelectDtoAttribute), true).Length > 0
            ).ToList();

            foreach (var tp in typeList)
            {
                var attrs = tp.GetCustomAttributes(false).FirstOrDefault(x => x.GetType() == typeof(SelectDtoAttribute)) as SelectDtoAttribute;

                if (attrs?.Entity == entity && attrs.Action == dtoAction) return tp;
            }

            throw new Exception($"Тип DTO не найден для данного типа {entity.Name} или действия {dtoAction}");
        }
    }
}
