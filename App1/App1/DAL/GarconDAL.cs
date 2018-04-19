using App1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1.DAL
{
    public class GarconDAL
    {
        private ObservableCollection<Garcon> Garcons = new ObservableCollection<Garcon>();
        private static GarconDAL GarconInstance = new GarconDAL();

        private GarconDAL()
        {
            Garcons.Add(new Garcon
            {
                Id = 1,
                Nome = "João"
            });

            Garcons.Add(new Garcon
            {
                Id = 2,
                Nome = "Tonho"
            });

            Garcons.Add(new Garcon
            {
                Id = 3,
                Nome = "Tião"
            });

            Garcons.Add(new Garcon
            {
                Id = 4,
                Nome = "José"
            });

            Garcons.Add(new Garcon
            {
                Id = 5,
                Nome = "Juvenal"
            });

            Garcons.Add(new Garcon
            {
                Id = 6,
                Nome = "Tiburcio"
            });

            Garcons.Add(new Garcon
            {
                Id = 7,
                Nome = "Astrogildo"
            });

            Garcons.Add(new Garcon
            {
                Id = 8,
                Nome = "Godofredo"
            });

            Garcons.Add(new Garcon
            {
                Id = 9,
                Nome = "Setembrino"
            });

            Garcons.Add(new Garcon
            {
                Id = 10,
                Nome = "Arisclemes"
            });
        }

        public static GarconDAL GetInstance()
        {
            return GarconInstance;
        }

        public ObservableCollection<Garcon> GetAll()
        {
            return Garcons;
        }

        public void Add(Garcon garcon)
        {
            this.Garcons.Add(garcon);
        }

    }
}
