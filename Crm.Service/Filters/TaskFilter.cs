using amocrm.library.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.Filters
{
    public class TaskFilter
    {
        [FilterNameRepresent("id[]")]
        public int Id { get; set; }

        [FilterNameRepresent("limit_rows")]
        public int LimitRows { get; set; }

        [FilterNameRepresent("limit_offset")]
        public int LimitOffset { get; set; }

        /// <summary>
        /// Task belongs to elements type of contact/lead/company/task
        /// </summary>
        [FilterNameRepresent("type")]
        public int Element { get; set; }

        /// <summary>
        /// Id of element - contact/lead/company/task
        /// </summary>
        [FilterNameRepresent("element_id")]
        public int ElementId { get; set; }

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

        [FilterNameRepresent("filter[status][]")]
        public bool isClosed { get; set; }

        [FilterNameRepresent("filter[created_by][]")]
        public bool CreatedBy { get; set; }

        /// <summary>
        /// Variant of action to do (Qualification\Make documends\Recall...)
        /// </summary>
        [FilterNameRepresent("filter[task_type][]")]
        public bool TaskType { get; set; }
    }
}
