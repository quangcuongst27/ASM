using DataService.Models.Filter;
using DataService.Models.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Models.Services
{
    public interface IAroundProviderService
    {
        AroundProvider GetAroundProviderById(int id);
        IEnumerable<AroundProvider> GetAllAroundProvider(AroundPrividerGetFilter filter);
    }
    public class AroundProviderService : BaseUnitOfWork<UnitOfWork>, IAroundProviderService
    {
        public AroundProviderService(UnitOfWork uow) : base(uow)
        {
        }

        public IEnumerable<AroundProvider> GetAllAroundProvider(AroundPrividerGetFilter filter)
        {
            var result = _uow.AroundProvider.Get();
            if(result == null)
            {
                return null;
            }
            else
            {
                if (filter.AroundPrividerCategory > 0)
                {
                    result = result.Where(p => p.AroundProviderCategoryId == filter.AroundPrividerCategory);
                }
                if (result == null)
                {
                    return null;
                }
                else
                {
                    return result;
                }
            }
           
        }

        public AroundProvider GetAroundProviderById(int id)
        {
            var result = _uow.AroundProvider.GetAroundProviderById(id);
            if(result == null)
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
