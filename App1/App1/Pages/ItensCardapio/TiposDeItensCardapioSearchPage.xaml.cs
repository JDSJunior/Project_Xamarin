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
	public partial class TiposDeItensCardapioSearchPage : ContentPage
	{
        private DataBase DB = new DataBase();
        private IEnumerable<TipoItemCardapio> itens;
        private Label displayValue;
        private Label keyValue;

		public TiposDeItensCardapioSearchPage (Label keyValue, Label displayValue)
		{
			InitializeComponent ();

            itens = DB.GetAll<TipoItemCardapio>();
            this.keyValue = keyValue;
            this.displayValue = displayValue;
		}
	}
}