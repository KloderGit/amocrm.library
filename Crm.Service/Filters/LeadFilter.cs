﻿using amocrm.library.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.Filters
{
    public class LeadFilter
    {
        [FilterNameRepresent("id[]")]
        public int Id { get; set; }

        [FilterNameRepresent("query")]
        public string Name { get; set; }

        [FilterNameRepresent("query")]
        public string Contains { get; set; }

        [FilterNameRepresent("limit_rows")]
        public int LimitRows { get; set; }

        [FilterNameRepresent("limit_offset")]
        public int LimitOffset { get; set; }

        [FilterNameRepresent("status")]
        public int Status { get; set; }

        [FilterNameRepresent("filter[active]")]
        public bool Active { get; set; }

        [FilterNameRepresent("filter[tasks]")]
        public int Tasks { get; set; }

        [FilterNameRepresent("responsible_user_id[]")]
        public int ResponsibleUser { get; set; }

        [FilterNameRepresent("filter[date_create][from]")]
        public DateTime CreateFrom { get; set; }

        [FilterNameRepresent("filter[date_create][to]")]
        public DateTime CreateTo { get; set; }

        [FilterNameRepresent("filter[date_modify][from]")]
        public DateTime ModifyFrom { get; set; }

        [FilterNameRepresent("filter[date_modify][to]")]
        public DateTime ModifyTo { get; set; }
    }
}
