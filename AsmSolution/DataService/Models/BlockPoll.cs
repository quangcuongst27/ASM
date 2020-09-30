using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class BlockPoll
    {
        public int BlockId { get; set; }
        public int PollId { get; set; }
        public string Name { get; set; }

        public virtual Block Block { get; set; }
        public virtual Poll Poll { get; set; }
    }
}
