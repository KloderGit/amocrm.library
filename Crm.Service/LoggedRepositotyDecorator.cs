using amocrm.library.Interfaces;
using amocrm.library.Models;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
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

            logger.LogDebug($"Получен Provider с AuthCookiesLifeTime - {Repository.Provider.AuthCookiesLifeTime()}.");



            var endPointLog = Repository.Provider.GetEndPoint<T>();
            logger.LogDebug($"Получен EndPoint для отправки запроса - {endPointLog}.");
            var queryLog = await Repository.QueryGenerator.Generate();
            logger.LogDebug($"Сгенерирован фильтр запроса - {queryLog}.");
            logger.LogDebug($"Полный URL запроса - {endPointLog}{queryLog}.");

            IEnumerable<T> result = new List<T>();

            try
            {
                result = await Repository.ExecuteAsync();
                logger.LogDebug($"Получено {result.Count()} записей.");

                sw.Stop();
                logger.LogDebug("Время выполнения запроса - {time} ", sw.Elapsed);
            }
            catch (HttpRequestException ex)
            {
                logger.LogDebug($"Запрос вернул ошибку - {ex.Message}");
                throw ex;
            }

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

            logger.LogDebug($"Получен Provider с AuthCookiesLifeTime - {Repository.Provider.AuthCookiesLifeTime()}.");
            var endPointLog = Repository.Provider.GetEndPoint<T>();
            logger.LogDebug($"Получен EndPoint для отправки запроса - {endPointLog}.");

            IEnumerable<int> result = new List<int>();

            try
            {
                result = await Repository.UpdateAsync(elements);
                logger.LogDebug($"Обновлено {result.Count()} записей.");

                sw.Stop();
                logger.LogDebug("Время выполнения запроса - {time} ", sw.Elapsed);
            }
            catch (HttpRequestException ex)
            {
                logger.LogDebug($"Запрос вернул ошибку - {ex.Message}");
                throw ex;
            }

            return result;
        }

        public async Task<IEnumerable<int>> AddAsync(T element)
        {
            logger.LogDebug($"Добавление объекта - {element}.");

            var result = await AddAsync(new List<T> { element });

            logger.LogDebug($"Id объекта - {result.First()}.");

            return result;
        }

        public async Task<IEnumerable<int>> AddAsync(IEnumerable<T> elements)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            logger.LogDebug($"Получен Provider с AuthCookiesLifeTime - {Repository.Provider.AuthCookiesLifeTime()}.");
            var endPointLog = Repository.Provider.GetEndPoint<T>();
            logger.LogDebug($"Получен EndPoint для отправки запроса - {endPointLog}.");

            IEnumerable<int> result = new List<int>();

            try
            {
                result = await Repository.AddAsync(elements);
                logger.LogDebug($"Добавлено {result.Count()} записей.");

                sw.Stop();
                logger.LogDebug("Время выполнения запроса - {time} ", sw.Elapsed);
            }
            catch (HttpRequestException ex)
            {
                logger.LogDebug($"Запрос вернул ошибку - {ex.Message}");
                throw ex;
            }

            return result;
        }

        public async Task<T> FindByIdAsync(int id)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            logger.LogDebug($"Получен Provider с AuthCookiesLifeTime - {Repository.Provider.AuthCookiesLifeTime()}.");
            var endPointLog = Repository.Provider.GetEndPoint<T>();
            logger.LogDebug($"Получен EndPoint для отправки запроса - {endPointLog}.");

            T result = new T();

            try
            {
                result = await Repository.FindByIdAsync(id);

                logger.LogInformation("Получено в модель DTO {@Model}", result);

                logger.LogDebug($"Найдено записей.");

                sw.Stop();
                logger.LogDebug("Время выполнения запроса - {time} ", sw.Elapsed);
            }
            catch (HttpRequestException ex)
            {
                logger.LogDebug($"Запрос вернул ошибку - {ex.Message}");
                throw ex;
            }

            return result;
        }
    }
}