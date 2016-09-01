using RondApp.DAL;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(RondApp.UWP.AppDatabase))]
namespace RondApp.UWP
{
    public class AppDatabase : ISQlite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "RondApp_DB.db3";
            string path = System.IO.Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            var conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(),path);
            return conn;
        }
    }
}
