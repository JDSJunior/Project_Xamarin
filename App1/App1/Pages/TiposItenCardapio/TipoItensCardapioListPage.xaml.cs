using App1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages.TiposItenCardapio
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TipoItensCardapioListPage : ContentPage
	{
        private TipoItemCardapioDAL dalItemCardapio = TipoItemCardapioDAL.GetInstance();

		public TipoItensCardapioListPage ()
		{
			InitializeComponent ();

            listviewTiposItensCardapio.ItemsSource = dalItemCardapio.GetAll();
		}
	}
}