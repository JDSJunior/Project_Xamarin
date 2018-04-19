using App1.DAL;
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
	public partial class TiposItensCardapioListPage : ContentPage
	{
        private TipoItemCardapioDAL ItensCardapio = TipoItemCardapioDAL.GetInstance();

		public TiposItensCardapioListPage ()
		{
			InitializeComponent ();

            listviewTiposItensCardapio.ItemsSource = ItensCardapio.GetAll();
		}
	}
}