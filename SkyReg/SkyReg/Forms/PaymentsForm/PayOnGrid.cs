using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyReg
{
    public class PayOnGrid
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public decimal Count { get; set; }
        public DateTime Date { get; set; }
        public string PayType { get; set; }
        public string UserName { get; set; }
    }
}
