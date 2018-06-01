using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class ItemCardapio
    {
        [PrimaryKey, AutoIncrement]
        public int ItemCardapioId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public byte[] Foto { get; set; }

        [ForeignKey(typeof(TipoItemCardapio))]
        public int TipoItemCardapioId { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public TipoItemCardapio TipoItemCardapio { get; set; }

        public override bool Equals(object obj)
        {
            ItemCardapio itemCardapio = obj as ItemCardapio;
            if (itemCardapio == null)
            {
                return false;
            }

            return (ItemCardapioId.Equals(itemCardapio.ItemCardapioId));
        }

        public override int GetHashCode()
        {
            return ItemCardapioId.GetHashCode();
        }
    }
}
