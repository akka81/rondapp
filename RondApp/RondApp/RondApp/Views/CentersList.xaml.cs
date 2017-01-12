using RondApp.Managers;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using RondApp.DAL;
using RondApp.Entities;

namespace RondApp.Views
{
    public partial class CentersList : ContentPage
    {
        private CentersManager centersMng;
        protected List<CenterDetailed> centers;

        private void InitPage()
        {
            InitializeComponent();

            centersList.ItemSelected += CentersList_ItemSelected;
        }

        public CentersList()
        {
            InitPage();
            //get all Centers
            DbCenters db = new DbCenters();
            centersMng = new CentersManager(db.GetDatabaseConn());

            centers = centersMng.All();
            SearchResults.Text = $"Trovati {centers.Count} Centri";

            centersList.ItemsSource = centers;
        }

        public CentersList(List<CenterDetailed> centers)
        {
            InitPage();
            this.centers = centers;
            SearchResults.Text = $"Trovati {centers.Count} Centri";

            centersList.ItemsSource = centers;
        }


        private void CentersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

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
