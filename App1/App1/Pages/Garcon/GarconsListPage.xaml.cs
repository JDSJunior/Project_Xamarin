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
        private GarconDAL Garcons = GarconDAL.GetInstance();

        public GarconsListPage()
        {
            InitializeComponent();

            GarconsListView.ItemsSource = Garcons.GetAll();
        }
    }
}