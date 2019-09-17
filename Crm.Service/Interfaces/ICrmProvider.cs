using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace amocrm.library.Interfaces
{
    public interface ICrmProvider
    {
        Task Auth();
        Task<HttpClient> GetClient();
        TimeSpan ServerTimeDiff { get; set; }
        bool AuthCookiesLifeTime();

        Uri GetEndPoint<T>();
    }
}
