using App1.Infraestructure;
using App1.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace App1.DAL
{
    public class TipoItemCardapioDAL
    {

        public SQLiteConnection sqlConnection;

        public TipoItemCardapioDAL()
        {
            this.sqlConnection = DependencyService.Get<IDataBaseConnection>().DbConnection();
            this.sqlConnection.CreateTable<TipoItemCardapio>();
        }

        public IEnumerable<TipoItemCardapio> GetAll()
        {
            return (from t in sqlConnection.Table<TipoItemCardapio>() select t).OrderBy(i => i.Nome).ToList();
        }

        public TipoItemCardapio GetItemById(long id)
        {
            return sqlConnection.Table<TipoItemCardapio>().FirstOrDefault(t => t.TipoItemCardapioId == id);
        }

        public void DeleteById(long id)
        {
            sqlConnection.Delete<TipoItemCardapio>(id);
        }

        public void Add(TipoItemCardapio tipoItemCardapio)
        {
            sqlConnection.Insert(tipoItemCardapio);
        }

        public void Update(TipoItemCardapio tipoItemCardapio)
        {
            sqlConnection.Update(tipoItemCardapio);
        }
    }
}
 