using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace amocrm.library.Interfaces
{
    public interface ICrmProvider
    {
        Task<HttpClient> GetClient();
        Uri GetEndPoint<T>();
    }
}
