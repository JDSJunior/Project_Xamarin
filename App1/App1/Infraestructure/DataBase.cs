using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Infraestructure
{
    public class DataBase
    {
        SQLiteConnection Connection;
        public static string Root;
        
        public DataBase()
        {
            var local = "RestauranteDB.db3";
            Connection = new SQLiteConnection(local);
        }
    }
}
