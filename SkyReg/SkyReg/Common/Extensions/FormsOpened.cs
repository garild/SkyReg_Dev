using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyReg.Common.Extensions
{
    public sealed class FormsOpened<TFrom> where TFrom : class
    {
        public static TFrom IsOpened(TFrom form)
        {
            if (form == default(TFrom))
                return Activator.CreateInstance<TFrom>();
                
            return form;
        }

        public static TFrom IsShowDialog(TFrom form)
        {
            if (form == default(TFrom))
            {
                form = Activator.CreateInstance<TFrom>();
                var newForm = (form as KryptonForm);
                newForm.WindowState = System.Windows.Forms.FormWindowState.Normal;
                newForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                newForm.TopLevel = true;
                newForm.BringToFront();
                newForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            }
            return form;
        }
    }
}
