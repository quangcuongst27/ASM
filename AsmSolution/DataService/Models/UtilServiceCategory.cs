using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class UtilServiceCategory
    {
        public UtilServiceCategory()
        {
            UtilityService = new HashSet<UtilityService>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModified { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<UtilityService> UtilityService { get; set; }
    }
}
