using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1.Infraestructure;
using SQLite;

namespace App1.Droid
{
    class DataBaseConnection_Android : IDataBaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbname = "RestauranteDB.db3";
            string documentsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentsFolder, dbname);
            var platform = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return new SQLiteConnection(platform, path);
        }
    }
}