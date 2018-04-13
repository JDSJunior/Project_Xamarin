using App1.DAL;
using App1.Pages.TiposItenCardapio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
		public MenuPage ()
		{
			InitializeComponent(); 
		}

        private async void GarconsOnClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new GarconsPage());
        }

        private async void EntregadoresOnClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new EntregadoresTabbedPage());
        }

        private async void TiposItensCardapioOnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TipoItensCardapioPage());
        }

    }
}