using RondApp.DAL;
using RondApp.Entities;
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

        public CenterPage(int centerId)
        {
            InitializeComponent();

            DbCenters db = new DbCenters();
            //todo:place centers pins on map
            CentersManager cMng = new CentersManager(db.GetDatabaseConn());
            CenterDetailed center = cMng.GetById(centerId);
            BindData(center);





        }

        public CenterPage(double Latitude, double Longitude)
        {

            InitializeComponent();
            DbCenters db = new DbCenters();
            //todo:place centers pins on map
            CentersManager cMng = new CentersManager(db.GetDatabaseConn());

            List<CenterDetailed> centers = cMng.GetByCoordinates(Latitude, Longitude);

            //if more than one go to list

            BindData(centers.First());
          
        }


        private void BindData(CenterDetailed center)
        {

            PageTitleArea.BackgroundColor = Color.FromHex(center.Color);
            CenterDarkAccent.Color = Color.FromHex(center.ColorDark);
            OpenStatus.BackgroundColor = Color.FromHex(center.OpenColor);
            CenterName.Text = center.Name;
            CenterType.Text = center.TypeName;
            OpenStatusLbl.Text = center.OpenNow == "A" ? "APERTO" : "CHIUSO";


            CenterDetailGrid.BindingContext = center;


        }

    }
}
