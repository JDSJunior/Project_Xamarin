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
	public partial class TiposItensNewPage : ContentPage
	{
        private DataBase dataBase = new DataBase();
        private byte[] bytesFoto = null;

        public TiposItensNewPage ()
		{
            InitializeComponent();
            PreparaParaNovoTipoItemCardapio();
            RegistraClickBotaoCamera();
            RegistraClickBotaoAlbum();
        }

        private void PreparaParaNovoTipoItemCardapio()
        {
            var novoId = dataBase.GetAll<TipoItemCardapio>().Max(X => X.Id) + 1;
            idItemCardapio.Text = novoId.ToString();
            nome.Text = string.Empty;
            fototipoitemcardapio.Source = null;
        }

        private void RegistraClickBotaoCamera()
        {
            BtnCamera.Clicked += async (sender, args) =>
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Não Existe Camêra", "A camêra não está disponivel", "Ok");
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

                fototipoitemcardapio.Source = ImageSource.FromStream(() =>
                {
                    var s = file.GetStream();
                    file.Dispose();
                    return s;
                });

                bytesFoto = memoryStream.ToArray();
            };
        }

        private void RegistraClickBotaoAlbum()
        {
            //criação do metodo anonimo para a captura do evento click do botão
            BtnAlbum.Clicked += async (sender, args) =>
            {

                //inicialização do plugin de camera
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Album não suportado", "Não existe permissão para acessar o álbum de fotos", "Ok");
                    return;
                }

                //metodo que habilita o album e permite a selecão
                var file = await CrossMedia.Current.PickPhotoAsync();

                //caso o usuario não tenha selecionado nenhua foto, clicando no botão cancelar

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

                //bytesFoto = memoryStream.ToArray();

                //instruções de recuração de arquivo com base no caminho
                //var getArquivoPcl = FileSystem.Current.GetFileFromPathAsync(file.Path);

                //recupera o caminho raiz da aplicação
                //var rootFolder = FileSystem.Current.LocalStorage;

                //caso a pasta fotos não exista ela é criada
                //var folderFoto = await rootFolder.CreateFolderAsync("Fotos", CreationCollisionOption.OpenIfExists);

                //cria o arquivo referente a foto selecionada
                //var setArquivoPCL = folderFoto.CreateFileAsync(getArquivoPcl.Result.Name, CreationCollisionOption.ReplaceExisting);

                //guarda o caminho referente a foto selecionada
                //var caminhoArquivo = setArquivoPCL.Result.Path;

                //recupera o arquivo selecionado e o atribui ao controle o formulario
                fototipoitemcardapio.Source = ImageSource.FromStream(() =>
                {
                    var stm = file.GetStream();
                    file.Dispose();
                    return stm;
                });
            };
        }

        public void BtnGravarClick(object sender, EventArgs args)
        {
            if (nome.Text.Trim() == string.Empty)
            {
                this.DisplayAlert("Erro,", "Você precisa informar o nome para o novo tipo de item do cardápio.", "OK");
            }
            else
            {
                dataBase.SaveItem(new TipoItemCardapio()
                {
                    Nome = nome.Text,
                    Foto = bytesFoto
                });

                PreparaParaNovoTipoItemCardapio();


            }
        }
    }
}