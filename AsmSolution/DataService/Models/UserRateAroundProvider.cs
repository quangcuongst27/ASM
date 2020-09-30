using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class UserRateAroundProvider
    {
        public int UserId { get; set; }
        public int AroundProviderId { get; set; }
        public int? Point { get; set; }

        public virtual AroundProvider AroundProvider { get; set; }
        public virtual User User { get; set; }
    }
}
