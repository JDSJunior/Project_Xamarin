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

        public TiposDeItensCardapioSearchPage()
        {
            InitializeComponent();
        }

        public TiposDeItensCardapioSearchPage(Label keyValue, Label displayValue)
        {
            InitializeComponent();

            itens = DB.GetAll<TipoItemCardapio>();
            this.keyValue = keyValue;
            this.displayValue = displayValue;
        }

        public async void OnItemTapped(object o, ItemTappedEventArgs args)
        {
            var item = (o as ListView).SelectedItem as TipoItemCardapio;
            this.keyValue.Text = item.Id.ToString();
            this.displayValue.Text = item.Nome;
            await Navigation.PopAsync();
        }

        public async void OnTextChanged(object o, TextChangedEventArgs args)
        {
            lvTipos.BeginRefresh();
            if (string.IsNullOrWhiteSpace(args.NewTextValue))
            {
                lvTipos.ItemsSource = itens;
            }
            else
            {
                lvTipos.ItemsSource = itens.Where(i => i.Nome.Contains(args.NewTextValue));
            }
            lvTipos.EndRefresh();
        }
    }
}