using RondApp.Models;
using System;
using Xamarin.Forms;

namespace RondApp.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            navMenu.GetNavigationListView.ItemSelected += OnItemSelected;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as NavigationItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.ItemType));
                navMenu.GetNavigationListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }  
}
