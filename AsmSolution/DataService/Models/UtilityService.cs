using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class UtilityService
    {
        public UtilityService()
        {
            ReceiptDetail = new HashSet<ReceiptDetail>();
            UtilServiceForHouseCat = new HashSet<UtilServiceForHouseCat>();
            UtilityServiceRangePrices = new HashSet<UtilityServiceRangePrices>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModified { get; set; }
        public double? Price { get; set; }
        public int? Type { get; set; }
        public int? UtilSrvCatId { get; set; }

        public virtual UtilServiceCategory UtilSrvCat { get; set; }
        public virtual ICollection<ReceiptDetail> ReceiptDetail { get; set; }
        public virtual ICollection<UtilServiceForHouseCat> UtilServiceForHouseCat { get; set; }
        public virtual ICollection<UtilityServiceRangePrices> UtilityServiceRangePrices { get; set; }
    }
}
