using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public int? BlsId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModified { get; set; }
        public int? ReceiptDetailId { get; set; }
        public double? TotalAmount { get; set; }
        public double? PaidAmount { get; set; }

        public virtual BalanceSheet Bls { get; set; }
        public virtual ReceiptDetail ReceiptDetail { get; set; }
    }
}
