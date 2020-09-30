using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public string UserCropUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
