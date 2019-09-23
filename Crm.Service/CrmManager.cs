using amocrm.library.Interfaces;
using amocrm.library.Mappings;
using amocrm.library.Models;
using amocrm.library.Tools;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace amocrm.library
{
    public class CrmManager : ICrmManager
    {
        ICrmProvider Provider { get; }
        ContactMaps mappings = new ContactMaps();
        IRepositoryCreator RepositoryCreator;

        public CrmManager()
        {
            new InitMappings();
        }

        public CrmManager(string account, string login, string pass)
            : this()
        {
            Provider = new AmoCrmProvider(account: account, login: login, pass: pass);
            this.RepositoryCreator = new BasicRepositoryCreator(Provider);
        }

        public CrmManager(ILogger logger, string account, string login, string pass)
          : this(account, login, pass)
        {
            this.RepositoryCreator = new LoggedRepositoryCreator(Provider, logger);
        }

        public IQueryableRepository<Lead> Leads => RepositoryCreator.GetRepository<Lead>();

        public IQueryableRepository<Contact> Contacts => RepositoryCreator.GetRepository<Contact>();

        public IQueryableRepository<Company> Companies => RepositoryCreator.GetRepository<Company>();

        public IQueryableRepository<Models.Task> Tasks => RepositoryCreator.GetRepository<Models.Task>();

        public IQueryableRepository<Note> Notes => RepositoryCreator.GetRepository<Note>();

        public async System.Threading.Tasks.Task DirectAuthorization()
        {
            await Provider.Auth();
        }
    }
}
