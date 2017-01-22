using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using SharpKml.Base;
using SharpKml.Dom;
using RondApp.Models;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text;

namespace RondApp.Views
{
    public partial class ZonesPage : ContentPage
    {
        Document docKml;
        List<Segnalazione> segnalazioni;

        public ZonesPage()
        {
            InitializeComponent();

            InitializePicker();
            GetSegnalazioni();
            GetCurrentPositionAsync();
        }

        public void GetSegnalazioni()
        {
            var webClient = new WebClient();

            webClient.DownloadStringCompleted += (s, e) => {
                var text = e.Result; // get the downloaded text
                
            };
            var url = new Uri("https://maps.googleapis.com/maps/api/js/ViewportInfoService.GetViewportInfo?1m6&1m2&1d45.448210178053415&2d9.143269606046829&2m2&1d45.48403894278448&2d9.194123336632856&2u12&4sit&5e2&7b0&8e0&callback=xdc.qa2sy6&token=103580");
            webClient.Encoding = Encoding.UTF8;
            webClient.DownloadStringAsync(url);
        }

        public void InitializePicker()
        {
            Parser parser = new Parser();
            var assembly = typeof(ZonesPage).GetTypeInfo().Assembly;
            parser.Parse(assembly.GetManifestResourceStream("RondApp.AREE.kml"));
            docKml = (Document)((Kml)parser.Root).Feature;

            foreach (Feature feat in docKml.Features)
            {
                List<string> zone = new List<string>();
                if (((Placemark)feat).Geometry is Polygon)
                {
                    ZonePicker.Items.Add(feat.Name);
                }
                zone.Sort();

                foreach(string z in zone)
                {
                    ZonePicker.Items.Add(z);
                }
            }

            ZonePicker.SelectedIndex = -1;
            ZonePicker.SelectedIndexChanged += ChangeZoneZonePicker_SelectedIndexChanged;
        }

        private void ChangeZoneZonePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker pick = (Picker)sender;
            foreach (Feature feat in docKml.Features)
            {
                string name = feat.Name;
                if (name == pick.Items[pick.SelectedIndex])
                {
                    Polygon poly = (Polygon)((Placemark)feat).Geometry;
                    IEnumerator<Vector> en = (IEnumerator<Vector>)poly.OuterBoundary.LinearRing.Coordinates.GetEnumerator();


                    List<Position> zone = new List<Position>();
                    while (en.MoveNext())
                    {
                        zone.Add(new Position(en.Current.Latitude, en.Current.Longitude));
                    }
                    myMap.ShapeCoordinates = zone;
                }
            }
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
                var locator = CrossGeolocator.Current;

                locator.DesiredAccuracy = 10;
                locator.PositionChanged += Locator_PositionChanged;

                Position Pos = new Position(45.4773, 9.1815);
                myMap.MoveToRegion(MapSpan.FromCenterAndRadius(Pos, Distance.FromKilometers(5)));

                this.SetMapPins(segnalazioni);
            }
            else if (status != PermissionStatus.Unknown)
            {
                await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
            }          
        }
      
        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            Position Pos = new Position(e.Position.Latitude, e.Position.Longitude);
            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(Pos, Distance.FromKilometers(1)));
        }

        private void SetMapPins(List<Segnalazione> segnalazioni)
        {
            foreach (Segnalazione seg in segnalazioni)
            {
                Pin centerPin = new Pin
                {
                    Label = seg.Name + "\n" + seg.Description,
                    Position = new Position(seg.Latitude, seg.Longitude),
                    Type = PinType.Place
                };
                //centerPin.Clicked += CenterPin_Clicked;
                myMap.Pins.Add(centerPin);
            }
        }
    }
}
