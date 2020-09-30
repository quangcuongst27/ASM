using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class HouseCategory
    {
        public HouseCategory()
        {
            House = new HashSet<House>();
            UtilServiceForHouseCat = new HashSet<UtilServiceForHouseCat>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual ICollection<House> House { get; set; }
        public virtual ICollection<UtilServiceForHouseCat> UtilServiceForHouseCat { get; set; }
    }
}
