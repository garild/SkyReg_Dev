using System;
using ComponentFactory.Krypton.Toolkit;
using DataLayer;
using DataLayer.Result.Repository;
using System.Linq;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using DataLayer.Utils;

namespace DepartureDiagram
{
    public partial class Departures : KryptonForm
    {
        private readonly DLModelRepository<Flight> _flight = new DLModelRepository<Flight>();
        public Departures()
        {
            InitializeComponent();
            LoadData();
        }

       

        private void LoadData()
        {
            groupListView.Items.Clear();

            using (_flight)
            {
                //var data = (from p in _flight.Table group p by p.FlyNr into groupList select groupList).ToDictionary(x => x.Key, y => y.ToList());

                var data = _flight.GetAll().Value;
                data.ForEach(p =>
                    {
                        groupListView.Items.Add(p.FlyNr);
                    }
                );
                var d = groupListView.Items.Count;

            }
        }
    }
}
