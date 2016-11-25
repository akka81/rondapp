using RondApp.DAL;
using System.IO;
using Xamarin.Forms;
using System;
using System.Threading.Tasks;

[assembly: Dependency(typeof(RondApp.Droid.AppDatabase))]
namespace RondApp.Droid
{
    public class AppDatabase : ISQlite
    {
        public AppDatabase() { }

        private const string sqliteFilename = "RondApp_DB.db3";
       
        public SQLite.SQLiteConnection GetConnection()
        {
           
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLite.SQLiteConnection(path);
            // Return the database connection

            
            return conn;
        }

      
    }

}