using App1.Infraestructure;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
     public class TipoItemCardapio : TasksDB
    {
        public string Nome { get; set; }
        public byte[] Foto { get; set; }

    }
}
