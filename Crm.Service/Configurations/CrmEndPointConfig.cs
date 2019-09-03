using Crm.Domain;
using Crm.Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Service.Configurations
{
    internal class CrmEndPointConfig
    {
        Uri _baseUrl { get; }
        Dictionary<Type, Uri> urls = new Dictionary<Type, Uri>();

        public Uri Base { get => _baseUrl; }

        public Uri Auth { get => new Uri(_baseUrl, "private/api/auth.php?type=json"); }

        public Uri Lead { get => new Uri(_baseUrl, "api/v2/leads"); }
        public Uri NotesLead { get => new Uri(_baseUrl, "api/v2/notes?type=lead"); }

        public Uri Contact { get => new Uri(_baseUrl, "api/v2/contacts"); }
        public Uri NotesContact { get => new Uri(_baseUrl, "api/v2/notes?type=contact"); }

        public Uri Company { get => new Uri(_baseUrl, "api/v2/companies"); }
        public Uri NotesCompany { get => new Uri(_baseUrl, "api/v2/notes?type=company"); }

        public Uri Task { get => new Uri(_baseUrl, "api/v2/tasks"); }
        public Uri NotesTask { get => new Uri(_baseUrl, "api/v2/notes?type=task"); }

        public Uri Catalog { get => new Uri(_baseUrl, "api/v2/catalog_elements"); }

        public Uri Fields { get => new Uri(_baseUrl, "api/v2/account"); }

        public CrmEndPointConfig(string account)
        {
            _baseUrl = new Uri($"https://{account}.amocrm.ru/");

            //urls.Add(typeof(LeadDTO), new Uri(_baseUrl, "api/v2/leads"));
            urls.Add(typeof(Contact), new Uri(_baseUrl, "api/v2/contacts"));
            //urls.Add(typeof(CompanyDTO), new Uri(_baseUrl, "api/v2/companies"));
            //urls.Add(typeof(CatalogDTO), new Uri(_baseUrl, "api/v2/catalog_elements"));
            //urls.Add(typeof(TaskDTO), new Uri(_baseUrl, "api/v2/tasks"));
            //urls.Add(typeof(NoteDTO), new Uri(_baseUrl, "api/v2/notes"));
            //urls.Add(typeof(Account), new Uri(_baseUrl, "api/v2/account"));
        }

        public Uri GetUrl<T>()
        {
            var name = typeof(T);
            var res = urls[name];

            return res;
        }
    }
}
