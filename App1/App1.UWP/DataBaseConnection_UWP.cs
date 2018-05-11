using App1.Infraestructure;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace App1.UWP
{
    class DataBaseConnection_UWP : IDataBaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "RestauranteDB.db3";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbName);
            var platform = new SQLitePlatformWinRT();
            return new SQLiteConnection(platform, path);
        }
    }
}
