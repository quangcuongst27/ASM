using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Receipt
    {
        public Receipt()
        {
            ReceiptDetail = new HashSet<ReceiptDetail>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? Type { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? Status { get; set; }
        public int? HouseId { get; set; }
        public string Description { get; set; }
        public int? ManagerId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModified { get; set; }
        public int? IsBatch { get; set; }
        public int? BlsId { get; set; }

        public virtual BalanceSheet Bls { get; set; }
        public virtual House House { get; set; }
        public virtual User Manager { get; set; }
        public virtual ICollection<ReceiptDetail> ReceiptDetail { get; set; }
    }
}
