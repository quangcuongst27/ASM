using DataService.Models.Repositories.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Models.Repositories.Create
{
   public interface IUserRepository : IBaseRepository<User>
    {
        User CheckLogin(string username, string password);
        User GetUserById(int id);
        User CheckUsername(string username);
    }
    public class UserRepository : Baserepository<User>, IUserRepository
    {
        public UserRepository(ApartmentDbContext Context) : base(Context)
        {
        }

        public User CheckLogin(string username, string password)
        {
            return Get().Where(p => p.Username == username && p.Password == password).FirstOrDefault();
        }

        public User CheckUsername(string username)
        {
            return Get().Where(p => p.Username == username).FirstOrDefault();
        }

        public User GetUserById(int id)
        {
            return Get().Where(p => p.Id == id ).FirstOrDefault();
        }
    }

}
