using App1.HelperControls;
using App1.Infraestructure;
using App1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages.ItensCardapio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItensCardapioPage : ContentPage
    {
        private DataBase DB = new DataBase();

        public ItensCardapioPage ()
        {
            InitializeComponent();

            btnNovoItem.Clicked += BtnNovoItemClick;
        }

        private async void BtnNovoItemClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItensCardapioNewPage());
        }

        private Collection<ListViewGrouping<TipoItemCardapio, ItemCardapio>> GetDataByGroup()
        {
            var dadosAgrupados = new Collection<ListViewGrouping<TipoItemCardapio, ItemCardapio>>();
            var tipos = DB.GetAllWithChildren();

            foreach (var tipo in tipos)
            {
                dadosAgrupados.Add(new ListViewGrouping<TipoItemCardapio, ItemCardapio>(tipo, tipo.Itens));
            }

            return dadosAgrupados;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvItensCardapio.ItemsSource = GetDataByGroup();
        }
    }
}