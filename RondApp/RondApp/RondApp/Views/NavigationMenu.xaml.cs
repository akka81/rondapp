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

        public ListView getNavigationListView { get { return navList; } }
        public NavigationMenu()
        {
            InitializeComponent();


            navListItems.Add(new Models.NavigationItem
            {
                Title = "Assistenza",
                IconRes = "human.png", 
                ItemType = typeof(AssistancePage)

            });
            navListItems.Add(new Models.NavigationItem
            {
                Title = "Mappa",
                IconRes = "human.png", 
                ItemType = typeof(MapPage)

            });
            navListItems.Add(new Models.NavigationItem
            {
                Title = "Lista Centri",
                IconRes = "human.png",
                ItemType = typeof(CentersList)

            });
            navListItems.Add(new Models.NavigationItem
            {
                Title = "About",
                IconRes = "human.png",
                ItemType = typeof(About)

            });

            navList.ItemsSource = navListItems;
        }
    }
}
