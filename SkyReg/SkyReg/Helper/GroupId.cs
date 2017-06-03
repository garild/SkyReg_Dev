using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;

namespace SkyReg.Helper
{
    public static class GroupId
    {
        private static int skoczkowie;
        private static int pasazerowie;

        public static int Skoczkowie
        {
            get {
                using(DLModelContainer model = new DLModelContainer())
                {
                    skoczkowie = model.Group.Where(p => p.Name == "Skoczkowie").Select(p=>p.Id).First();
                }
                return skoczkowie;
            }
        }

        public static int Pasazerowie
        {
            get
            {
                using(DLModelContainer model = new DLModelContainer())
                {
                    pasazerowie = model.Group.Where(p => p.Name == "Pasażerowie tandemów").Select(p => p.Id).First();
                }
                return pasazerowie;
            }
        }


    }
}
