using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class UtilServiceForHouseCat
    {
        public int Id { get; set; }
        public int? HouseCatId { get; set; }
        public int? UtilServiceId { get; set; }
        public int? Status { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual HouseCategory HouseCat { get; set; }
        public virtual UtilityService UtilService { get; set; }
    }
}
