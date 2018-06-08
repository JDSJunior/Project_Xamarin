using App1.DAL;
using App1.Infraestructure;
using App1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages.TiposItensCardapio
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TiposItensPage : ContentPage
    {
        private DataBase bd = new DataBase();

        public TiposItensPage()
		{
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listviewItensCardapio.ItemsSource = bd.GetAll<TipoItemCardapio>();
        }

        public async void OnRemoverClick(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var item = mi.CommandParameter as TipoItemCardapio;
            var opcao = await DisplayAlert("Confirmação de exclusão", "Confirma excluir o item " + item.Nome.ToUpper() + "?", "Sim", "Não");
            if (opcao)
            {
                bd.DeleteById<TipoItemCardapio>(item.Id);
            }

            listviewItensCardapio.ItemsSource = bd.GetAll<TipoItemCardapio>();
        }

        public async void OnAlterarClick(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var item = mi.CommandParameter as TipoItemCardapio;
            await Navigation.PushModalAsync(new TiposItensCardapioEditPage(item));
        }


    }
}