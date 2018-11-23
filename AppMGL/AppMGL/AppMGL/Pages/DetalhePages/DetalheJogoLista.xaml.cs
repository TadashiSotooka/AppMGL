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

namespace AppMGL.Pages.DetalhePages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalheJogoLista : ContentPage
	{
        ListaReturn message = new ListaReturn();
        private Lista _lista;
		public DetalheJogoLista (Lista lista)
        {
			InitializeComponent ();

            _lista = lista;

            if (lista == null)
                throw new ArgumentNullException(nameof(lista));

            BindingContext = lista;
           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void BtnFavorito(object sender, EventArgs e)
        {
            //await DisplayAlert("Clicado", "Sair", "OK");
            var action = await DisplayActionSheet("Escolha o status atual do jogo", "Cancel", "", "Adicionar aos Favoritos", "Remover aos Favoritos");
            if (action == "Adicionar aos Favoritos")
            {
                Button button = sender as Button;
                string id = button.CommandParameter.ToString();
                
                var usuario = ((App)Application.Current).Conexao.Table<Usuario>().ToList().First();
                var codUsuario = usuario.idUsuario;

                ListaRequest listaRequest = new ListaRequest();
                listaRequest.idUsuario = Convert.ToInt32(codUsuario);
                listaRequest.idJogo = Convert.ToInt32(id);
                listaRequest.idFavorito = 1;

                FavoritoApplication favoritoApplication = new FavoritoApplication();
                var message = favoritoApplication.addFavorito(listaRequest);

                if (message.message.Equals("Status do Favorito Trocado!"))
                {

                    OnAppearing();
                }
                else
                {
                    await DisplayAlert("Alerta!", message.message, "OK");
                }
            }

            if (action == "Remover aos Favoritos")
            {
                Button button = sender as Button;
                string id = button.CommandParameter.ToString();

                var usuario = ((App)Application.Current).Conexao.Table<Usuario>().ToList().First();
                var codUsuario = usuario.idUsuario;

                ListaRequest listaRequest = new ListaRequest();
                listaRequest.idUsuario = Convert.ToInt32(codUsuario);
                listaRequest.idJogo = Convert.ToInt32(id);
                listaRequest.idFavorito = 2;

                FavoritoApplication favoritoApplication = new FavoritoApplication();
                var message = favoritoApplication.addFavorito(listaRequest);

                if (message.message.Equals("Status do Favorito Trocado!"))
                {

                    OnAppearing();
                }
                else
                {
                    await DisplayAlert("Alerta!", message.message, "OK");
                }
            }

        }

        private async void BtnStatus(object sender, EventArgs e)
        {
            //await DisplayAlert("Clicado", "Sair", "OK");
            var action = await DisplayActionSheet("Escolha o status atual do jogo", "Cancel", "", "Completado", "Jogando", "Em  Espera", "Desistiu");
            if (action == "Completado")
            {
                //await Navigation.PushModalAsync(new Teste());
                //await AppMGL.App.NavegarPaginaMasterDetail(new DetalheJogoLista(), "");
                //await Navigation.PushAsync(new Home());
                Button button = sender as Button;
                string id = button.CommandParameter.ToString();

                var usuario = ((App)Application.Current).Conexao.Table<Usuario>().ToList().First();
                var codUsuario = usuario.idUsuario;

                ListaRequest listaRequest = new ListaRequest();
                listaRequest.idUsuario = Convert.ToInt32(codUsuario);
                listaRequest.idJogo = Convert.ToInt32(id);
                listaRequest.idCategoriaLista = 1;

                //AddDesejoApplication addDesejoApplication = new AddDesejoApplication();
                //var message = addDesejoApplication.addDesejo(listaRequest);
                StatusApplication statusApplication = new StatusApplication();
                var message = statusApplication.TrocarStatus(listaRequest);

                if (message.message.Equals("Status Trocado!"))
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

            if (action == "Jogando")
            {
                //await AppMGL.App.NavegarPaginaMasterDetail(new StatusJogo(), "");
                Button button = sender as Button;
                string id = button.CommandParameter.ToString();

                var usuario = ((App)Application.Current).Conexao.Table<Usuario>().ToList().First();
                var codUsuario = usuario.idUsuario;

                ListaRequest listaRequest = new ListaRequest();
                listaRequest.idUsuario = Convert.ToInt32(codUsuario);
                listaRequest.idJogo = Convert.ToInt32(id);
                listaRequest.idCategoriaLista = 2;

                //AddDesejoApplication addDesejoApplication = new AddDesejoApplication();
                //var message = addDesejoApplication.addDesejo(listaRequest);
                StatusApplication statusApplication = new StatusApplication();
                var message = statusApplication.TrocarStatus(listaRequest);

                if (message.message.Equals("Status Trocado!"))
                {
                    //await AppMGL.App.NavegarPaginaMasterDetail(new Home(), "sinc");
                    //listaJogos.ItemsSource = null;
                    OnAppearing();
                    //await Navigation.PushAsync(new DetalheJogoLista(lista));


                }
                else
                {
                    await DisplayAlert("Alerta!", message.message, "OK");
                }
            }

            if (action == "Em  Espera")
            {
                Button button = sender as Button;
                string id = button.CommandParameter.ToString();

                var usuario = ((App)Application.Current).Conexao.Table<Usuario>().ToList().First();
                var codUsuario = usuario.idUsuario;

                ListaRequest listaRequest = new ListaRequest();
                listaRequest.idUsuario = Convert.ToInt32(codUsuario);
                listaRequest.idJogo = Convert.ToInt32(id);
                listaRequest.idCategoriaLista = 3;

                //AddDesejoApplication addDesejoApplication = new AddDesejoApplication();
                //var message = addDesejoApplication.addDesejo(listaRequest);
                StatusApplication statusApplication = new StatusApplication();
                var message = statusApplication.TrocarStatus(listaRequest);

                if (message.message.Equals("Status Trocado!"))
                {
                    //await AppMGL.App.NavegarPaginaMasterDetail(new Home(), "sinc");
                    //listaJogos.ItemsSource = null;
                    //await Task.Delay(50);
                    OnAppearing();
                    //await Navigation.PushAsync(new DetalheJogoLista(lista));
                }
                else
                {
                    await DisplayAlert("Alerta!", message.message, "OK");
                }
            }

            if (action == "Desistiu")
            {
                Button button = sender as Button;
                string id = button.CommandParameter.ToString();

                var usuario = ((App)Application.Current).Conexao.Table<Usuario>().ToList().First();
                var codUsuario = usuario.idUsuario;

                ListaRequest listaRequest = new ListaRequest();
                listaRequest.idUsuario = Convert.ToInt32(codUsuario);
                listaRequest.idJogo = Convert.ToInt32(id);
                listaRequest.idCategoriaLista = 4;

                //AddDesejoApplication addDesejoApplication = new AddDesejoApplication();
                //var message = addDesejoApplication.addDesejo(listaRequest);
                StatusApplication statusApplication = new StatusApplication();
                var message = statusApplication.TrocarStatus(listaRequest);

                if (message.message.Equals("Status Trocado!"))
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
            //await DisplayAlert("Clicado", "Sair", "OK");

        }

        private async void BtnAtualizar(object sender, EventArgs e)
        {
            //await DisplayAlert("Clicado", "Sair", "OK");
            await Task.Delay(50);
            await AppMGL.App.NavegarPaginaMasterDetail(new Home(), "sinc");
            //await Navigation.PushAsync(new DetalheJogoLista());

            //Button button = sender as Button;
            //string id = button.CommandParameter.ToString();

            //var mi = ((MenuItem)sender);
            //var codJogo = mi.CommandParameter as Lista;

            //await Navigation.PushAsync(new DetalheJogoLista(id));

            //BindingContext = _lista;
            //OnAppearing();

        }

       
        private async void BtnRemover(object sender, EventArgs e)
        {
            //await DisplayAlert("Clicado", "Sair", "OK");
            //await Task.Delay(50);

            Button button = sender as Button;
            string id = button.CommandParameter.ToString();

            //Convert.ToInt32(idJogo);
            //Convert.ToInt32(myJogo.idJogo);


            //var mi = ((MenuItem)sender);
            // var myJogo = mi.CommandParameter as Lista;

            var minhaConexao = Plugin.Connectivity.CrossConnectivity.Current.IsConnected;
            if (minhaConexao.Equals(true))
            {
                DeletarListaApplication appDelete = new DeletarListaApplication();
                //var retorno = appDelete.DeletarJogo(myJogo.idJogo);
                message = appDelete.DeletarJogo(Convert.ToInt32(id));

                if (message.message.Equals("Excluido da sua Lista!"))
                {
                    //listaJogos.ItemsSource = null;
                    //OnAppearing();
                    await AppMGL.App.NavegarPaginaMasterDetail(new Home(), "sinc");

                }
            }
            else
            {
                await DisplayAlert("Alerta!", message.message, "OK");
                //await DisplayAlert("Alerta", "Algo deu errado!", "OK");
            }

        }
    }
}