using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crm.Interfaces
{
    public interface ICrmRepository<T>
    {
        ICrmProvider Provider { get; }

        Task<IEnumerable<int>> AddAsync(T element);
        Task<IEnumerable<int>> AddAsync(IEnumerable<T> element);

        Task<IEnumerable<int>> UpdateAsync(T element);
        Task<IEnumerable<int>> UpdateAsync(IEnumerable<T> element);
    }
}
