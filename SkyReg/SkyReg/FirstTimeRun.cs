﻿using System;
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
            using (DLModelRepository<Group> _contextGroup = new DLModelRepository<Group>())
            {
                //Czy jest grupa Spadochroniarze
                var allGroups = _contextGroup.GetAll();
                var isSkydiversGroup = allGroups.Where(p => p.Name == "Skoczkowie").FirstOrDefault();
                if (isSkydiversGroup == null)
                {
                    Group gp = new Group();
                    gp.Name = "Skoczkowie";
                    gp.Color = "White";
                    gp.AllowDelete = false;
                    _contextGroup.Add(gp);
                }

                //Czy jest grupa Pasażerowie tandemów
                var isPassengerGroup = allGroups.Where(p => p.Name == "Pasażerowie tandemów").FirstOrDefault();
                if (isPassengerGroup == null)
                {
                    Group gp = new Group();
                    gp.Name = "Pasażerowie tandemów";
                    gp.Color = "LightPink";
                    gp.AllowDelete = false;
                    _contextGroup.Add(gp);
                }
            }
            using (DLModelRepository<User> _contextUser = new DLModelRepository<User>())
            using (DLModelRepository<Operator> _contextOperator = new DLModelRepository<Operator>())
            {
                var allUsers = _contextUser.GetAll();
                var allOperators = _contextOperator.GetAll();
                var isAdmin = allUsers.Where(p => p.Login == "admin").FirstOrDefault();
                if (isAdmin == null)
                {
                    User usr = new User();
                    usr.Login = "admin";
                    usr.Password = "s7PNTS7UQzg=";
                    usr.FirstName = "Admin";
                    usr.SurName = "Admin";
                    
                    Operator opr = new Operator();
                    opr.User = usr;
                    opr.Type = (int)Enum_OperatorTypes.Operator;
                    _contextOperator.Add(opr);
                }
            }
        }
    }
        
}
