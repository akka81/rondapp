using RondApp.DAL;
using Xamarin.Forms;

namespace RondApp
{
    public partial class App : Application
    {
        public App()
        {
            DbCenters DbMng = new DbCenters();
            DbMng.LoadDbData();
            MainPage = new Views.MainPage();
        }
    }
}
