using amocrm.library.Tools;

namespace amocrm.library.Filters
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
