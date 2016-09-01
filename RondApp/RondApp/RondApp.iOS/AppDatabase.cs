using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RondApp.DAL;
using SQLite.Net;
using System.IO;

using Xamarin.Forms;

[assembly: Dependency(typeof(RondApp.iOS.AppDatabase))]
namespace RondApp.iOS
{
 
    public class AppDatabase : ISQlite
    {
        public AppDatabase() { }
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "RondApp_DB.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection(new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS(),path);
            // Return the database connection
            return conn;
        }
    }
}