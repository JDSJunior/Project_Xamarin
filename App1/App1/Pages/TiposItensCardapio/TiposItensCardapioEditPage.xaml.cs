using App1.DAL;
using App1.Infraestructure;
using App1.Models;
using PCLStorage;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
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
        private TipoItemCardapio tipoItemCardapio = new TipoItemCardapio();
        private DataBase db = new DataBase();

        public TiposItensCardapioEditPage(TipoItemCardapio tipoItemCardapio)
        {
            InitializeComponent();
            PopularFormulario(tipoItemCardapio);
            RegistraClickBotaoCamera();
            RegistraClickBotaoAlbum();
        }



        private void PopularFormulario(TipoItemCardapio tipoItemCardapio)
        {
            this.tipoItemCardapio = tipoItemCardapio;
            idtipoitemcardapio.Text = tipoItemCardapio.Id.ToString();
            nome.Text = tipoItemCardapio.Nome;
            fototipoitemcardapio.Source = ImageSource.FromStream(() => new MemoryStream(tipoItemCardapio.Foto));
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

                if (file == null)
                {
                    return;
                }

                var stream = file.GetStream();
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                fototipoitemcardapio.Source = ImageSource.FromStream(() =>
                {
                    var s = file.GetStream();
                    file.Dispose();
                    return s;
                });
            };
        }

        private void RegistraClickBotaoCamera()
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
                });

                if (file == null)
                {
                    return;
                }

                var stream = file.GetStream();
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);

                tipoItemCardapio.Foto = File.ReadAllBytes(file.Path);

                fototipoitemcardapio.Source = ImageSource.FromStream(() =>
                {
                    var s = file.GetStream();
                    file.Dispose();
                    return s;
                });
            };
        }

        public async void BtnGravarClick(object sender, EventArgs e)
        {
            if (nome.Text.Trim() == string.Empty)
            {
                await this.DisplayAlert("Erro", "Voce precisa informar o nome para o novo tipo de item do cardápio", "OK");
            }
            else
            {
                tipoItemCardapio.Nome = nome.Text;

                db.Update<TipoItemCardapio>(tipoItemCardapio);

                await DisplayAlert("Confirmação.", "O item " + nome.Text.ToUpper() + " foi salvo!", "OK");

                await Navigation.PushModalAsync(new TiposItensPage());
            }
        }
    }
}