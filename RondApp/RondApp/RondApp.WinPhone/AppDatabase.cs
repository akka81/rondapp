using RondApp.DAL;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;
using System;
using System.Threading.Tasks;

[assembly: Dependency(typeof(RondApp.WinPhone.AppDatabase))]
namespace RondApp.WinPhone
{
    public class AppDatabase : ISQlite
    {
        private const string sqliteFilename = "RondApp_DB.db3";

        public SQLite.SQLiteConnection GetConnection()
        {
           
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}
