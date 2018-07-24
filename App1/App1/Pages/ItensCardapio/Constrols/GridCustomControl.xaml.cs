using App1.Infraestructure;
using App1.Models;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages.ItensCardapio.Constrols
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GridCustomControl : Grid
	{
        private byte[] bytesFoto;
        private DataBase DB;

        public GridCustomControl ()
		{
			InitializeComponent ();
        }


        private async void OnTapLookForTipos(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new TiposDeItensCardapioSearchPage(idTipo, nomeTipo));
        }

        private async void OnAlbumClicked(object sender, EventArgs args)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                await App.Current.MainPage.DisplayAlert("Album não suportado", "Não existe permissão para acessar o album de fotos.", "Ok");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();
            
            if(file == null)
            {
                return;
            }

            var stream = file.GetStream();
            var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            fotoAlbum.Source = ImageSource.FromStream(() =>
            {
                var s = file.GetStream();
                file.Dispose();
                return s;
            });

            bytesFoto = memoryStream.ToArray();
        }

        private async void OnTappedSaveItem(object sender, EventArgs args)
        {
            DB = new DataBase();
            DB.SaveItem(new ItemCardapio()
            {
                Nome = nome.Text,
                Descricao = descricao.Text,
                Preco = Convert.ToDouble(preco.Text),
                TipoItemCardapioId = Convert.ToInt32(idTipo.Text),
                Foto = bytesFoto
            });

            await App.Current.MainPage.DisplayAlert("Inserção de item", "Item inserido com sucesso.", "Ok");

            ClearControls();
        }

        private void ClearControls()
        {
            nome.Text = string.Empty;
            descricao.Text = string.Empty;
            preco.Text = string.Empty;
            bytesFoto = null;
            idTipo.Text = string.Empty;
            nomeTipo.Text = "Selecione o Tipo do Item";
            fotoAlbum.Source = null;
        }
    }
}