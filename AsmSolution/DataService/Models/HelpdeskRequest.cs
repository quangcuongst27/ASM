using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class HelpdeskRequest
    {
        public HelpdeskRequest()
        {
            HelpdeskRequestLog = new HashSet<HelpdeskRequestLog>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? DoneDate { get; set; }
        public int? Status { get; set; }
        public int? HelpdeskRequestCatId { get; set; }
        public int? HouseId { get; set; }
        public int? SupporterId { get; set; }

        public virtual HelpdeskRequestCategory HelpdeskRequestCat { get; set; }
        public virtual House House { get; set; }
        public virtual User Supporter { get; set; }
        public virtual ICollection<HelpdeskRequestLog> HelpdeskRequestLog { get; set; }
    }
}
