using DataService.Models.Filter;
using DataService.Models.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Models.Services
{
    public interface IAroundProviderProductService
    {
        AroundProviderProduct GetAroundProviderProductById(int id);
        IEnumerable<AroundProviderProduct> GetAroundProviderProductFilter(AroundProviderProductGetFilter filter);
    }
    public class AroundProviderProductService : BaseUnitOfWork<UnitOfWork>, IAroundProviderProductService
    {
        public AroundProviderProductService(UnitOfWork uow) : base(uow)
        {
        }

        public AroundProviderProduct GetAroundProviderProductById(int id)
        {
            var result = _uow.AroundProviderProduct.GetAroundProviderProductByID(id);
            if (result == null)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        public IEnumerable<AroundProviderProduct> GetAroundProviderProductFilter(AroundProviderProductGetFilter filter)
        {
            var result = _uow.AroundProviderProduct.Get();
            if(result == null)
            {
                return null;
            }
            else
            {
                if(filter.AroundProviderId > 0)
                {
                    result = result.Where(p => p.AroundProviderId == filter.AroundProviderId);
                }
                return result;
            }
        }
    }
}
