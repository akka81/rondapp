using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;
using Plugin.Geolocator.Abstractions;

namespace RondApp.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();

            var p = GetCurrentPosition();
           

        }

        public async Task<Position> GetCurrentPosition()
        {
            return await Plugin.Geolocator.CrossGeolocator.Current.GetPositionAsync(10000);
         
        }
    
    }
}
