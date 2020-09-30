using DataService.Models.Repositories.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Models.Repositories.Create
{
    public interface IAroundProviderCategoryRepository : IBaseRepository<AroundProviderCategory>
    {
        AroundProviderCategory GetAroundProviderCategoryById(int id);
       
    }
    public class AroundProviderCategoryRepository : Baserepository<AroundProviderCategory>, IAroundProviderCategoryRepository
    {
        public AroundProviderCategoryRepository(ApartmentDbContext Context) : base(Context)
        {
        }

   

        public AroundProviderCategory GetAroundProviderCategoryById(int id)
        {
            return Get().Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
