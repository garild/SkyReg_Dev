using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyReg
{
    public interface IParachuteListElem
    {
        int Id { get; set; }
        string IdNr { get; set; }
        string Name { get; set; }
        decimal RentValue { get; set; }
        decimal AssemblyValue { get; set; }
        string OwnerName { get; set; }
        int UserId { get; set; }
    }
}
