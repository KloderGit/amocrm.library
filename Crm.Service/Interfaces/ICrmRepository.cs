using System.Collections.Generic;
using System.Threading.Tasks;

namespace amocrm.library.Interfaces
{
    public interface ICrmRepository<T>
    {
        Task<T> FindByIdAsync(int id);
        Task<IEnumerable<int>> AddAsync(T element);
        Task<IEnumerable<int>> AddAsync(IEnumerable<T> element);
        Task<IEnumerable<int>> UpdateAsync(T element);
        Task<IEnumerable<int>> UpdateAsync(IEnumerable<T> element);
    }
}
