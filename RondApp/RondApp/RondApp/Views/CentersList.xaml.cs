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

        private void CentersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (e.SelectedItem == null)
                return;


            CenterDetailed selectedCenter = (CenterDetailed)((ListView)sender).SelectedItem;
            
            Navigation.PushAsync(new CenterPage(selectedCenter.ID));
            ((ListView)sender).SelectedItem = null;


        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {

            centersList.BeginRefresh();
            var FoundCenters = centers.Where(c => c.Name.ToLower().Contains(e.NewTextValue) || c.TypeName.ToLower().Contains(e.NewTextValue.ToLower())).ToList();

            SearchResults.Text = $"Trovati {FoundCenters.Count} Centri";
            centersList.ItemsSource = FoundCenters;

            centersList.EndRefresh();

        }

    }


}
