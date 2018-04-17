using App1.DAL;
using App1.Models;
//using PCLStorage;
//using Plugin.Media;
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
        //private TipoItemCardapioDAL dalTiposItenscardapio = TipoItemCardapioDAL.GetInstance();
        //private string caminhoArquivo;

		public TipoItensCardapioNewPage ()
		{
			InitializeComponent ();
            //PreparaParaNovoTipoItemCardapio();
            //RegistraClickBotaoCamera(idtipoitemcardapio.Text.Trim());
            //RegistraClickBotaoAlbum();
		}

        //private void PreparaParaNovoTipoItemCardapio()
        //{
        //    var novoId = dalTiposItenscardapio.GetAll().Max(x => x.Id) + 1;

        //    idtipoitemcardapio.Text = novoId.ToString().Trim();
        //    nome.Text = string.Empty;
        //    fotoitemcardapio.Source = null;
        //}

        //private void RegistraClickBotaoCamera(string idparafoto)
        //{
        //    BtnCamera.Clicked += async (sender, args) =>
        //    {
        //        //iniciação do plugin de interação com a camera e o album
        //        await CrossMedia.Current.Initialize();

        //        //verificação de disponibilidade da camera e se é possivel tirar foto
        //        if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
        //        {
        //            await DisplayAlert("Não existe câmera", "A câmera não está disponivel.", "Ok");
        //            return;
        //        }

        //        //método que habilita a câmera, informando a pasta onde deverá ser armazenada, o nome a ser dado
        //        //ao arquivo e se é ou não para armazenar a foto também no album
        //        var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
        //        {
        //            Directory = FileSystem.Current.LocalStorage.Name,
        //            Name = "tipoitem_" + idparafoto + "jpg",
        //            SaveToAlbum = true
        //        });

        //        //caso o usuário não tenha tirado a foto, clicando no botão cancelar
        //        if (file == null)
        //        {
        //            return;
        //        }

        //        //Armazena o caminho da foto para ser, utilizado na gravação do item
        //        caminhoArquivo = file.Path;

        //        //recupera a foto e a atribui para o controle visual
        //        fotoitemcardapio.Source = ImageSource.FromStream(() =>
        //        {
        //            var stream = file.GetStream();
        //            file.Dispose();
        //            return stream;
        //        });
        //    };
        //}


        //private void RegistraClickBotaoAlbum()
        //{
        //    //criação do método anônimo para captura do evento click do botão
        //    BtnAlbum.Clicked += async (sender, args) =>
        //    {
        //        //inicialização do plugin de interação com a câmera a album
        //        await CrossMedia.Current.Initialize();

        //        //Verificação de disponibilidade do album
        //        if (!CrossMedia.Current.IsPickPhotoSupported)
        //        {
        //            await DisplayAlert("Album não suportado", "Não existe permissão para acessar o album de fotos", "Ok");
        //            return;
        //        }

        //        //metodo que habilita o album e permite a seleção de uma foto
        //        var file = await CrossMedia.Current.PickPhotoAsync();

        //        //caso o usuario não tenha selecionado uma foto, clicando no botão cancelar
        //        if (file == null)
        //        {
        //            return;
        //        }

        //        //Nas instruções abaixo é feito uso dos componentos PCLStorage e PCLSpecialFolder
        //        //Recupera o arquivo com base no caminho da foto selecionada
        //        var getArquivoPCL = FileSystem.Current.GetFileFromPathAsync(file.Path);

        //        //recupera o caminho raiz da aplicação no dispositivo
        //        var rootFolder = FileSystem.Current.LocalStorage;

        //        //caso a pasta Fotos não existe, ela é criada para armazenamento da foto selecionada
        //        var folderFoto = await rootFolder.CreateFolderAsync("Fotos", CreationCollisionOption.OpenIfExists);

        //        //cria o arquivo referente à foto selecionada
        //        var setArquivoPCL = folderFoto.CreateFileAsync(getArquivoPCL.Result.Name, CreationCollisionOption.ReplaceExisting);

        //        //guarda o caminho do arquivo para ser utilizado na gravação do item criado
        //        caminhoArquivo = setArquivoPCL.Result.Path;

        //        //recupera o arquivo selecionado e o atribui ao controle no formulário
        //        fotoitemcardapio.Source = ImageSource.FromStream(() =>
        //        {
        //            var stream = file.GetStream();
        //            file.Dispose();
        //            return stream;
        //        });
        //    };
        //}

        //public void BtnGravarClick(object sender, EventArgs e)
        //{
        //    if (nome.Text.Trim() == string.Empty)
        //    {
        //        this.DisplayAlert("Erro", "Você precisa informar o nome para o novo tipo de item do cardapio.", "OK");
        //    }
        //    else
        //    {
        //        dalTiposItenscardapio.Add(new TipoItemCardapio()
        //        {
        //            Id = Convert.ToUInt32(idtipoitemcardapio.Text),
        //            Nome = nome.Text,
        //            CaminhoArquivoFoto = caminhoArquivo
        //        });

        //        PreparaParaNovoTipoItemCardapio();
        //    }
        //}
    }
}