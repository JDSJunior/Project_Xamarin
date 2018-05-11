using SQLite;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Infraestructure
{
    public interface IDataBaseConnection
    {
        SQLiteConnection DbConnection();
    }
}
