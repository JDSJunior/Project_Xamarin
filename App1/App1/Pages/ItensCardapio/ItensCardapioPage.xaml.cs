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
    public partial class ItensCardapioPage : ContentPage
    {
        public ItensCardapioPage ()
        {
            InitializeComponent();

            btnNovoItem.Clicked += BtnNovoItemClick;

        }

        private async void BtnNovoItemClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItensCardapioNewPage());
        }


    }
}