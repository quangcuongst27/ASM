using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class UserAnswerPoll
    {
        public int PollId { get; set; }
        public int UserId { get; set; }
        public string Answer { get; set; }
        public DateTime? AnswerDate { get; set; }

        public virtual Poll Poll { get; set; }
        public virtual User User { get; set; }
    }
}
