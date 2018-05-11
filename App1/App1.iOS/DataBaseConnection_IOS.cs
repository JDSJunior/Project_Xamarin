using App1.Infraestructure;
using App1.iOS;
using SQLite;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DataBaseConnection_IOS))]
namespace App1.iOS
{
    class DataBaseConnection_IOS : IDataBaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "RestauranteDB.db3";
            string personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, ".", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            var platform = new SQLitePlatformIOS();
            return new SQLiteConnection(platform, path);
        }
    }
}