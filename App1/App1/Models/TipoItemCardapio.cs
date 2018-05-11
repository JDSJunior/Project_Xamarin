using SQLite;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
     public class TipoItemCardapio
    {
        [PrimaryKey, AutoIncrement]
        public long? TipoItemCardapioId { get; set; }
        public string Nome { get; set; }
        public byte Foto { get; set; }


        public override bool Equals(object obj)
        {
            TipoItemCardapio tipoItemCardapio = obj as TipoItemCardapio;
            if (tipoItemCardapio == null)
            {
                return false;
            }
            return (TipoItemCardapioId.Equals(tipoItemCardapio.TipoItemCardapioId));
        }

        public override int GetHashCode()
        {
            return TipoItemCardapioId.GetHashCode();
        }
    }
}
