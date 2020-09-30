﻿using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public int? UserId { get; set; }
        public string Detail { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
