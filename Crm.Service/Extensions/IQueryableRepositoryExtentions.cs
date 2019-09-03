using Crm.Service.Filters;
using Crm.Service.Interfaces;
using Crm.Service.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Crm.Service.Extensions
{

    public static class IQueryableRepositoryExtentions
    {

        public static IQueryableRepository<Contact> Where(this IQueryableRepository<Contact> queryable, Expression<Func<Filter, bool>> predicate)
        {
            queryable.QueryGenerator.CreateQuery(predicate);
            return queryable;
        }
        public static async Task<List<T>> ToList<T>(this IQueryableRepository<T> queryable)
        {
            Debug.WriteLine($"Запрос данных");
            return new List<T>(await queryable.ExecuteAsync());
        }


        public static IQueryableRepository<Lead> Where(this IQueryableRepository<Lead> queryable, Expression<Func<Filter, bool>> predicate)
        {
            queryable.QueryGenerator.CreateQuery(predicate);
            return queryable;
        }

    }

}


