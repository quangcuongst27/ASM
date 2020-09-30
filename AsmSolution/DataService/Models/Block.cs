using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Block
    {
        public Block()
        {
            BlockPoll = new HashSet<BlockPoll>();
            House = new HashSet<House>();
        }

        public int Id { get; set; }
        public string BlockName { get; set; }

        public virtual ICollection<BlockPoll> BlockPoll { get; set; }
        public virtual ICollection<House> House { get; set; }
    }
}
