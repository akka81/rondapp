using RondApp.Utils;
using Xamarin.Forms;
using RondApp.iOS;
using Xamarin.Forms.Maps.iOS;
using MapKit;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using CoreLocation;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(ZoneMap), typeof(CustomMapRenderer))]
namespace RondApp.iOS
{
    public class CustomMapRenderer : MapRenderer
    {
        MKPolygonRenderer polygonRenderer;

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                var nativeMap = Control as MKMapView;
                nativeMap.OverlayRenderer = null;
            }

            if (e.NewElement != null)
            {
                UpdateMap((ZoneMap)e.NewElement);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "ShapeCoordinates")
            {
                UpdateMap((ZoneMap)sender);
            }
        }

        private void UpdateMap(ZoneMap formsMap)
        {
            var nativeMap = Control as MKMapView;

            nativeMap.OverlayRenderer = GetOverlayRenderer;
            nativeMap.RemoveOverlays();

            if (formsMap.ShapeCoordinates.Count > 0)
            {
                CLLocationCoordinate2D[] coords = new CLLocationCoordinate2D[formsMap.ShapeCoordinates.Count];

                int index = 0;
                foreach (var position in formsMap.ShapeCoordinates)
                {
                    coords[index] = new CLLocationCoordinate2D(position.Latitude, position.Longitude);
                    index++;
                }

                var blockOverlay = MKPolygon.FromCoordinates(coords);
                nativeMap.AddOverlay(blockOverlay);
            }
        }

        MKOverlayRenderer GetOverlayRenderer(MKMapView mapView, IMKOverlay overlay)
        {
            if (polygonRenderer == null)
            {
                polygonRenderer = new MKPolygonRenderer(overlay as MKPolygon);
                polygonRenderer.FillColor = UIColor.Red;
                polygonRenderer.StrokeColor = UIColor.Blue;
                polygonRenderer.Alpha = 0.4f;
                polygonRenderer.LineWidth = 9;
            }
            return polygonRenderer;
        }
    }
}