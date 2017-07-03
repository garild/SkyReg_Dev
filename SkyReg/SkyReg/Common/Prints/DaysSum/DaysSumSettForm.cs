using ComponentFactory.Krypton.Toolkit;
using DataLayer.Entities.DBContext;
using SkyReg.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyReg.Common.Prints.DaysSum
{
    public partial class DaysSumSettForm : KryptonForm
    {
        public DaysSumSettForm()
        {
            InitializeComponent();
            datSince.Value = DateTime.Now.Date;
            datTo.Value = DateTime.Now.Date;
        }

        private void btnSaveCfg_Click(object sender, EventArgs e)
        {
            if (ValidateData() == true)
            {
                DataPreparing();
            }
        }

        private void DataPreparing()
        {
            this.Close();
            //Nagłówek wydruku
            var htmlBuilder = new StringBuilder();
            htmlBuilder.AppendLine(HtmlTemplate.TempalteHtml.FormatWith(new
            {
                DateSince = datSince.Value.ToString("yyyy-MM-dd"),
                DateTo = datTo.Value.ToString("yyyy-MM-dd")
            }));

            //Zestawienie KP i KW
            htmlBuilder.AppendLine(HtmlTemplate.TableStart);
            htmlBuilder.AppendLine(HtmlTemplate.singleRow.FormatWith(new
            {
                Element1 = "Suma KP:",
                Element2 = GetKPSumByDate()
            }));
            htmlBuilder.AppendLine(HtmlTemplate.singleRow.FormatWith(new
            {
                Element1 = "Suma KW:",
                Element2 = GetKWSumByDate()
            }));
            htmlBuilder.AppendLine(HtmlTemplate.TableEnd);
            htmlBuilder.AppendLine(HtmlTemplate.DrawLine);
            //Zestawienie skoków wg typów
            htmlBuilder.AppendLine(HtmlTemplate.Title.FormatWith(new
            {
                Title = "Zestawienie skoków wg typu"
            }));
            
            htmlBuilder.AppendLine(HtmlTemplate.TableStart);
            htmlBuilder.AppendLine(HtmlTemplate.UserTypesRow.FormatWith(new
            {
                Element1 = "Nazwa",
                Element2 = "Ilość",
                Element3 = "Cena",
                Element4 = "Wartość"
            }));
            List<UsersTypesOnTally> usrTypes = TallyByUserType();
            foreach(UsersTypesOnTally item in usrTypes)
            {
                htmlBuilder.AppendLine(HtmlTemplate.UserTypesRow.FormatWith(new
                {
                    Element1 = item.Name,
                    Element2 = item.Count,
                    Element3 = item.Price,  
                    Element4 = decimal.Parse( item.Price, CultureInfo.CurrentCulture) * item.Count
                }));
            }
            htmlBuilder.AppendLine(HtmlTemplate.TableEnd);
            htmlBuilder.AppendLine(HtmlTemplate.DrawLine);
            //Zestawienie układek wg ceny
            htmlBuilder.AppendLine(HtmlTemplate.Title.FormatWith(new
            {
                Title = "Zestawienie układek według ceny"
            }));
            htmlBuilder.AppendLine(HtmlTemplate.TableStart);
            htmlBuilder.AppendLine(HtmlTemplate.AssemblyRow.FormatWith(new
            {
                Element1 = "Cena",
                Element2 = "Ilość",
                Element3 = "Wartość"
            }));
            List<AssemblyByPriceOnTally> assemblyByPrice = TallyAssemblyByPrice();
            foreach(AssemblyByPriceOnTally item in assemblyByPrice)
            {
                htmlBuilder.AppendLine(HtmlTemplate.AssemblyRow.FormatWith(new
                {
                    Element1 = item.Price,
                    Element2 = item.Count,
                    Element3 = item.Price * item.Count
                }));
            }
            htmlBuilder.AppendLine(HtmlTemplate.TableEnd);
            htmlBuilder.AppendLine(HtmlTemplate.DrawLine);
            //Zestawienie tych którym należy się kasa - piloci tandemów
            htmlBuilder.AppendLine(HtmlTemplate.Title.FormatWith(new
            {
                Title = "Piloci tandemów"
            }));
            htmlBuilder.AppendLine(HtmlTemplate.TableStart);
            htmlBuilder.AppendLine(HtmlTemplate.PilotsRow.FormatWith(new
            {
                Element1 = "Użytkownik",
                Element2 = "Typ skoczka",
                Element3 = "Ilość",
                Element4 = "Cena",
                Element5 = "Wartość"
            }));
            List<PilotsOnTally> pilots = JumpersForMoney();
            foreach(PilotsOnTally item in pilots)
            {
                htmlBuilder.AppendLine(HtmlTemplate.PilotsRow.FormatWith(new
                {
                    Element1 = item.UserName,
                    Element2 = item.UserType,
                    Element3 = item.Count,
                    Element4 = item.Price,
                    Element5 = item.Count * item.Price
                }));
            }
            htmlBuilder.AppendLine(HtmlTemplate.TableEnd);
            htmlBuilder.AppendLine(HtmlTemplate.DrawLine);
            //Zestawienie skoków z kamerą
            htmlBuilder.AppendLine(HtmlTemplate.Title.FormatWith(new
            {
                Title = "Zestawienie skoków z kamerą"
            }));

            decimal camPrice = default(decimal);
            int camJumpCount = JumpsWithCamera(out camPrice);
            htmlBuilder.AppendLine(HtmlTemplate.TableStart);
            htmlBuilder.AppendLine(HtmlTemplate.CameraRow.FormatWith(new
            {
                Element1 = "",
                Element2 = "Ilość",
                Element3 = "Cena",
                Element4 = "Wartość"
            }));
            htmlBuilder.AppendLine(HtmlTemplate.CameraRow.FormatWith(new
            {
                Element1 = "Skoków z kamerą:",
                Element2 = camJumpCount,
                Element3 = camPrice,
                Element4 = camPrice * camJumpCount
            }));
            htmlBuilder.AppendLine(HtmlTemplate.TableEnd);
            htmlBuilder.AppendLine(HtmlTemplate.DrawLine);

            DaysSumForm dsf = new DaysSumForm(htmlBuilder.ToString());
            dsf.ShowDialog();

        }

        private int JumpsWithCamera(out decimal cameraPrice)
        {
            using(SkyRegContext ctx = new SkyRegContext())
            {
                int camJumpCount = ctx
                    .FlightsElem
                    .Include("Flight")
                    .Include("DefinedUserType")
                    .Where(p => p.Flight.FlyDateTime >= datSince.Value.Date && p.Flight.FlyDateTime <= datTo.Value.Date && p.DefinedUserType.IsCam == true)
                    .Count();

                cameraPrice = ctx.GlobalSetting.Where(p => p.Id == 1).Select(p => p.CamPrice.Value).FirstOrDefault();

                return camJumpCount;
            }
        }

        private List<PilotsOnTally> JumpersForMoney()
        {
            List<PilotsOnTally> list = new List<PilotsOnTally>();

            using(SkyRegContext ctx = new SkyRegContext())
            {
                //pobieram typy użytkownika które mają wartość na minusie
                List<int> idsUsersType = ctx
                    .DefinedUserType
                    .Where(p => p.Value < 0)
                    .Select(p => p.Id)
                    .ToList();

                list = ctx
                    .FlightsElem
                    .Include("Flight")
                    .Where(p => p.Flight.FlyDateTime >= datSince.Value.Date && p.Flight.FlyDateTime <= datTo.Value.Date)
                    .Where(p => idsUsersType.Contains(p.UsersTypeId.Value))
                    .GroupBy(p => new { p.UsersTypeId, p.User_Id })
                    .Select(p => new
                    {
                        userTypeId = p.Key.UsersTypeId,
                        userId = p.Key.User_Id,
                        count = p.Count()
                    })
                    .Select(p => new PilotsOnTally
                    {
                        UserType = ctx.DefinedUserType.Where(q => q.Id == p.userTypeId).Select(q => q.Name).FirstOrDefault(),
                        Price = ctx.DefinedUserType.Where(q=>q.Id == p.userTypeId).Select(q=>q.Value).FirstOrDefault(),
                        UserName = ctx.User.Where(q => q.Id == p.userId).Select(q => q.Name).FirstOrDefault(),
                        Count = p.count
                    }).ToList();
                return list;    
            }
        }

        private List<AssemblyByPriceOnTally> TallyAssemblyByPrice()
        {
            List<AssemblyByPriceOnTally> list = new List<AssemblyByPriceOnTally>();

            using(SkyRegContext ctx = new SkyRegContext())
            {
                list = ctx
                    .Payment
                    .Where(p => p.Date >= datSince.Value.Date && p.Date <= datTo.Value.Date && p.ChargeType == (int)SkyRegEnums.ChargesTypes.ParachuteAssembly)
                    .GroupBy(p => p.Value)
                    .Select(p => new AssemblyByPriceOnTally
                    {
                        Count = p.Count(),
                        Price = p.Key
                    }).ToList();
            }

            return list;
        }

        private List<UsersTypesOnTally> TallyByUserType()
        {
            List<UsersTypesOnTally> list = new List<UsersTypesOnTally>();

            using (SkyRegContext ctx = new SkyRegContext())
            {
                list = ctx.FlightsElem
                .Include("Flight")
                .Where(p => p.Flight.FlyDateTime >= datSince.Value.Date && p.Flight.FlyDateTime <= datTo.Value.Date && p.UsersTypeId != null)
                .GroupBy(p => p.UsersTypeId)
                .ToList()
                .Select(p => new UsersTypesOnTally
                {
                    Count = p.Count(),
                    Name = ctx.DefinedUserType.Where(q => q.Id == p.Key).Select(q => q.Name).First(),
                    Price = ctx.DefinedUserType.Where(q => q.Id == p.Key).Select(q => q.Value).First().ToString()
                }).ToList();

            }

            return list;
        }

        private object GetKWSumByDate()
        {
            decimal result = default(decimal);

            using (SkyRegContext ctx = new SkyRegContext())
            {
                var KWResult = ctx
                    .Payment
                    .Include("PaymentsSetting")
                    .Where(p => p.Date >= datSince.Value && p.Date <= datTo.Value && (int)p.PaymentsSetting.Type == (int)SkyRegEnums.PaymentsTypes.KW)
                    .ToList();

                if (KWResult.Count > 0)
                    result = KWResult.Sum(p => p.Value);
                else
                    result = default(decimal);
            }

            return result;
        }

        private decimal GetKPSumByDate()
        {
            decimal result = default(decimal);

            using (SkyRegContext ctx = new SkyRegContext())
            {
                var KPResult = ctx
                    .Payment
                    .Include("PaymentsSetting")
                    .Where(p => p.Date >= datSince.Value && p.Date <= datTo.Value && (int)p.PaymentsSetting.Type == (int)SkyRegEnums.PaymentsTypes.KP)
                    .ToList();

                if (KPResult.Count > 0)
                    result = KPResult.Sum(p => p.Value);
                else
                    result = default(decimal);
            }

            return result;
        }

        private bool ValidateData()
        {
            bool result = true;

            errorProvider1.Clear();

            if (datSince.Value == null)
            {
                errorProvider1.SetError(datSince, "Wartość nie może być pusta!");
                result = false;
            }
            if (datTo.Value == null)
            {
                errorProvider1.SetError(datTo, "Wartość nie może być pusta!");
                result = false;
            }

            if (datSince.Value > datTo.Value)
            {
                errorProvider1.SetError(datSince, "Okres od nie może być większy niż okres do!");
                errorProvider1.SetError(datTo, "Okres od nie może być większy niż okres do!");
                result = false;
            }
            return result;
        }
    }
}
