using System;
using System.Linq;
using DataLayer;
using DataLayer.Result.Repository;
using Msg = AC.ExtendedRenderer.Toolkit.KryptonMessageBox;
using System.Windows.Forms;

namespace SkyReg
{
    public static class FirstTimeRun
    {
        //Uruchamiane podczas startu programu - za pierwszym razem dodaje stałe elementy do bazy
        private static readonly DLModelRepository<Group> _contextGroup = new DLModelRepository<Group>();
        private static readonly DLModelRepository<User> _contextUser = new DLModelRepository<User>();
        private static readonly DLModelRepository<Operator> _contextOperator = new DLModelRepository<Operator>();
        private static readonly DLModelRepository<PaymentsSetting> _contextPaymentsSetting = new DLModelRepository<PaymentsSetting>();
        
        public static void CheckAndAdd()
        {
            try
            {
                Group gpSkoczkowie = default(Group);

                using (_contextGroup)
                {
                    Group gp = default(Group);

                    //Czy jest grupa Spadochroniarze
                    var allGroups = _contextGroup.Table;
                    var isSkydiversGroup = allGroups.Where(p => p.Name == "Skoczkowie").FirstOrDefault();
                    if (isSkydiversGroup == null)
                    {
                        gp = new Group();
                        gp.Name = "Skoczkowie";
                        gp.Color = "White";
                        gp.AllowDelete = false;
                        if (_contextGroup.Insert(gp).IsSuccess)
                            gpSkoczkowie = gp;
                    }

                    //Czy jest grupa Pasażerowie tandemów
                    var isPassengerGroup = allGroups.Where(p => p.Name == "Pasażerowie tandemów").FirstOrDefault();
                    if (isPassengerGroup == null)
                    {
                        gp = new Group();
                        gp.Name = "Pasażerowie tandemów";
                        gp.Color = "LightPink";
                        gp.AllowDelete = false;
                        _contextGroup.Insert(gp);
                    }
                }
                using (_contextUser)
                using (_contextOperator)
                {
                    var allUsers = _contextUser.Table;
                    var allOperators = _contextOperator.Table;
                    var isAdmin = allUsers?.Where(p => p.Login == "admin").FirstOrDefault();
                    if (isAdmin == null)
                    {
                        var usr = new User()
                        {
                            Login = "admin",
                            Password = "s7PNTS7UQzg=",
                            FirstName = "Admin",
                            SurName = "Admin",
                            Group = gpSkoczkowie
                        };

                        var opr = new Operator()
                        {
                            User = usr,
                            Type = (int)OperatorTypes.Operator
                        };

                        _contextOperator.Insert(opr);
                    }
                }


                using (_contextPaymentsSetting)
                {
                    //Czy jest zdefiniowane KP
                    var inComeCash = (short)PaymentsTypes.Wpłata;
                    var outComeCash = (short)PaymentsTypes.Wypłata;

                    if (!_contextPaymentsSetting.Table.Any(p => p.Type == inComeCash))
                    {
                        var ps = new PaymentsSetting()
                        {
                            Type = inComeCash,
                            Name = "KP"
                        };

                        _contextPaymentsSetting.Insert(ps);
                    }

                    //Czy jest zdefiniowane KW
                    if (!_contextPaymentsSetting.Table.Any(p => p.Type == outComeCash))
                    {
                        var ps = new PaymentsSetting()
                        {
                            Type = outComeCash,
                            Name = "KW"
                        };

                        _contextPaymentsSetting.Insert(ps);
                    }
                }
            }
            catch (Exception ex)
            {
                Msg.Show($"Wystąpił błąd w {nameof(FirstTimeRun)}, treść : {ex.Message}", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
	
    }

}
