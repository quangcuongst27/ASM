using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class AroundProvider
    {
        public AroundProvider()
        {
            AroundProviderProduct = new HashSet<AroundProviderProduct>();
            UserRateAroundProvider = new HashSet<UserRateAroundProvider>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public long? ClickCount { get; set; }
        public int? AroundProviderCategoryId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModified { get; set; }
        public int? Status { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public virtual AroundProviderCategory AroundProviderCategory { get; set; }
        public virtual ICollection<AroundProviderProduct> AroundProviderProduct { get; set; }
        public virtual ICollection<UserRateAroundProvider> UserRateAroundProvider { get; set; }
    }
}
