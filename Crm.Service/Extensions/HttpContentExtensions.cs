using Mapster;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace amocrm.library.Extensions
{
    public static class HttpContentExtensions
    {
        public static async Task<IEnumerable<T>> ReadGetResponseAsync<T>(this HttpContent content)
        {
            var dtoType = typeof(T).GetDtoType();

            var listType = typeof(List<>);
            var genericListType = listType.MakeGenericType(dtoType);

            var response = await content.ReadAsStringAsync().ConfigureAwait(false);

            var toJson = JObject.Parse(response);
            var token = (JArray)toJson.SelectToken("_embedded").SelectToken("items");

            var result = token.ToObject(genericListType);
            return result.Adapt<List<T>>();
        }

        public static async Task<IEnumerable<int>> ReadPostResponseAsync(this HttpContent content)
        {
            var listType = typeof(List<int>);

            var response = await content.ReadAsStringAsync().ConfigureAwait(false);

            var toJson = JObject.Parse(response);
            var token = (JArray)toJson.SelectToken("_embedded").SelectToken("items");

            var result = token.Select(x => x["id"].Value<int>()).ToList();
            return result;
        }
    }
}
