using App1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1.DAL
{
    public class EntregadorDAL
    {
        private ObservableCollection<Entregador> Entregadores = new ObservableCollection<Entregador>();
        private static EntregadorDAL EntregadorInstance = new EntregadorDAL();

        private EntregadorDAL()
        {
            Entregadores.Add(new Entregador()
            {
                Id = 1,
                Nome = "Brauzio",
                Telefone = "91919191"
            });

            Entregadores.Add(new Entregador()
            {
                Id = 2,
                Nome = "Enteucios",
                Telefone = "92929292"
            });

            Entregadores.Add(new Entregador()
            {
                Id = 3,
                Nome = "Cartucius",
                Telefone = "93939393"
            });

            Entregadores.Add(new Entregador()
            {
                Id = 4,
                Nome = "Adolitero",
                Telefone = "94949494"
            });

            Entregadores.Add(new Entregador()
            {
                Id = 5,
                Nome = "Castrogildo",
                Telefone = "95959595"
            });

            Entregadores.Add(new Entregador()
            {
                Id = 6,
                Nome = "Gendencio",
                Telefone = "96969696"
            });

            Entregadores.Add(new Entregador()
            {
                Id = 7,
                Nome = "Tonho",
                Telefone = "97979797"
            });

            Entregadores.Add(new Entregador()
            {
                Id = 8,
                Nome = "Juvenal",
                Telefone = "98989898"
            });

            Entregadores.Add(new Entregador()
            {
                Id = 9,
                Nome = "Astrogildo",
                Telefone = "99999999"
            });

            Entregadores.Add(new Entregador()
            {
                Id = 10,
                Nome = "Sem nome",
                Telefone = "90909090"
            });
        }

        public static EntregadorDAL GetInstance()
        {
            return EntregadorInstance;
        }

        public ObservableCollection<Entregador> GetAll()
        {
            return Entregadores;
        }

        public void Add(Entregador entregador)
        {
            this.Entregadores.Add(entregador);
        }

    }
}
