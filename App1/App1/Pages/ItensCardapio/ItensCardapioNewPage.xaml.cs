using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages.ItensCardapio
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItensCardapioNewPage : ContentPage
	{
		public ItensCardapioNewPage ()
		{
			InitializeComponent ();
		}

        
        private async void OnTapLookForTipos(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new TiposDeItensCardapioSearchPage(idTipo, nomeTipo));
        }
    }
}