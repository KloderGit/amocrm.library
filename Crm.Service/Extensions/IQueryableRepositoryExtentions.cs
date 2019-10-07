using amocrm.library.Filters;
using amocrm.library.Interfaces;
using amocrm.library.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace amocrm.library.Extensions
{

    public static class IQueryableRepositoryExtentions
    {

        public static IQueryableRepository<Contact> Where(this IQueryableRepository<Contact> queryable, Expression<Func<ContactFilter, bool>> predicate)
        {
            queryable.QueryGenerator.CreateQuery(predicate);
            return queryable;
        }
        public static async Task<List<T>> ToList<T>(this IQueryableRepository<T> queryable)
        {
            Debug.WriteLine($"Запрос данных");
            return new List<T>(await queryable.ExecuteAsync());
        }


        public static IQueryableRepository<Lead> Where(this IQueryableRepository<Lead> queryable, Expression<Func<LeadFilter, bool>> predicate)
        {
            queryable.QueryGenerator.CreateQuery(predicate);
            return queryable;
        }

        public static IQueryableRepository<Note> Where(this IQueryableRepository<Note> queryable, Expression<Func<NoteFilter, bool>> predicate)
        {
            queryable.QueryGenerator.CreateQuery(predicate);
            return queryable;
        }
    }

}


