using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyReg
{
    public class ExpiredItem
    {
        public string Name { get; set; }
        public DateTime? CertExpire { get; set; }
        public DateTime? SurveyExpire { get; set; }
        public DateTime? InsuranceExpire { get; set; }
    }
}
