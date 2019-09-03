using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Crm.Interfaces
{
    public interface ICrmProvider
    {
        Task<bool> Auth();
        Task<HttpClient> GetClient();
        bool AuthCookiesLifeTime();
        Uri GetEndPoint<T>();
    }
}
