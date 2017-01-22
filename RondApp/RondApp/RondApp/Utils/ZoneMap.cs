using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace RondApp.Utils
{
    public class ZoneMap : Map
    {
        //public List<Position> ShapeCoordinates { get; set; }

        public static readonly BindableProperty ItemShapeCoordinates =
            BindableProperty.Create<ZoneMap, List<Position>>(p => p.ShapeCoordinates, null);

        public List<Position> ShapeCoordinates
        {
            get { return (List<Position>)GetValue(ItemShapeCoordinates); }
            set {
                SetValue(ItemShapeCoordinates, value);
                OnPropertyChanged();
            } // it would rise ElementPropertyChanged event
        }

        public ZoneMap()
        {
            ShapeCoordinates = new List<Position>();
        }
    }
}
