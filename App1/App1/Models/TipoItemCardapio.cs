using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
     public class TipoItemCardapio
    {
        [PrimaryKey, AutoIncrement]
        public long? Id { get; set; }
        public string Nome { get; set; }
        public byte Foto { get; set; }


        public override bool Equals(object obj)
        {
            TipoItemCardapio tipoItemCardapio = obj as TipoItemCardapio;
            if (tipoItemCardapio == null)
            {
                return false;
            }
            return (Id.Equals(tipoItemCardapio.Id));
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
