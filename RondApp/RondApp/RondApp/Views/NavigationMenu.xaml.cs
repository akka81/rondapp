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
                IconRes = "human.png", //new Image { Source = ImageSource.FromResource("human.pnf"), VerticalOptions = LayoutOptions.Start, HorizontalOptions = LayoutOptions.Start },
                ItemType = typeof(AssistancePage)

            });

          
           
            navList.ItemsSource = navListItems;
        }
    }
}
