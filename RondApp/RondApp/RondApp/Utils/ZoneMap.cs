using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using RondApp.Models;

namespace RondApp.Utils
{
    public class ZoneMap : Map
    {
        public static readonly BindableProperty ItemShapeCoordinates =
            BindableProperty.Create<ZoneMap, List<Position>>(p => p.ShapeCoordinates, null);

        public static readonly BindableProperty ItemSegnalazioni =
            BindableProperty.Create<ZoneMap, List<Segnalazione>>(p => p.Segnalazioni, null);

        public List<Position> ShapeCoordinates
        {
            get { return (List<Position>)GetValue(ItemShapeCoordinates); }
            set {
                SetValue(ItemShapeCoordinates, value);
                OnPropertyChanged();
            } // it would rise ElementPropertyChanged event
        }

        public List<Segnalazione> Segnalazioni
        {
            get { return (List<Segnalazione>)GetValue(ItemSegnalazioni); }
            set
            {
                SetValue(ItemSegnalazioni, value);
                OnPropertyChanged();
            } // it would rise ElementPropertyChanged event
        }

        public ZoneMap()
        {
            ShapeCoordinates = new List<Position>();
            Segnalazioni = new List<Segnalazione>();
        }
    }
}
