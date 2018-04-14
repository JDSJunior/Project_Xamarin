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
	public partial class TipoItensCardapioNewPage : ContentPage
	{
        private TipoItemCardapioDAL dalTiposItenscardapio = TipoItemCardapioDAL.GetInstance();
        private string caminhoArquivo;

		public TipoItensCardapioNewPage ()
		{
			InitializeComponent ();
            PreparaParaNovoTipoItemCardapio();
            RegistraClickBotaoCamera(idtipoitemcardapio.Text.Trim());
            RegistraClickBotaoAlbum();
		}

        private void PreparaParaNovoTipoItemCardapio()
        {
            var novoId = dalTiposItenscardapio.GetAll().Max(x => x.Id) + 1;

            idtipoitemcardapio.Text = novoId.ToString().Trim();
            nome.Text = string.Empty;
            fotoitemcardapio.Source = null;
        };


    }
}