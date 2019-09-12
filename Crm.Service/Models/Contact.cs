using amocrm.library.Models.Fields;
using System.Collections.Generic;

namespace amocrm.library.Models
{
    public class Contact : EntityMember
    {
        public int UpdatedBy { get; set; }

        public IEnumerable<int> Leads { get; set; } = new List<int>();

        public SimpleObject Company { get; set; }

        public IEnumerable<int> Customers { get; set; } = new List<int>();
    }
}