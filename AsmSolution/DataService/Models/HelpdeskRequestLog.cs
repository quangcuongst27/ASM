using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class HelpdeskRequestLog
    {
        public int Id { get; set; }
        public int? HelpdeskRequestId { get; set; }
        public int? ChangeFromUserId { get; set; }
        public int? AssignToUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? StatusFrom { get; set; }
        public int? StatusTo { get; set; }
        public DateTime? DeadLine { get; set; }

        public virtual User AssignToUser { get; set; }
        public virtual User ChangeFromUser { get; set; }
        public virtual HelpdeskRequest HelpdeskRequest { get; set; }
    }
}
