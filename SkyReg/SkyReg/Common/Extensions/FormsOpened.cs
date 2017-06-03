using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyReg.Common.Extensions
{
    public sealed class FormsOpened<TFrom> where TFrom : class,new()
    {
        public static TFrom IsOpened(TFrom form)
        {
            if (form == default(TFrom))
                return Activator.CreateInstance<TFrom>();
            return form;
        }
    }
}
