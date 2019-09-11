using System.Linq.Expressions;
using System.Threading.Tasks;

namespace amocrm.library.Interfaces
{
    public interface IQueryGenerator
    {
        void CreateQuery(Expression expression);
        Task<string> Generate();
    }
}
