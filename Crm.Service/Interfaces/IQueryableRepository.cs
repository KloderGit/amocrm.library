using System.Collections.Generic;
using System.Threading.Tasks;

namespace amocrm.library.Interfaces
{
    public interface IQueryableRepository<T> : ICrmRepository<T>
    {
        IQueryGenerator QueryGenerator { get; set; }
        IEnumerable<T> Execute();
        Task<IEnumerable<T>> ExecuteAsync();
        IEnumerator<T> GetEnumerator();
    }
}
