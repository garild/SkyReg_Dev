using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyReg
{
    public partial class LicenceInfoForm : KryptonForm
    {
        public LicenceInfoForm()
        {
            InitializeComponent();
        }

        private void LicenceInfoForm_Load(object sender, EventArgs e)
        {
            txtForFirm.Text = "Sky Force Piotrków Tryb.";
            if (Settings.Default.LicenceKey == "0okm)OKM")
                txtExpirienceDate.Text = "2017-07-31";
            else if (Settings.Default.LicenceKey == "ZAQ12wsx")
                txtExpirienceDate.Text = "Bezterminowa";
            else
                txtExpirienceDate.Text = "Brak";

            txtLicenceInfo.Text = @"WAŻNE — PROSIMY DOKŁADNIE ZAPOZNAĆ SIĘ Z TREŚCIĄ: Niniejsza Umowa Licencyjna Użytkownika Oprogramowania(„Umowa Licencyjna”) stanowi prawnie wiążące porozumienie pomiędzy osobą fizyczną lub prawną(„Licencjobiorcą”) i firmą @ps dev studio Paweł Smużny. Przedmiotem Umowy Licencyjnej  jest oprogramowanie firmy @ps dev studio określone powyżej, które obejmuje oprogramowanie komputerowe oraz może obejmować związane z nim nośniki, materiały drukowane, dokumentację w formie „online” oraz dokumentację elektroniczną(„Produkt”).Produktowi mogą towarzyszyć poprawki lub uzupełnienia do niniejszej Umowy Licencyjnej .PRZEZ INSTALOWANIE, KOPIOWANIE LUB KORZYSTANIE PRODUKTU LICENCJOBIORCA ZGADZA SIĘ PRZESTRZEGAĆ POSTANOWIEŃ NINIEJSZEJ UMOWY LICENCYJNEJ.JEŚLI LICENCJOBIORCA NIE ZGADZA SIĘ Z POSTANOWIENIAMI UMOWY LICENCYJNEJ, NIE MOŻE INSTALOWAĆ ANI KORZYSTAĆ Z PRODUKTU, NATOMIAST MOŻE GO ZWRÓCIĆ W MIEJSCU NABYCIA W ZAMIAN ZA ZWROT ZAPŁACONEJ KWOTY W PEŁNEJ WYSOKOŚCI.  Ponadto przez instalowanie, kopiowanie lub inne korzystanie z subskrypcyjnych aktualizacji, które Licencjobiorca otrzymał jako część Produktu(„AKTUALIZACJE”), Licencjobiorca zgadza się przestrzegać dodatkowych postanowień licencyjnych towarzyszących tym AKTUALIZACJOM.  Jeśli Licencjobiorca nie zgadza się z tymi dodatkowymi postanowieniami licencyjnymi towarzyszącymi AKTUALIZACJOM, nie może instalować, kopiować ani używać tych AKTUALIZACJI.";
        }
    }
}
