using DataLayer;
using SkyReg.BLL.Repository;
using System.Linq;
using System;

namespace SkyReg.BLL.Services
{
    public class LoginRepository : ILoginRepository
    {
        public static readonly DLModelContainer _dbContext = new DLModelContainer();

        public LoginRepository()
        {

        }

        public User AddUser(User newUser)
        {
           var d = _dbContext.User.Add(newUser);
            _dbContext.SaveChanges();

            return d;
        }

        public User GetUser(string login, string password) => _dbContext.User.AsNoTracking().Where(p => p.Login == login && p.Password == password).FirstOrDefault();
    }
}
