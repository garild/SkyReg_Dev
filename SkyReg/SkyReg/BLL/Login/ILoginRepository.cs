using DataLayer;
using DataLayer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyReg.BLL.Repository
{
    public interface ILoginRepository
    {
        User GetUser(string login, string password);
        User AddUser(User newUser);
    }
}
