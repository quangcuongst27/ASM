using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Post
    {
        public Post()
        {
            Comment = new HashSet<Comment>();
            Image = new HashSet<Image>();
            Report = new HashSet<Report>();
        }

        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? Status { get; set; }
        public int? UserId { get; set; }
        public string EmbedCode { get; set; }
        public int? Disable { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Image> Image { get; set; }
        public virtual ICollection<Report> Report { get; set; }
    }
}
