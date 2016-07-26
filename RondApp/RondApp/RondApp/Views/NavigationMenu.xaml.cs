using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RondApp.Views
{
    public partial class NavigationMenu : ContentPage
    {
        public List<Models.NavigationItem> navListItems = new List<Models.NavigationItem>();
        public NavigationMenu()
        {
            InitializeComponent();

            navListItems.Add(new Models.NavigationItem
            {
                Title = "Assistenza",
                IconRes = "icon.png",
                ItemType = typeof(AssistancePage),
            });


            navList.ItemsSource = navListItems;
        }
    }
}
