using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyReg
{
    class UserTypeListElem : IUserTypeListElem
    {
        public int Id { get; set ; }
        public string Name { get; set ; }
        public decimal Value { get; set; }
        public string Camera { get; set; }
    }
}
