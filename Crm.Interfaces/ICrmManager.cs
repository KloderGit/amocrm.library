using Crm.Domain;

namespace Crm.Interfaces
{
    public interface ICrmManager
    {
        ICrmRepository<Lead> Leads { get; }
        IQueryableRepository<Contact> Contacts { get; }
        ICrmRepository<Company> Companies { get; }
        ICrmRepository<Task> Tasks { get; }
        ICrmRepository<Note> Notes { get; }
    }
}
