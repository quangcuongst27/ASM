using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class House
    {
        public House()
        {
            HelpdeskRequest = new HashSet<HelpdeskRequest>();
            Receipt = new HashSet<Receipt>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public int? BlockId { get; set; }
        public string Floor { get; set; }
        public string HouseName { get; set; }
        public string Description { get; set; }
        public double? Area { get; set; }
        public int? OwnerId { get; set; }
        public string ProfileImage { get; set; }
        public string CoverImage { get; set; }
        public bool? DisplayMember { get; set; }
        public bool? AllowOtherView { get; set; }
        public int? TypeId { get; set; }
        public int? Status { get; set; }
        public int? WaterMeter { get; set; }

        public virtual Block Block { get; set; }
        public virtual HouseCategory Type { get; set; }
        public virtual ICollection<HelpdeskRequest> HelpdeskRequest { get; set; }
        public virtual ICollection<Receipt> Receipt { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
