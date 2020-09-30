using DataService.Models.Filter;
using DataService.Models.Repositories.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Models.Repositories.Create
{
    public interface IAroundProviderProduct : IBaseRepository<AroundProviderProduct>
    {
        AroundProviderProduct GetAroundProviderProductByID(int id);
      
    }
    public class AroundProviderProductRepository : Baserepository<AroundProviderProduct>, IAroundProviderProduct
    {
        public AroundProviderProductRepository(ApartmentDbContext Context) : base(Context)
        {
        }

        public AroundProviderProduct GetAroundProviderProductByID(int id)
        {
            return Get().Where(p => p.Id == id).FirstOrDefault();
        }

 
    }
}
