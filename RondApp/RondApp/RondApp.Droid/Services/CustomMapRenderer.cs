using RondApp.Droid;
using Xamarin.Forms.Platform.Android;
using RondApp.Utils;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using System.Collections.Generic;
using Xamarin.Forms;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

[assembly: ExportRenderer(typeof(ZoneMap), typeof(CustomMapRenderer))]
namespace RondApp.Droid
{
    public class CustomMapRenderer : MapRenderer, IOnMapReadyCallback
    {
        GoogleMap map;
        List<Position> shapeCoordinates;

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);
            Element.PropertyChanged += (s_, e_) => Invalidate();

            if (e.OldElement != null)
            {
                // Unsubscribe
            }

            if (e.NewElement != null)
            {
                var formsMap = (ZoneMap)e.NewElement;
                shapeCoordinates = formsMap.ShapeCoordinates;

                ((MapView)Control).GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;
            map.Clear();

            if (shapeCoordinates.Count > 0)
            {
                var polygonOptions = new PolygonOptions();
                polygonOptions.InvokeFillColor(0x66FF0000);
                polygonOptions.InvokeStrokeColor(0x660000FF);
                polygonOptions.InvokeStrokeWidth(30.0f);

                foreach (var position in shapeCoordinates)
                {
                    polygonOptions.Add(new LatLng(position.Latitude, position.Longitude));
                }

                map.AddPolygon(polygonOptions);
            }
        }
    }
}