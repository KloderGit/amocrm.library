using amocrm.library.Models;
using amocrm.library.Tools;
using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace amocrm.library.Extensions
{
    internal static class IEnumerableExtensions
    {
        public static ArrayList ToArrayList(this IEnumerable array)
        {
            var result = new ArrayList();

            foreach (var item in array)
            {
                result.Add(item);
            }

            return result;
        }
    }
}
