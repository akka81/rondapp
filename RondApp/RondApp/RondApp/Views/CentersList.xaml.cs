using RondApp.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using SQLite;
using RondApp.DAL;
using RondApp.Entities;

namespace RondApp.Views
{
    public partial class CentersList : ContentPage
    {

        private CentersManager centersMng;
        private SQLiteConnection db;
        protected List<CenterDetailed> centers;

        public CentersList()
        {
            InitializeComponent();

            centersList.ItemSelected += CentersList_ItemSelected;
            //get all Centers
            DbCenters db = new DbCenters();
            centersMng = new CentersManager(db.GetDatabaseConn());

            centers = centersMng.All();
            SearchResults.Text = $"Trovati {centers.Count} Centri";

            centersList.ItemsSource = centers;
        }

        private async void CentersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            await Navigation.PushAsync(new CenterPage(1));

            ((ListView)sender).SelectedItem = null;
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {

            centersList.BeginRefresh();

            var FoundCenters = centers.Where(c => c.Name.Contains(e.NewTextValue)).ToList();

            SearchResults.Text = $"Trovati {FoundCenters.Count} Centri";
            centersList.ItemsSource = FoundCenters;


            

            centersList.EndRefresh();


        }

    }


}
