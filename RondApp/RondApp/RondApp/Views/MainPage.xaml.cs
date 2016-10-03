using RondApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RondApp.Views
{
    public partial class MainPage : MasterDetailPage
    {
        //NavigationMenu navMenu;

        public MainPage()
        {
            InitializeComponent();
            //navMenu = new NavigationMenu();
            navMenu.getNavigationListView.ItemSelected += OnItemSelected;
        
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as NavigationItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.ItemType));
                navMenu.getNavigationListView.SelectedItem = null;
                IsPresented = false;
            }
        }

    }  
}
