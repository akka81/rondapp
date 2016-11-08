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
                IconRes = "help.png", 
                Description = "Cerca il centro adeguato",
                ItemType = typeof(AssistancePage)

            });
            navListItems.Add(new Models.NavigationItem
            {
                Title = "Mappa",
                IconRes = "map.png", 
                Description = "Visualizza i centri sulla mappa",
                ItemType = typeof(MapPage)

            });
            navListItems.Add(new Models.NavigationItem
            {
                Title = "Lista Centri",
                IconRes = "List.png",
                Description = "Visualizza l'elenco di tutti i centri",
                ItemType = typeof(CentersList)

            });
            navListItems.Add(new Models.NavigationItem
            {
                Title = "About",
                IconRes = "about.png",
                ItemType = typeof(About)

            });

            navList.ItemsSource = navListItems;
        }
    }
}
