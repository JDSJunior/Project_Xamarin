using App1.DAL;
using App1.Models;
using PCLStorage;
using Plugin.Media;
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
	public partial class TiposItensCardapioEditPage : ContentPage
	{
        private TipoItemCardapio tipoItemCardapio;
        private string caminhoArquivo;
        private TipoItemCardapioDAL dalTipoItensCardapio = TipoItemCardapioDAL.GetInstance();

		public TiposItensCardapioEditPage (TipoItemCardapio tipoItemCardapio)
		{
			InitializeComponent ();
            PopularFormulario(tipoItemCardapio);
            RegistraClickBotaoCamera(idtipoitemcardapio.Text.Trim());
            RegistraClickBotaoAlbum();
		}

        private void PopularFormulario(TipoItemCardapio tipoItemCardapio)
        {
            this.tipoItemCardapio = tipoItemCardapio;
            idtipoitemcardapio.Text = tipoItemCardapio.Id.ToString();
            nome.Text = tipoItemCardapio.Nome;
            caminhoArquivo = setArquivoPCL.Result.Path;
            fototipoitemcardapio.Source = ImageSource.FromFile(tipoItemCardapio.CaminhoArquivoFoto);
        }

        private void RegistraClickBotaoAlbum()
        {
            BtnAlbum.Clicked += async (sender, args) =>
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Album não suportado", "Não existe permissão para acessar o album de fotos", "Ok");
                    return;
                }

                var file = await CrossMedia.Current.PickPhotoAsync();
                var getArquivoPCL = FileSystem.Current.GetFileFromPathAsync(file.Path);
                var rootFolder = FileSystem.Current.LocalStorage;
                var folderFoto = await rootFolder.CreateFolderAsync("Fotos", CreationCollisionOption.OpenIfExists);
                var setArquivoPCL = folderFoto.CreateFileAsync(getArquivoPCL.Result.Name, CreationCollisionOption.ReplaceExisting);
                var arquivoLido = getArquivoPCL.Result.ReadAllTextAsync();
                var arquivoEscrito = setArquivoPCL.Result.WriteAllTextAsync(arquivoLido.Result);

                caminhoArquivo = setArquivoPCL.Result.Path;

                if (file == null)
                {
                    return;
                }
                fototipoitemcardapio.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;

                });
            };
        }

        private void RegistraClickBotaoCamera(string idparafoto)
        {
            BtnCamera.Clicked += async (sender, args) =>
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Não existe camera", "A camera não está disponivel.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = FileSystem.Current.LocalStorage.Name,
                    Name = "tipoitem" + idparafoto.Trim() + ".jpg"
                });

                if (file == null)
                {
                    return;
                }

                fototipoitemcardapio.Source = ImageSource.FromFile(file.Path);

                caminhoArquivo = file.Path;
            };
        }

        public async void BtnGravarClick(object sender, EventArgs e)
        {
            //terminar aqui
        }
	}
}