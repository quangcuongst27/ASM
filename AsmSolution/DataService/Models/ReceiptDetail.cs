using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class ReceiptDetail
    {
        public ReceiptDetail()
        {
            Transaction = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public double? Total { get; set; }
        public double? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public int? UtilityServiceId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModified { get; set; }
        public int? FromNumber { get; set; }
        public int? ToNumber { get; set; }
        public int? ReceiptId { get; set; }

        public virtual Receipt Receipt { get; set; }
        public virtual UtilityService UtilityService { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
