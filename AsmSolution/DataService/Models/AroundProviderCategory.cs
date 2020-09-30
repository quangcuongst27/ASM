using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class AroundProviderCategory
    {
        public AroundProviderCategory()
        {
            AroundProvider = new HashSet<AroundProvider>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<AroundProvider> AroundProvider { get; set; }
    }
}
