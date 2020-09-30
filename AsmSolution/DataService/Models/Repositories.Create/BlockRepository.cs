using DataService.Models.Repositories.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Models.Repositories.Create
{
    public interface IBlockRepository : IBaseRepository<Block>
    {
        Block GetBlockById(int? id);
    }
    public class BlockRepository : Baserepository<Block>, IBlockRepository
    {
        public BlockRepository(ApartmentDbContext Context) : base(Context)
        {
        }

        public Block GetBlockById(int? id)
        {
            return Get().Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
