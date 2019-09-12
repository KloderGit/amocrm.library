using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace amocrm.library.Interfaces
{
    public interface ICrmProvider
    {
        Task Auth();
        Task<HttpClient> GetClient();
        bool AuthCookiesLifeTime();
        Uri GetEndPoint<T>();
    }
}
