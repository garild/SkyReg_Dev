using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyReg
{
    public class FlightsOnList
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string FlightsNr { get; set; }
        public string AirplaneNr { get; set; }
        public string Status { get; set; }
        public int Altitude { get; set; }
        public int AvailableSeats { get; set; }
    }
}
