using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crm.Interfaces
{
    public interface IQueryableRepository<T> : ICrmRepository<T>
    {
        IQueryGenerator QueryGenerator { get; set; }
        IEnumerable<T> Execute();
        Task<IEnumerable<T>> ExecuteAsync();
        IEnumerator<T> GetEnumerator();
    }
}
