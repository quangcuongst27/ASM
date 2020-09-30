using DataService.Models.Repositories.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Models.Repositories.Create
{
    public interface IAroundProviderRepository : IBaseRepository<AroundProvider>
    {
        AroundProvider GetAroundProviderById(int id);
    }
    public class AroundProviderRepository : Baserepository<AroundProvider>, IAroundProviderRepository
    {
        public AroundProviderRepository(ApartmentDbContext Context) : base(Context)
        {
        }

        public AroundProvider GetAroundProviderById(int id)
        {
            return Get().Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
