using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class AroundProviderProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public int? ViewIndex { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModified { get; set; }
        public int? AroundProviderId { get; set; }

        public virtual AroundProvider AroundProvider { get; set; }
    }
}
