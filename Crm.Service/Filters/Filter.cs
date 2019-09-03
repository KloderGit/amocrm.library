using Crm.Service.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
