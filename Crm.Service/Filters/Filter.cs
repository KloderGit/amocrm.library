using Crm.Service.Tools;

namespace Crm.Service.Filters
{
    public class Filter
    {
        [FilterNameRepresent("id")]
        public int Id { get; set; }
        [FilterNameRepresent("query")]
        public string Name { get; set; }
        [FilterNameRepresent("contact")]
        public string User { get; set; }
    }
}
