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
	public partial class GarconsNewPage : ContentPage
	{
        private GarconDAL dalGarcon = GarconDAL.GetInstance();

		public GarconsNewPage ()
		{
			InitializeComponent ();
            PreparaParaNovoGarcon();
		}

        public void BtnGravarClick(object sender, EventArgs e)
        {
            if(nome.Text.Trim()==string.Empty)
            {
                this.DisplayAlert("Erro", "Você precisa informar o nome.", "OK");
            }
            else
            {
                dalGarcon.Add(new Garcon()
                {
                    Id = Convert.ToUInt32(idgarcon.Text),
                    Nome = nome.Text,
                });

                PreparaParaNovoGarcon();
            }
        }

        private void PreparaParaNovoGarcon()
        {
            var novoId = dalGarcon.GetAll().Max(x => x.Id) + 1;
            idgarcon.Text = novoId.ToString().Trim();
        }
	}
}