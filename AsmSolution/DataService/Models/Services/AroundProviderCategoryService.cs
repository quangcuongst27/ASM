using DataService.Models.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Models.Services
{
    public interface IAroundProviderCategoryService
    {
        AroundProviderCategory GetAroundProviderCategoryById(int id);
        IEnumerable<AroundProviderCategory> GetAllProviderCategory();
    }
    public class AroundProviderCategoryService : BaseUnitOfWork<UnitOfWork>, IAroundProviderCategoryService
    {
        public AroundProviderCategoryService(UnitOfWork uow) : base(uow)
        {
        }

        public IEnumerable<AroundProviderCategory> GetAllProviderCategory()
        {
            var result = _uow.AroundPrividerCategory.Get();
            if(result == null)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        public AroundProviderCategory GetAroundProviderCategoryById(int id)
        {
            var result = _uow.AroundPrividerCategory.GetAroundProviderCategoryById(id);
            if( result == null)
            {
                return null;
            }
            else
            {
                return result;
            }
        }
    }
}
