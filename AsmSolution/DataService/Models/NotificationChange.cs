using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class NotificationChange
    {
        public int Id { get; set; }
        public int NotificationObjectId { get; set; }
        public string Verb { get; set; }
        public int Actor { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual User ActorNavigation { get; set; }
        public virtual NotificationObject NotificationObject { get; set; }
    }
}
