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
                Nome = "Cachorro Quente",
                CaminhoArquivoFoto = "cachorro_quente.png"
            });

            TiposItensCardapio.Add(new TipoItemCardapio()
            {
                Id = 3,
                Nome = "Lasanha",
                CaminhoArquivoFoto = "lasanha.png"
            });

            TiposItensCardapio.Add(new TipoItemCardapio()
            {
                Id = 4,
                Nome = "Xis",
                CaminhoArquivoFoto = "xis.png"
            });

            TiposItensCardapio.Add(new TipoItemCardapio()
            {
                Id = 5,
                Nome = "Pastel",
                CaminhoArquivoFoto = "pastel.png"
            });

            TiposItensCardapio.Add(new TipoItemCardapio()
            {
                Id = 6,
                Nome = "Espetinho",
                CaminhoArquivoFoto = "espetinho.png"
            });

            TiposItensCardapio.Add(new TipoItemCardapio()
            {
                Id = 7,
                Nome = "Torta",
                CaminhoArquivoFoto = "torta.png"
            });

            TiposItensCardapio.Add(new TipoItemCardapio()
            {
                Id = 8,
                Nome = "Sanduiche",
                CaminhoArquivoFoto = "sanduiche.png"
            });

            TiposItensCardapio.Add(new TipoItemCardapio()
            {
                Id = 9,
                Nome = "Macarrão",
                CaminhoArquivoFoto = "macarrão.png"
            });

            TiposItensCardapio.Add(new TipoItemCardapio()
            {
                Id = 10,
                Nome = "Pizza",
                CaminhoArquivoFoto = "pizza.png"
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

        public void Add(TipoItemCardapio tipoItemCardapio)
        {
            TiposItensCardapio.Add(tipoItemCardapio);
        }

        public void Remover(TipoItemCardapio tipoItemCardapio)
        {
            TiposItensCardapio.Remove(tipoItemCardapio);
        }

    }
}
