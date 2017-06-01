using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyReg
{
    public class ParachuteListElem : IParachuteListElem
    {
        public int Id { get; set; }
        public string IdNr { get; set; }
        public string Name { get; set; }
        public decimal RentValue { get; set; }
        public decimal AssemblyValue { get; set; }
        public string OwnerName { get; set; }
        public int UserId { get; set; }
    }
}
