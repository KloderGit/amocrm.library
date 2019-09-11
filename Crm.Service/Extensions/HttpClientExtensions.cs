using amocrm.library.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace amocrm.library.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PostObjectAsync(this HttpClient client, Uri url, System.Object @object)
        {
            var objToJson = JsonConvert.SerializeObject(@object);
            var stringContent = new StringContent(objToJson.ToString());

            return await client.PostAsync(url, stringContent).ConfigureAwait(false);
        }

        public static async Task<string> PostResultAsync(this HttpClient client, Uri url, System.Object @object)
        {
            string result = String.Empty;

            try
            {
                var request = await client.PostObjectAsync(url, @object);
                result = await request.Content.ReadAsStringAsync().ConfigureAwait(false);
                request.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                var error = JsonConvert.DeserializeObject<Error>(result);
                var exception = new HttpRequestException(error.Response.Error);
                exception.Data.Add("ErrorCode", error.Response.ErrorCode);
                exception.Data.Add("IP", error.Response.Ip);
                exception.Data.Add("Domain", error.Response.Domain);
                exception.Data.Add("ServerTime", error.Response.ServerTime);

                throw exception;
            }

            return result;
        }


        public static async Task<string> GetResultAsync(this HttpClient client, string url)
        {
            string result = String.Empty;

            try
            {
                var request = await client.GetAsync(url).ConfigureAwait(false);
                result = await request.Content.ReadAsStringAsync().ConfigureAwait(false);
                request.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                var error = JsonConvert.DeserializeObject<Error>(result);
                var exception = new HttpRequestException(error.Response.Error);
                exception.Data.Add("ErrorCode", error.Response.ErrorCode);
                exception.Data.Add("IP", error.Response.Ip);
                exception.Data.Add("Domain", error.Response.Domain);
                exception.Data.Add("ServerTime", error.Response.ServerTime);

                throw exception;
            }

            return result;
        }

    }
}
