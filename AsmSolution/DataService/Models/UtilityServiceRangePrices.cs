using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class UtilityServiceRangePrices
    {
        public int Id { get; set; }
        public int? ServiceId { get; set; }
        public string Name { get; set; }
        public double? FromAmount { get; set; }
        public double? ToAmount { get; set; }
        public double? Price { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual UtilityService Service { get; set; }
    }
}
