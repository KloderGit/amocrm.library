using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace amocrm.library.Interfaces
{
    public interface IQueryableRepository<T> : ICrmRepository<T>, IEnumerable
    {
        ICrmProvider Provider { get; }
        IQueryGenerator QueryGenerator { get; set; }
        IEnumerable<T> Execute();
        Task<IEnumerable<T>> ExecuteAsync();
    }
}
