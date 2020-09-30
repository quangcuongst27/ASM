using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class NotificationObject
    {
        public NotificationObject()
        {
            NotificationChange = new HashSet<NotificationChange>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string TargetObject { get; set; }
        public int? TargetObjectId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<NotificationChange> NotificationChange { get; set; }
    }
}
