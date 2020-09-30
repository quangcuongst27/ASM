using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class BalanceSheet
    {
        public BalanceSheet()
        {
            Receipt = new HashSet<Receipt>();
            Transaction = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public DateTime? LastModified { get; set; }
        public int? ManagerId { get; set; }
        public double? TotalIncome { get; set; }
        public double? TotalExpense { get; set; }
        public double? TotalIncomeInCash { get; set; }
        public double? TotalExpenseInCash { get; set; }
        public double? RedundancyStartMonth { get; set; }
        public double? RedundancyEndMonth { get; set; }

        public virtual User Manager { get; set; }
        public virtual ICollection<Receipt> Receipt { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
