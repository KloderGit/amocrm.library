using amocrm.library.Models.Fields;
using System.Collections.Generic;

namespace amocrm.library.Models
{
    public class Contact : EntityMember
    {
        public int UpdatedBy { get; set; }

        public List<int> Leads { get; set; } = new List<int>();

        public SimpleObject Company { get; set; }
    }
}