using System.Collections.Generic;
using Xamarin.Forms;

namespace RondApp.Views
{
    public partial class NavigationMenu : ContentPage
    {
        public List<Models.NavigationItem> navListItems = new List<Models.NavigationItem>();

        public ListView GetNavigationListView { get { return navList; } }

        public NavigationMenu()
        {
            InitializeComponent();

            Device.OnPlatform(iOS: () => navList.SeparatorVisibility = SeparatorVisibility.None);

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
                IconRes = "list.png",
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

            Device.OnPlatform(iOS: () => navList.SeparatorVisibility = SeparatorVisibility.None);
        }
    }
}
