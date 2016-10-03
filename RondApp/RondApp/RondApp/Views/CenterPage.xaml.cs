using RondApp.DAL;
using RondApp.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RondApp.Views
{
    public partial class CenterPage : ContentPage
    {
        public CenterPage(double Latitude, double Longitude)
        {
            DbCenters db = new DbCenters();
            //todo:place centers pins on map
            CentersManager cMng = new CentersManager(db.GetDatabaseConn());

            cMng.GetByCoordinates(Latitude, Longitude);
            InitializeComponent();
        }
    }
}
