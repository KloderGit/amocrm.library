using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Crm.Interfaces
{
    public interface IQueryGenerator
    {
        void CreateQuery(Expression expression);
        Task<string> Generate();
    }
}
