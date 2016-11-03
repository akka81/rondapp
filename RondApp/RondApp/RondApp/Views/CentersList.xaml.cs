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

        public string SearchResults = string.Empty;
        private CentersManager centersMng;
        private SQLiteConnection db;
        protected List<CenterDetailed> centers;

        public CentersList()
        {
            InitializeComponent();

            //get all Centers
            DbCenters db = new DbCenters();
            centersMng = new CentersManager(db.GetDatabaseConn());

            centers = centersMng.All();
            SearchResults = $"Trovati {centers.Count} Centri";

            centersList.ItemsSource = centers;
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {

            centersList.BeginRefresh();


            centersList.ItemsSource = centers.Where(c => c.Name.Contains(e.NewTextValue)).ToList();

            centersList.EndRefresh();


        }

    }


}
