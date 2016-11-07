using RondApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RondApp
{
    public partial class App : Application
    {
        public App()
        {
            //Database Initializazion
            DbCenters DbMng = new DbCenters();
            DbMng.LoadDbData();

            //map page
           MainPage = new Views.MainPage();
        }
    }
}
