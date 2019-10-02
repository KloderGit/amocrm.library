using amocrm.library.Models;
using amocrm.library.Models.Account;
using System;
using System.Collections.Generic;

namespace amocrm.library.Configurations
{
    internal class CrmEndPointConfig
    {
        Uri _baseUrl { get; }
        Dictionary<Type, Uri> urls = new Dictionary<Type, Uri>();


        public Uri Auth { get => new Uri(_baseUrl, "private/api/auth.php?type=json"); }

        public CrmEndPointConfig(string account)
        {
            _baseUrl = new Uri($"https://{account}.amocrm.ru/");

            urls.Add(typeof(Lead), new Uri(_baseUrl, "api/v2/leads"));
            urls.Add(typeof(Contact), new Uri(_baseUrl, "api/v2/contacts"));
            urls.Add(typeof(Company), new Uri(_baseUrl, "api/v2/companies"));
            //urls.Add(typeof(CatalogDTO), new Uri(_baseUrl, "api/v2/catalog_elements"));
            urls.Add(typeof(Task), new Uri(_baseUrl, "api/v2/tasks"));
            urls.Add(typeof(Note), new Uri(_baseUrl, "api/v2/notes"));
            urls.Add(typeof(AccountInfo), new Uri(_baseUrl, "api/v2/account?with=custom_fields,users,pipelines,note_types,task_types"));
        }

        public Uri GetUrl<T>()
        {
            var name = typeof(T);
            var res = urls[name];

            return res;
        }
    }
}
