using DataService.Models.Repositories.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Models.Repositories.Create
{
    public interface IHouseRepository : IBaseRepository<House>
    {
        House GetHouseById(int? id);
    }
    public class HouseRepository : Baserepository<House>, IHouseRepository
    {
        public HouseRepository(ApartmentDbContext Context) : base(Context)
        {
        }

        public House GetHouseById(int? id)
        {
            return Get().Where(p => p.Id == id).FirstOrDefault();
        }
    }

}
