using System;
using System.Linq;
using DataLayer;
using DataLayer.Result.Repository;
using Msg = AC.ExtendedRenderer.Toolkit.KryptonMessageBox;
using System.Windows.Forms;
using SkyRegEnums;

namespace SkyReg
{
    public static class FirstTimeRun
    {
        //Uruchamiane podczas startu programu - za pierwszym razem dodaje stałe elementy do bazy
        private static readonly SkyRegContextRepository<Group> _contextGroup = new SkyRegContextRepository<Group>();
        private static readonly SkyRegContextRepository<User> _contextUser = new SkyRegContextRepository<User>();
        private static readonly SkyRegContextRepository<Operator> _contextOperator = new SkyRegContextRepository<Operator>();
        private static readonly SkyRegContextRepository<PaymentsSetting> _contextPaymentsSetting = new SkyRegContextRepository<PaymentsSetting>();
        
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
                        if (_contextGroup.InsertEntity(gp).IsSuccess)
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
                        _contextGroup.InsertEntity(gp);
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
                            Name ="Dev",
                            Group = gpSkoczkowie
                        };

                        var opr = new Operator()
                        {
                            User = usr,
                            Type = (int)OperatorTypes.Operator
                        };

                        _contextOperator.InsertEntity(opr);
                    }
                }
                using (var _ctxPaySettings = new SkyRegContextRepository<PaymentsSetting>())
                {
                    //Czy jest zdefiniowane KP
                    var inComeCash = (short)PaymentsTypes.KP;
                    var outComeCash = (short)PaymentsTypes.KW;
                    var charge = (short)PaymentsTypes.Naleznosc;
                    var commitment = (short)PaymentsTypes.Zobowiazanie;
                  
                    if (!_ctxPaySettings.Table.Any(p => p.Type == inComeCash))
                    {
                        PaymentsSetting ps = new PaymentsSetting();
                        ps.Type = inComeCash;
                        ps.Name = "KP";
                        _ctxPaySettings.InsertEntity(ps);
                    }

                    //Czy jest zdefiniowane KW
                    if (!_ctxPaySettings.Table.Any(p => p.Type == outComeCash))
                    {
                        PaymentsSetting ps = new PaymentsSetting();
                        ps.Type = outComeCash;
                        ps.Name = Enum.GetName(typeof(PaymentsTypes), PaymentsTypes.KW);
                        ps.Value = 0;
                        ps.Count = 0;
                        _ctxPaySettings.InsertEntity(ps);
                    }
               
                    if (!_ctxPaySettings.Table.Any(p => p.Type == charge))
                    {
                        PaymentsSetting ps = new PaymentsSetting();
                        ps.Type = charge;
                        ps.Name = "Należność";
                        _ctxPaySettings.InsertEntity(ps);
                    }

                    if (!_contextPaymentsSetting.Table.Any(p => p.Type == commitment))
                    {
                        PaymentsSetting ps = new PaymentsSetting();
                        ps.Type = commitment;
                        ps.Name = "Zobowiązanie";
                        _ctxPaySettings.InsertEntity(ps);
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
