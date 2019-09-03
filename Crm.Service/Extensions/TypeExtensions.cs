﻿using Crm.Service.DTO;
using System;
using System.Linq;
using System.Reflection;

namespace Crm.Service.Extensions
{
    public static class TypeExtensions
    {
        public static Type GetDtoType(this Type entity)
        {
            var asmbly = Assembly.GetExecutingAssembly();
            var typeList = asmbly.GetTypes().Where(
                    t => t.GetCustomAttributes(typeof(ParentAttribute), true).Length > 0
            ).ToList();

            foreach (var tp in typeList)
            {
                var attrs = tp.GetCustomAttributes(false).FirstOrDefault(x => x.GetType() == typeof(ParentAttribute)) as ParentAttribute;

                if (attrs?.Master == entity) return tp;
            }

            throw new Exception($"Тип DTO не найден для данного типа {entity.Name}");
        }
    }
}
