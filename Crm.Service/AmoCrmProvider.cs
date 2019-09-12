
using amocrm.library.Configurations;
using amocrm.library.Interfaces;
using amocrm.library.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace amocrm.library
{
    public class AmoCrmProvider : ICrmProvider
    {
        static DateTime cookiesLiveTime;

        HttpClient client;
        HttpClientHandler handler;
        CrmEndPointConfig endPoint;
        private readonly string login;
        private string pass;

        public AmoCrmProvider(string account, string login, string pass)
        {
            endPoint = new CrmEndPointConfig(account);
            this.login = login;
            this.pass = pass;
        }

        public async System.Threading.Tasks.Task Auth()
        {
            Debug.WriteLine($"Соединение с CRM");

            handler = new HttpClientHandler
            {
                CookieContainer = new CookieContainer(),
                UseCookies = true,
                UseDefaultCredentials = true
            };

            client = new HttpClient(handler);

            var requestParams = new Dictionary<string, string>
                {
                   { "USER_LOGIN", this.login},
                   { "USER_HASH", this.pass }
                };

            var content = new FormUrlEncodedContent(requestParams);
            var request = await client.PostAsync(endPoint.Auth, content);
            var response = await request.Content.ReadAsStringAsync();

            if (!request.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<Error>(response);
                var exception = new HttpRequestException(error.Response.Error);
                exception.Data.Add("ErrorCode", error.Response.ErrorCode);
                exception.Data.Add("IP", error.Response.Ip);
                exception.Data.Add("Domain", error.Response.Domain);
                exception.Data.Add("ServerTime", error.Response.ServerTime);
                throw exception;
            }

            AmoCrmProvider.cookiesLiveTime = DateTime.Now;

        }

        public bool AuthCookiesLifeTime()
        {
            var lifeTime = TimeSpan.FromMinutes(13);

            return DateTime.Now.Subtract(AmoCrmProvider.cookiesLiveTime) < lifeTime & handler != null;
        }

        public async Task<HttpClient> GetClient()
        {
            if (!AuthCookiesLifeTime()) await Auth();

            return client;
        }

        public Uri GetEndPoint<TPoint>()
        {
            return endPoint.GetUrl<TPoint>();
        }

    }
}
