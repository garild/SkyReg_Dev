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
                            FirstName = "Admin",
                            SurName = "Admin",
                            Group = gpSkoczkowie
                        };
                       
                        var opr = new Operator()
                        {
                            User = usr,
                            Type = (int)OperatorTypes.Operator
                        };

                        _contextOperator.InsertEntity(opr,false);
                    }
                }
                using (DLModelContainer model = new DLModelContainer())
                {
                    //Czy jest zdefiniowane KP
                    var inComeCash = (short)PaymentsTypes.KP;
                    var outComeCash = (short)PaymentsTypes.KW;
                    var charge = (short)PaymentsTypes.Naleznosc;
                    var commitment = (short)PaymentsTypes.Zobowiazanie;
                    bool isIncomeCash = model.PaymentsSetting.Any(p => p.Type == inComeCash);
                    if (isIncomeCash == false)
                    {
                        PaymentsSetting ps = new PaymentsSetting();
                        ps.Type = inComeCash;
                        ps.Name = "KP";
                        model.PaymentsSetting.Add(ps);
                        model.SaveChanges();
                    }

                    //Czy jest zdefiniowane KW
                    bool isExpenditureCash = model.PaymentsSetting.Any(p => p.Type == outComeCash);
                    if (isExpenditureCash == false)
                    {
                        PaymentsSetting ps = new PaymentsSetting();
                        ps.Type = outComeCash;
                        ps.Name = Enum.GetName(typeof(PaymentsTypes), PaymentsTypes.KW);
                        ps.Value = 0;
                        ps.Count = 0;
                        model.PaymentsSetting.Add(ps);
                        model.SaveChanges();
                    }

                    bool isCharge = model.PaymentsSetting.Any(p => p.Type == charge);
                    if (isCharge  == false)
                    {
                        PaymentsSetting ps = new PaymentsSetting();
                        ps.Type = charge;
                        ps.Name = "Należność";
                        model.PaymentsSetting.Add(ps);
                        model.SaveChanges();
                    }

                    bool isCommitment = model.PaymentsSetting.Any(p => p.Type == commitment);
                    if (isCommitment == false)
                    {
                        PaymentsSetting ps = new PaymentsSetting();
                        ps.Type = commitment;
                        ps.Name = "Zobowiązanie";
                        model.PaymentsSetting.Add(ps);
                        model.SaveChanges();
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
