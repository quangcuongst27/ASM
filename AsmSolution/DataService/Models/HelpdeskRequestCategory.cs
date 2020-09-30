using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class HelpdeskRequestCategory
    {
        public HelpdeskRequestCategory()
        {
            HelpdeskRequest = new HashSet<HelpdeskRequest>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual ICollection<HelpdeskRequest> HelpdeskRequest { get; set; }
    }
}
