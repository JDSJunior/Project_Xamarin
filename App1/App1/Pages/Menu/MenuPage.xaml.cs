﻿using App1.DAL;
using App1.Pages.ItensCardapio;
using App1.Pages.TiposItensCardapio;
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

        private async void TiposItensCardapio(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new TiposCardapioTabbedPage());
        }

        private async void Itens(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ItensCardapioPage());
        }

    }
}