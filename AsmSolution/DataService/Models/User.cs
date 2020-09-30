using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class User
    {
        public User()
        {
            BalanceSheet = new HashSet<BalanceSheet>();
            Comment = new HashSet<Comment>();
            HelpdeskRequest = new HashSet<HelpdeskRequest>();
            HelpdeskRequestLogAssignToUser = new HashSet<HelpdeskRequestLog>();
            HelpdeskRequestLogChangeFromUser = new HashSet<HelpdeskRequestLog>();
            NotificationChange = new HashSet<NotificationChange>();
            NotificationObject = new HashSet<NotificationObject>();
            Post = new HashSet<Post>();
            Receipt = new HashSet<Receipt>();
            Report = new HashSet<Report>();
            UserAnswerPoll = new HashSet<UserAnswerPoll>();
            UserRateAroundProvider = new HashSet<UserRateAroundProvider>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public int? HouseId { get; set; }
        public int? Creator { get; set; }
        public string ProfileImage { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Idnumber { get; set; }
        public int? Gender { get; set; }
        public string Fullname { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModified { get; set; }
        public int? FamilyLevel { get; set; }
        public DateTime? IdcreatedDate { get; set; }
        public int? Status { get; set; }
        public string SendPasswordTo { get; set; }

        public virtual House House { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<BalanceSheet> BalanceSheet { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<HelpdeskRequest> HelpdeskRequest { get; set; }
        public virtual ICollection<HelpdeskRequestLog> HelpdeskRequestLogAssignToUser { get; set; }
        public virtual ICollection<HelpdeskRequestLog> HelpdeskRequestLogChangeFromUser { get; set; }
        public virtual ICollection<NotificationChange> NotificationChange { get; set; }
        public virtual ICollection<NotificationObject> NotificationObject { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<Receipt> Receipt { get; set; }
        public virtual ICollection<Report> Report { get; set; }
        public virtual ICollection<UserAnswerPoll> UserAnswerPoll { get; set; }
        public virtual ICollection<UserRateAroundProvider> UserRateAroundProvider { get; set; }
    }
}
