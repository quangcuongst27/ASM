using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Poll
    {
        public Poll()
        {
            BlockPoll = new HashSet<BlockPoll>();
            UserAnswerPoll = new HashSet<UserAnswerPoll>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? Status { get; set; }
        public string Question { get; set; }
        public int? Mode { get; set; }
        public int? Priority { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string Answer5 { get; set; }

        public virtual ICollection<BlockPoll> BlockPoll { get; set; }
        public virtual ICollection<UserAnswerPoll> UserAnswerPoll { get; set; }
    }
}
