using App1.Infraestructure;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
     public class TipoItemCardapio : TasksDB
    {
        public string Nome { get; set; } = String.Empty;
        public byte[] Foto { get; set; }

        [OneToMany]
        public List<ItemCardapio> Itens { get; set; }

        public override bool Equals(object obj)
        {
            TipoItemCardapio tipoItemCardapio = obj as TipoItemCardapio;

            if(tipoItemCardapio == null)
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
