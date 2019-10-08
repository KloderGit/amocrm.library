using amocrm.library.Configurations;
using amocrm.library.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.Filters
{
    public class NoteFilter
    {
        [FilterNameRepresent("id[]")]
        public int Id { get; set; }

        [FilterNameRepresent("limit_rows")]
        public int LimitRows { get; set; }

        [FilterNameRepresent("limit_offset")]
        public int LimitOffset { get; set; }

        /// <summary>
        /// The task relates to elements of the type contact / leader / company / task
        /// </summary>
        [FilterNameRepresent("type")]
        public string Element { get; set; }

        /// <summary>
        /// Id of element - contact/lead/company/task
        /// </summary>
        [FilterNameRepresent("element_id")]
        public int ElementId { get; set; }

        /// <summary>
        /// Note Type Option (Common\System...)
        /// </summary>
        [FilterNameRepresent("e_type")]
        public int NoteType { get; set; }
    }
}
