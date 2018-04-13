using App1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1.DAL
{
    public class TipoItemCardapioDAL
    {
        private ObservableCollection<TipoItemCardapio> TiposItensCardapio = new ObservableCollection<TipoItemCardapio>();
        private static TipoItemCardapioDAL TipoItemCardapioInstance = new TipoItemCardapioDAL();

        private TipoItemCardapioDAL()
        {
            TiposItensCardapio.Add(new TipoItemCardapio()
            {
                Id = 1,
                Nome = "Pizza",
                CaminhoArquivoFoto = "pizza.png"
            });

            TiposItensCardapio.Add(new TipoItemCardapio()
            {
                Id = 2,
                Nome = "Bebidas",
                CaminhoArquivoFoto = "bebidas.png"
            });

            TiposItensCardapio.Add(new TipoItemCardapio()
            {
                Id = 3,
                Nome = "Saladas",
                CaminhoArquivoFoto = "saladas.png"
            });

            TiposItensCardapio.Add(new TipoItemCardapio()
            {
                Id = 4,
                Nome = "Sanduiches",
                CaminhoArquivoFoto = "sanduiche.png"
            });

            TiposItensCardapio.Add(new TipoItemCardapio()
            {
                Id = 5,
                Nome = "Sobremesas",
                CaminhoArquivoFoto = "sobremesas.png"
            });

            TiposItensCardapio.Add(new TipoItemCardapio()
            {
                Id = 6,
                Nome = "Carnes",
                CaminhoArquivoFoto = "carnes.png"
            });
        }

        public static TipoItemCardapioDAL GetInstance()
        {
            return TipoItemCardapioInstance;
        }

        public ObservableCollection<TipoItemCardapio> GetAll()
        {
            return TiposItensCardapio;
        }

        public void Add(TipoItemCardapio tipoitemcardapio)
        {
            TiposItensCardapio.Add(tipoitemcardapio);
        }
    }
}
