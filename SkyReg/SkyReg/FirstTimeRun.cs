using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using System.Drawing;

namespace SkyReg
{
    public static class FirstTimeRun
    {
        //Uruchamiane podczas startu programu - za pierwszym razem dodaje stałe elementy do bazy
        public static void CheckAndAdd()
        {
            using(DLModelContainer model = new DLModelContainer())
            {
                //Czy jest grupa Pasażerowie tandemów
                var isPassengerGroup = model.Group.Any(p => p.Name == "Pasażerowie tandemów");
                if(isPassengerGroup == false)
                {
                    Group gp = new Group();
                    gp.Name = "Pasażerowie tandemów";
                    gp.Color = Color.LightPink.ToString();
                    gp.AllowDelete = false;
                    model.Group.Add(gp);
                    model.SaveChanges();
                }

                //Czy jest grupa Spadochroniarze
                var isSkydiversGroup = model.Group.Any(p => p.Name == "Skoczkowie");
                if(isSkydiversGroup == false)
                {
                    Group gp = new Group();
                    gp.Name = "Skoczkowie";
                    gp.Color = Color.LightGreen.ToString();
                    gp.AllowDelete = false;
                    model.Group.Add(gp);
                    model.SaveChanges();
                }

                //Czy jest użytkownik admin z hasłem 123 i jednocześnie jest operatorem
                var isAdmin = model.User.Any(p => p.Login == "admin"); ;
                if (isAdmin == false)
                {
                    User usr = new User();
                    usr.Login = "admin";
                    usr.Password = "s7PNTS7UQzg=";
                    usr.FirstName = "Admin";
                    usr.SurName = "Admin";
                    model.User.Add(usr);
                    model.SaveChanges();

                    Operator opr = new Operator();
                    opr.User = usr;
                    opr.Type = (int)Enum_OperatorTypes.Operator;
                    model.Operator.Add(opr);
                    model.SaveChanges();
                }
            }
        }
    }
}
