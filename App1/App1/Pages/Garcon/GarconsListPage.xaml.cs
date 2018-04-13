using App1.DAL;
using App1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GarconsListPage : ContentPage
    {
        ObservableCollection<Garcon> garcons = new ObservableCollection<Garcon>();

        public GarconsListPage()
        {
            InitializeComponent();

            GarconsListView.ItemsSource = garcons;

            garcons.Add(new Garcon { Nome = "Brauzio" });
            garcons.Add(new Garcon { Nome = "Asdrugio" });
            garcons.Add(new Garcon { Nome = "Entencius" });
            garcons.Add(new Garcon { Nome = "Gesdefrau" });
            garcons.Add(new Garcon { Nome = "Cartucius" });
            garcons.Add(new Garcon { Nome = "Adoliterio" });
            garcons.Add(new Garcon { Nome = "Kenteucio" });
            garcons.Add(new Garcon { Nome = "Mineslau" });
            garcons.Add(new Garcon { Nome = "Gesdefrau" });
            garcons.Add(new Garcon { Nome = "Cartucius" });
            garcons.Add(new Garcon { Nome = "Adoliterio" });
            garcons.Add(new Garcon { Nome = "Kenteucio" });
            garcons.Add(new Garcon { Nome = "Mineslau" });
        }
    }
}