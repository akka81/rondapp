using RondApp.DAL;
using Xamarin.Forms;

namespace RondApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Application.Current.Resources["LargeFontSize"] = Device.OnPlatform(
                iOS: Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                Android: Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                WinPhone: 20);

            Application.Current.Resources["MediumFontSize"] = Device.OnPlatform(
                iOS: Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                Android: Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                WinPhone: 18);

            Application.Current.Resources["SmallFontSize"] = Device.OnPlatform(
                iOS: Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                Android: Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                WinPhone: 16);

            Application.Current.Resources["XSmallFontSize"] = Device.OnPlatform(
                iOS: Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                Android: Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                WinPhone: 14);

            DbCenters DbMng = new DbCenters();
            DbMng.LoadDbData();
            MainPage = new Views.MainPage();
        }
    }
}
