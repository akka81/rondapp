using RondApp.UWP;
using Xamarin.Forms.Platform.UWP;
using RondApp.Utils;
using RondApp.Models;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.UWP;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Devices.Geolocation;
using System.Collections.Generic;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(ZoneMap), typeof(CustomMapRenderer))]
namespace RondApp.UWP
{
    public class CustomMapRenderer : MapRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "ShapeCoordinates")
            {
                RedrawMap((ZoneMap)sender);
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
            }

            if (e.NewElement != null)
            {
                RedrawMap((ZoneMap)e.NewElement);
            }
        }

        private void RedrawMap(ZoneMap formsMap)
        {
            var nativeMap = Control as MapControl;
            nativeMap.MapElements.Clear();

            var coordinates = new List<BasicGeoposition>();
            foreach (var position in formsMap.ShapeCoordinates)
            {
                coordinates.Add(new BasicGeoposition() { Latitude = position.Latitude, Longitude = position.Longitude });
            }

            if (coordinates.Count > 0)
            {
                var polygon = new MapPolygon();
                polygon.FillColor = Windows.UI.Color.FromArgb(128, 255, 0, 0);
                polygon.StrokeColor = Windows.UI.Color.FromArgb(128, 0, 0, 255);
                polygon.StrokeThickness = 5;
                polygon.Path = new Geopath(coordinates);
                nativeMap.MapElements.Add(polygon);
            }
        }
    }
}