

using Crm.Service.Interfaces;
using Crm.Service.Mappings;
using Crm.Service.Models;
using Crm.Service.Tools;
using Microsoft.Extensions.Logging;
using System;
using Task = Crm.Service.Models.Task;
using Tasks = System.Threading.Tasks;

namespace Crm.Service
{
    public class CrmManager
    {
        ICrmProvider Provider { get; }
        ContactMaps mappings = new ContactMaps();
        IRepositoryCreator RepositoryCreator;

        public CrmManager(string account, string login, string pass)
        {
            Provider = new AmoCrmProvider(account: account, login: login, pass: pass);
            this.RepositoryCreator = new BasicRepositoryCreator(Provider);
        }

        public CrmManager(ILogger logger, string account, string login, string pass)
          : this(account, login, pass)
        {
            this.RepositoryCreator = new LoggedRepositoryCreator(Provider, logger);
        }

        public async Tasks.Task<bool> DirectAuthorization()
        {
            return await Provider.Auth();
        }

        public IQueryableRepository<Lead> Leads => RepositoryCreator.GetRepository<Lead>();

        public IQueryableRepository<Contact> Contacts => RepositoryCreator.GetRepository<Contact>();

        public ICrmRepository<Company> Companies => throw new NotImplementedException();

        public ICrmRepository<Task> Tasks => throw new NotImplementedException();

        public ICrmRepository<Note> Notes => throw new NotImplementedException();
    }
}
