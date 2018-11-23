using AppMGL.MGLApplication.MApplication;
using AppMGL.MGLApplication.Model;
using AppMGL.MGLApplication.Request;
using AppMGL.MGLApplication.Return;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMGL.Pages.ListaPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Favorito : ContentPage
	{
        ListaReturn message = new ListaReturn();
        public string codUsuario;

        public Favorito ()
		{
			InitializeComponent ();
            DesabilitarSelecao();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ListarJogos();
        }

        private void DesabilitarSelecao()
        {
            listaJogos.ItemSelected += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };
        }

        private async void ListarJogos()
        {

            var usuario = ((App)Application.Current).Conexao.Table<Usuario>().ToList().First();
            codUsuario = usuario.idUsuario;

            ListaFavoritoApplication listaApplication = new ListaFavoritoApplication();
            var retorno = await Task.Run(() => listaApplication.RetornarListaUsuario(codUsuario));

            if (retorno.message.Equals(""))
            {
                listaJogos.ItemsSource = retorno.listas;
            }
        }



        private async void OnDetalhe(object sender, EventArgs e)
        {

            await DisplayAlert("Clicado", "Info", "OK");
        }

        private async void OnTroca(object sender, EventArgs e)
        {

            //await DisplayAlert("Clicado", "Info", "OK");
            //Button button = sender as Button;
            //string id = button.CommandParameter.ToString();
            var mi = ((MenuItem)sender);
            var myJogo = mi.CommandParameter as Lista;

            var usuario = ((App)Application.Current).Conexao.Table<Usuario>().ToList().First();
            var codUsuario = usuario.idUsuario;

            ListaRequest listaRequest = new ListaRequest();
            listaRequest.idUsuario = Convert.ToInt32(codUsuario);
            listaRequest.idJogo = Convert.ToInt32(myJogo.idJogo);
            listaRequest.idFavorito = 2;

            //AddDesejoApplication addDesejoApplication = new AddDesejoApplication();
            //var message = addDesejoApplication.addDesejo(listaRequest);

            FavoritoApplication favoritoApplication = new FavoritoApplication();
            var message = favoritoApplication.addFavorito(listaRequest);

            if (message.message.Equals("Status do Favorito Trocado!"))
            {
                //await AppMGL.App.NavegarPaginaMasterDetail(new Home(), "sinc");
                //listaJogos.ItemsSource = null;
                OnAppearing();
            }
            else
            {
                await DisplayAlert("Alerta!", message.message, "OK");
            }
        }

        // -- 

        private async void OnClickRecarregar(object sender, EventArgs e)
        {

            //await DisplayAlert("Clicado", "Info", "OK");
            //await Navigation.PushModalAsync(new Home());
            //await Navigation.PushAsync(new Home());
            await Task.Delay(50);
            await AppMGL.App.NavegarPaginaMasterDetail(new Home(), "sinc");
        }

        private async void OnClickSair(object sender, EventArgs e)
        {
            //await DisplayAlert("Clicado", "Sair", "OK");

            ((App)Application.Current).Conexao.DeleteAll<Usuario>();
            await AppMGL.App.NavegarPaginaMasterDetail(new Login(), "modal");
            /*UsuarioApplication usuarioApplication = new UsuarioApplication();
            usuarioApplication.DeleteAll();


            await AppMGL.App.NavegarPaginaMasterDetail(new Autenticacao(), "modal");*/
        }
    }
}