using Crm.Service.Extensions;
using Crm.Service.Interfaces;
using Crm.Service.Models;
using Crm.Service.Tools;
using Mapster;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crm.Service
{
    public class CrmRepositoty<T> : IQueryableRepository<T>, IEnumerable where T : EntityCore, new()
    {
        public IQueryGenerator QueryGenerator { get; set; } = new QueryGenerator();
        public ICrmProvider Provider { get; }

        public CrmRepositoty(ICrmProvider crmProvider)
        {
            this.Provider = crmProvider;
        }
        public CrmRepositoty(ICrmProvider crmProvider, IQueryGenerator generator)
            : this(crmProvider)
        {
            this.QueryGenerator = generator;
        }

        public IEnumerable<T> Execute()
        {
            var result = this.ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }

        public async Task<IEnumerable<T>> ExecuteAsync()
        {
            var client = await Provider.GetClient();
            var endPoint = Provider.GetEndPoint<T>();
            var query = await QueryGenerator.Generate();

            var responseString = await client.GetResultAsync(endPoint + query).ConfigureAwait(false);

            if (string.IsNullOrEmpty(responseString)) return new List<T>();

            return CreateGetResult(responseString);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var array = Execute();
            return array.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        public async Task<IEnumerable<int>> UpdateAsync(T element)
        {
            return await UpdateAsync(new List<T> { element });
        }

        public async Task<IEnumerable<int>> UpdateAsync(IEnumerable<T> elements)
        {
            var client = await Provider.GetClient();
            var endPoint = Provider.GetEndPoint<T>();

            var dtoToUpdate = new DtoModelBuilder<T>().GetUpdateModel(elements);

            var responseString = await client.PostResultAsync(endPoint, dtoToUpdate).ConfigureAwait(false);

            if (string.IsNullOrEmpty(responseString)) return new List<int>();

            return CreatePostResult(responseString);
        }

        public async Task<IEnumerable<int>> AddAsync(T element)
        {
            return await AddAsync(new List<T> { element });
        }

        public async Task<IEnumerable<int>> AddAsync(IEnumerable<T> elements)
        {
            var client = await Provider.GetClient();
            var endPoint = Provider.GetEndPoint<T>();

            var dtoToAdd = new DtoModelBuilder<T>().GetAddModel(elements);

            var responseString = await client.PostResultAsync(endPoint, dtoToAdd).ConfigureAwait(false);

            if (string.IsNullOrEmpty(responseString)) return new List<int>();

            return CreatePostResult(responseString);
        }

        IEnumerable<T> CreateGetResult(string jsonString)
        {
            var dtoType = typeof(T).GetDtoType();

            var listType = typeof(List<>);
            var genericListType = listType.MakeGenericType(dtoType);

            var toJson = JObject.Parse(jsonString);
            var token = (JArray)toJson.SelectToken("_embedded").SelectToken("items");

            var result = token.ToObject(genericListType);
            return result.Adapt<List<T>>();
        }

        IEnumerable<int> CreatePostResult(string jsonString)
        {
            var listType = typeof(List<int>);

            var toJson = JObject.Parse(jsonString);
            var token = (JArray)toJson.SelectToken("_embedded").SelectToken("items");

            var result = token.Select(x => x["id"].Value<int>()).ToList();
            return result;
        }
    }
}