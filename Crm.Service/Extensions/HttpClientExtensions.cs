using amocrm.library.Converters;
using amocrm.library.Models;
using amocrm.library.Tools;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace amocrm.library.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<string> PostResultAsync(this HttpClient client, Uri url, System.Object @object)
        {
            var objToJson = JsonConvert.SerializeObject(@object, new PostJsonSerializerSettings().GetSerializeSetting());
            var stringContent = new StringContent(objToJson.ToString());

            var request = await client.PostAsync(url, stringContent).ConfigureAwait(false);
            var response = await request.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!request.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<AuthResponse>(response);
                var exception = new AmoCrmHttpException(error);
                throw exception;
            }

            return response;
        }


        public static async Task<string> GetResultAsync(this HttpClient client, string url)
        {
            var request = await client.GetAsync(url).ConfigureAwait(false);
            var response = await request.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!request.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<AuthResponse>(response);
                var exception = new AmoCrmHttpException(error);
                throw exception;
            }

            return response;
        }

    }
}
