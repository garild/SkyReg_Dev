using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyReg
{
    public class UsersFinances
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public decimal Count { get; set; }
        public int Type { get; set; }
    }
}
