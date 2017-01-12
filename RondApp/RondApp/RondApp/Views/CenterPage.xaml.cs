using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using RondApp.DAL;
using RondApp.Entities;
using RondApp.Managers;
using RondApp.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RondApp.Views
{
    public partial class CenterPage : ContentPage
    {
        private DbCenters db = new DbCenters();
        private CenterDetailed center;
     
        public  CenterPage(int centerId)
        {   
            InitializeComponent();
            CentersManager cMng = new CentersManager(db.GetDatabaseConn());

            this.center = cMng.GetById(centerId);      
            BindData(center);

        }

        public CenterPage(CenterDetailed center)
        {
            InitializeComponent();

            this.center = center;
            BindData(center);
        }

        private async void BindData(CenterDetailed center)
        {
            PageTitleArea.BackgroundColor = Color.FromHex(center.Color);
            CenterDarkAccent.BackgroundColor = Color.FromHex(center.ColorDark);
            //OpenStatus.BackgroundColor = Color.FromHex(center.OpenColor);
            CenterName.Text = center.Name;
            CenterType.Text = center.TypeName;
            OpenStatusLbl.Text = center.OpenNow == "A" ? "APERTO" : "CHIUSO";

            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Phone);
            if (status != PermissionStatus.Granted)
            {
                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Phone))
                {
                    await DisplayAlert("Permesso Telefono", "è richiesto il permesso di poter effettuare telefonate", "OK");
                }

                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Phone });
                status = results[Permission.Location];
            }

            if (status == PermissionStatus.Granted)
            {
                SetCallButtonVisible(true);
             
            }
            else if (status != PermissionStatus.Unknown)
            {
                SetCallButtonVisible(false);
                //bind center data
                CenterDetailGrid.BindingContext = center;
            }

            //bind center data
            CenterDetailGrid.BindingContext = center;

        }

        protected void OnOrariClicked(object sender, EventArgs e)
        {
            NoHours.IsVisible = false;
            CenterHours.IsVisible = true;
            CenterDetailGrid.IsVisible = false;
          
            if (CenterHours.ItemsSource == null)
            {
                CentersManager cMng = new CentersManager(db.GetDatabaseConn());
                List<OpeningHoursDetailed> centerOpenings = cMng.GetCenterOpeningsHours(this.center.ID);
                CenterHours.ItemsSource = centerOpenings;
                if (centerOpenings.Count == 0)
                    NoHours.IsVisible = true;
            }

            BtnInfo.IsVisible = true;
            BtnHours.IsVisible = false;
                 
        }

        protected void OnCallClicked(object sender, EventArgs e)
        {
            var dialer = DependencyService.Get<IDialer>();
            if (dialer != null)
            {
                dialer.Dial(center.PhoneNumber);
            }

        }

        protected void OnInfoClicked(object sender, EventArgs e)
        {
            BtnHours.IsVisible = true;
            BtnInfo.IsVisible = false;
           
            CenterHours.IsVisible = false;
            CenterDetailGrid.IsVisible = true;

        }

        private void SetCallButtonVisible(bool granted)
        {
            if (!string.IsNullOrWhiteSpace(center.PhoneNumber) && granted)
            {
                BtnCall.IsVisible = true;
            }
        }

    }
}
