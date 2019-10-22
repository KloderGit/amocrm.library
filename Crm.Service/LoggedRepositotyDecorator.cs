using amocrm.library.Interfaces;
using amocrm.library.Models;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace amocrm.library
{
    public class LoggedRepositotyDecorator<T> : IQueryableRepository<T>, IEnumerable where T : EntityCore, new()
    {
        ILogger logger;
        public ICrmProvider Provider { get => Repository.Provider; }
        public IQueryableRepository<T> Repository { get; set; }

        public IQueryGenerator QueryGenerator
        {
            get => Repository.QueryGenerator;
            set => Repository.QueryGenerator = value;
        }

        public LoggedRepositotyDecorator(IQueryableRepository<T> repository, ILogger logger)
        {
            logger.LogTrace($"Creating logged repository - {this.GetType().Name}");
            this.logger = logger;
            Repository = repository;
        }

        public IEnumerable<T> Execute()
        {
            return Repository.Execute();
        }

        public async Task<IEnumerable<T>> ExecuteAsync()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            logger.LogTrace("Request for get data (async).");
            logger.LogTrace($"The authentication cookie has not expired - {Repository.Provider.AuthCookiesLifeTime()}.");

            var endPointLog = Repository.Provider.GetEndPoint<T>();
            logger.LogTrace($"EndPoint to send request is - {endPointLog}.");

            var queryLog = await Repository.QueryGenerator.Generate();
            logger.LogTrace($"Query filters are generated  - {queryLog}.");
            logger.LogTrace($"Full request URL - {endPointLog}{queryLog}.");

            var result = await Repository.ExecuteAsync();
            logger.LogDebug("Received {@Count} records. {@Model}", result.Count(), result);

            sw.Stop();
            logger.LogTrace("Query execution time - {time} ", sw.Elapsed);

            return result;
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
            Stopwatch sw = new Stopwatch();
            sw.Start();

            logger.LogTrace("Request for update data (async).");

            logger.LogTrace($"The authentication cookie has not expired - {Repository.Provider.AuthCookiesLifeTime()}.");

            var endPointLog = Repository.Provider.GetEndPoint<T>();
            logger.LogTrace($"EndPoint to send request is - {endPointLog}.");

            var result = await Repository.UpdateAsync(elements);
            logger.LogDebug("Updated {@Count} records. {@Model}", result.Count(), result);

            sw.Stop();
            logger.LogTrace("Query execution time - {time} ", sw.Elapsed);

            return result;
        }

        public async Task<IEnumerable<int>> AddAsync(T element)
        {
            return await AddAsync(new List<T> { element });
        }

        public async Task<IEnumerable<int>> AddAsync(IEnumerable<T> elements)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            logger.LogTrace("Request for add data (async).");

            logger.LogTrace($"The authentication cookie has not expired - {Repository.Provider.AuthCookiesLifeTime()}.");

            var endPointLog = Repository.Provider.GetEndPoint<T>();
            logger.LogTrace($"EndPoint to send request is - {endPointLog}.");


            var result = await Repository.AddAsync(elements);
            logger.LogDebug("Added {@Count} records. {@Model}", result.Count(), result);

            sw.Stop();
            logger.LogTrace("Query execution time - {time} ", sw.Elapsed);

            return result;
        }

        public async Task<T> FindByIdAsync(int id)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            logger.LogTrace("Find object by Id (async).");

            logger.LogTrace($"The authentication cookie has not expired - {Repository.Provider.AuthCookiesLifeTime()}.");

            var endPointLog = Repository.Provider.GetEndPoint<T>();
            logger.LogTrace($"EndPoint to send request is - {endPointLog}.");

            var result = await Repository.FindByIdAsync(id);
            logger.LogDebug("Found {@Count} record. Type - {@Type}", result == null ? 0 : 1, result.GetType().Name);

            sw.Stop();
            logger.LogTrace("Query execution time - {time} ", sw.Elapsed);

            return (T)result;
        }
    }
}