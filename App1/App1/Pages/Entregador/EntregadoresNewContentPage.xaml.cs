using App1.DAL;
using App1.Models;
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
	public partial class EntregadoresNewContentPage : ContentPage
	{
        private EntregadorDAL dalEntregador = EntregadorDAL.GetInstance();
        

		public EntregadoresNewContentPage ()
		{
			InitializeComponent ();
            PreparaParaNovoEntregador();
		}

        public void BtnGravarClick(object sender, EventArgs e)
        {
            if(nome.Text.Trim() == string.Empty || telefone.Text== string.Empty)
            {
                this.DisplayAlert("Erro", "Você precisa informar o nome e telefone para o entregador.", "OK");
            }
            else
            {
                dalEntregador.Add(new Entregador()
                {
                    Id = Convert.ToUInt32(identregador.Text),
                    Nome = nome.Text,
                    Telefone = telefone.Text
                });
                PreparaParaNovoEntregador();
            }
        }

        private void PreparaParaNovoEntregador()
        {
            var novoId = dalEntregador.GetAll().Max(x => x.Id) + 1;
            identregador.Text = novoId.ToString().Trim();
            nome.Text = string.Empty;
            telefone.Text = string.Empty;
        }
    }
}