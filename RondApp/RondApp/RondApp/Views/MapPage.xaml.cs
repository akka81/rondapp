using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using RondApp.Managers;
using RondApp.DAL;
using RondApp.Models;

namespace RondApp.Views
{
    public partial class MapPage : ContentPage
    {

        public MapPage()
        {
           

            GetCurrentPositionAsync();
        }

        public async void GetCurrentPositionAsync()
        {
           
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            if (status != PermissionStatus.Granted)
            {
                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                {
                    await DisplayAlert("Need location", "Gunna need that location", "OK");
                }

                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Location });
                status = results[Permission.Location];
            }

            if (status == PermissionStatus.Granted)
            {
                InitializeComponent();

                var locator = CrossGeolocator.Current;

                locator.DesiredAccuracy = 10;
                locator.PositionChanged += Locator_PositionChanged;
                var position = await locator.GetPositionAsync(10000);

                Xamarin.Forms.Maps.Position Pos = new Position(position.Latitude, position.Longitude); //37, -122);
                myMap.MoveToRegion(MapSpan.FromCenterAndRadius(Pos, Distance.FromKilometers(1)));
                DbCenters db = new DbCenters();
                //todo:place centers pins on map
                CentersManager cMng = new CentersManager(db.GetDatabaseConn());
                this.SetMapPins(cMng.All());

            }
            else if (status != PermissionStatus.Unknown)
            {
                await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
               
            }          
        }

      
        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            
            Xamarin.Forms.Maps.Position Pos = new Position(e.Position.Latitude, e.Position.Longitude); //37, -122);
            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(Pos, Distance.FromKilometers(1)));
        }

        private void SetMapPins(List<Center> centers)
        {
            foreach (Center ctr in centers)
            {
                Pin centerPin = new Pin
                {
                    Address = ctr.Address,
                    Label = ctr.Name,
                    Position = new Position(ctr.Latitude, ctr.Longitude),
                    Type = PinType.Place                
                };
                centerPin.Clicked += CenterPin_Clicked;
                myMap.Pins.Add(centerPin);             
            }
        }

        private async void CenterPin_Clicked(object sender, EventArgs e)
        {
         

            DbCenters db = new DbCenters();
            //todo:place centers pins on map
            CentersManager cMng = new CentersManager(db.GetDatabaseConn());

            Pin SelectedPin = (Pin)sender;
            cMng.GetByCoordinates(SelectedPin.Position.Latitude, SelectedPin.Position.Longitude);
        }
    }
}
