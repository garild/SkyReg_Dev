using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using System.Drawing;
using SkyReg.BLL.Services;
using DataLayer.Result.Repository;
using DataLayer.Utils;

namespace SkyReg
{
    public static class FirstTimeRun
    {
        //Uruchamiane podczas startu programu - za pierwszym razem dodaje stałe elementy do bazy
      
        public static void CheckAndAdd()
        {
            Group gpSkoczkowie = default(Group);

            using (DLModelRepository<Group> _contextGroup = new DLModelRepository<Group>())
            {
                Group gp = default(Group);
                
                //Czy jest grupa Spadochroniarze
                var allGroups = _contextGroup.GetAll();
                    var isSkydiversGroup = allGroups.Value.Where(p => p.Name == "Skoczkowie").FirstOrDefault();
                    if (isSkydiversGroup == null)
                    {
                        gp = new Group();
                        gp.Name = "Skoczkowie";
                        gp.Color = "White";
                        gp.AllowDelete = false;
                        if( _contextGroup.Insert(gp).IsSuccess)
                            gpSkoczkowie = gp;
                    }



                    //Czy jest grupa Pasażerowie tandemów
                    var isPassengerGroup = allGroups.Value.Where(p => p.Name == "Pasażerowie tandemów").FirstOrDefault();
                    if (isPassengerGroup == null)
                    {
                        gp = new Group();
                        gp.Name = "Pasażerowie tandemów";
                        gp.Color = "LightPink";
                        gp.AllowDelete = false;
                        _contextGroup.Insert(gp);
                    }
            }
            using (DLModelRepository<User> _contextUser = new DLModelRepository<User>())
            using (DLModelRepository<Operator> _contextOperator = new DLModelRepository<Operator>())
            {
                var allUsers = _contextUser.GetAll();
                var allOperators = _contextOperator.GetAll();
                var isAdmin = allUsers.Value.Where(p => p.Login == "admin").FirstOrDefault();
                if (isAdmin == null)
                {
                    User usr = new User();
                    usr.Login = "admin";
                    usr.Password = "s7PNTS7UQzg=";
                    usr.FirstName = "Admin";
                    usr.SurName = "Admin";
                    usr.Group = gpSkoczkowie;
                    
                    Operator opr = new Operator();
                    opr.User = usr;
                    opr.Type = (int)OperatorTypes.Operator;
                    _contextOperator.Insert(opr);
                }
            }
        }
    }
        
}
