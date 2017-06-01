using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyReg
{
    public interface IUserTypeListElem
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal Value { get; set; }
        string Camera { get; set; }
    }
}
