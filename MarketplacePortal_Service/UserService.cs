using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketplacePortal_Repository;
using MarketplacePortal_DAL;

namespace MarketplacePortal_Service
{
    public interface IUserService
    {
        //IEnumerable<tblUser> GetAllUsers();
        Boolean IsUserExist(string username, string password);
        void InsertUser(tblUser user);
 
    }
    public class UserService: IUserService
    {
        UnitOfWork uow = new UnitOfWork();
        
        private IEnumerable<tblUser> GetAllUsers()
        {
            IRepository<tblUser> userRepo = uow.UserRepository;
            return userRepo.GetAll();
        }

        public Boolean IsUserExist(string username, string password)
        {
            var users = from u in GetAllUsers()
                        select u;
            var count = -1;
            //check if UserName is email || username
            if (username.Contains("@"))
            {
                count = users.Where(u_db => u_db.UserEmail == username && u_db.UserPassword == password).Count();
            }
            else
            {
                count = users.Where(u_db => u_db.UserName == username && u_db.UserPassword == password).Count();
            }

            if (count == 1)
                return true;
            else return false;
        }

        public void InsertUser(tblUser user)
        {
            uow.UserRepository.Insert(user);
        }
    }
}
