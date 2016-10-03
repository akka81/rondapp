using RondApp.DAL;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(RondApp.WinPhone.AppDatabase))]
namespace RondApp.WinPhone
{
    public class AppDatabase : ISQlite
    {
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "RondApp_DB.db3";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}
