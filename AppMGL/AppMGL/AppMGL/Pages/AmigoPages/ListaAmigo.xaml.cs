using AppMGL.MGLApplication.MApplication;
using AppMGL.MGLApplication.Model;
using AppMGL.MGLApplication.Request;
using AppMGL.MGLApplication.Return;
using AppMGL.Pages.DetalhePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMGL.Pages.AmigoPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaAmigo : ContentPage
	{
        ListaReturn message = new ListaReturn();
        public string codUsuario;

        public ListaAmigo (Amigo amigo)
		{
			InitializeComponent ();
            DesabilitarSelecao();

            codUsuario = amigo.idUsuarioAmigo;

         

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

            //var usuario = ((App)Application.Current).Conexao.Table<Usuario>().ToList().First();
            //codUsuario = amigo.idUsuarioAmigo;

            ListaApplication listaApplication = new ListaApplication();
            var retorno = await Task.Run(() => listaApplication.RetornarListaUsuario(codUsuario));

            if (retorno.message.Equals(""))
            {
                listaJogos.ItemsSource = retorno.listas;
            }
        }

        private async void OnAddLista(object sender, EventArgs e)
        {

            //await DisplayAlert("Clicado", "Info", "OK");
            var action = await DisplayActionSheet("Escolha o status atual do jogo", "Cancel", "", "Completado", "Jogando", "Em  Espera", "Desistiu");
            if (action == "Completado")
            {
                //await Navigation.PushModalAsync(new Teste());
                //await AppMGL.App.NavegarPaginaMasterDetail(new DetalheJogoLista(), "");
                //await Navigation.PushAsync(new Home());
                //Button button = sender as Button;
                //string id = button.CommandParameter.ToString();

                var mi = ((MenuItem)sender);
                var myJogo = mi.CommandParameter as Lista;

                var usuario = ((App)Application.Current).Conexao.Table<Usuario>().ToList().First();
                var codUsuario = usuario.idUsuario;

                ListaRequest listaRequest = new ListaRequest();
                listaRequest.idUsuario = Convert.ToInt32(codUsuario);
                listaRequest.idJogo = Convert.ToInt32(myJogo.idJogo);
                listaRequest.idCategoriaLista = 1;

                //AddDesejoApplication addDesejoApplication = new AddDesejoApplication();
                //var message = addDesejoApplication.addDesejo(listaRequest);
                AddListaApplication addListaApplication = new AddListaApplication();
                var message = addListaApplication.addLista(listaRequest);

                if (message.message.Equals("Adicionado na sua Lista!"))
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
                //Button button = sender as Button;
                //string id = button.CommandParameter.ToString();

                var mi = ((MenuItem)sender);
                var myJogo = mi.CommandParameter as Lista;

                var usuario = ((App)Application.Current).Conexao.Table<Usuario>().ToList().First();
                var codUsuario = usuario.idUsuario;

                ListaRequest listaRequest = new ListaRequest();
                listaRequest.idUsuario = Convert.ToInt32(codUsuario);
                listaRequest.idJogo = Convert.ToInt32(myJogo.idJogo);
                listaRequest.idCategoriaLista = 2;

                //AddDesejoApplication addDesejoApplication = new AddDesejoApplication();
                //var message = addDesejoApplication.addDesejo(listaRequest);
                AddListaApplication addListaApplication = new AddListaApplication();
                var message = addListaApplication.addLista(listaRequest);

                if (message.message.Equals("Adicionado na sua Lista!"))
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

            if (action == "Em  Espera")
            {
                //Button button = sender as Button;
                //string id = button.CommandParameter.ToString();
                var mi = ((MenuItem)sender);
                var myJogo = mi.CommandParameter as Lista;

                var usuario = ((App)Application.Current).Conexao.Table<Usuario>().ToList().First();
                var codUsuario = usuario.idUsuario;

                ListaRequest listaRequest = new ListaRequest();
                listaRequest.idUsuario = Convert.ToInt32(codUsuario);
                listaRequest.idJogo = Convert.ToInt32(myJogo.idJogo);
                listaRequest.idCategoriaLista = 3;

                //AddDesejoApplication addDesejoApplication = new AddDesejoApplication();
                //var message = addDesejoApplication.addDesejo(listaRequest);
                AddListaApplication addListaApplication = new AddListaApplication();
                var message = addListaApplication.addLista(listaRequest);

                if (message.message.Equals("Adicionado na sua Lista!"))
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

            if (action == "Desistiu")
            {
                //Button button = sender as Button;
                //string id = button.CommandParameter.ToString();
                var mi = ((MenuItem)sender);
                var myJogo = mi.CommandParameter as Lista;

                var usuario = ((App)Application.Current).Conexao.Table<Usuario>().ToList().First();
                var codUsuario = usuario.idUsuario;

                ListaRequest listaRequest = new ListaRequest();
                listaRequest.idUsuario = Convert.ToInt32(codUsuario);
                listaRequest.idJogo = Convert.ToInt32(myJogo.idJogo);
                listaRequest.idCategoriaLista = 4;

                //AddDesejoApplication addDesejoApplication = new AddDesejoApplication();
                //var message = addDesejoApplication.addDesejo(listaRequest);
                AddListaApplication addListaApplication = new AddListaApplication();
                var message = addListaApplication.addLista(listaRequest);

                if (message.message.Equals("Adicionado na sua Lista!"))
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


        }

        private async void OnAddDesejo(object sender, EventArgs e)
        {

            //await DisplayAlert("Clicado", "Info", "OK");
            var mi = ((MenuItem)sender);
            var myJogo = mi.CommandParameter as Lista;

            var usuario = ((App)Application.Current).Conexao.Table<Usuario>().ToList().First();
            var codUsuario = usuario.idUsuario;

            DesejoRequest desejoRequest = new DesejoRequest();
            desejoRequest.idUsuario = Convert.ToInt32(codUsuario);
            desejoRequest.idJogo = Convert.ToInt32(myJogo.idJogo);

            AddDesejoApplication addDesejoApplication = new AddDesejoApplication();
            var message = addDesejoApplication.addDesejo(desejoRequest);

            if (message.message.Equals("Adicionado na lista de Desejo!"))
            {
                //await AppMGL.App.NavegarPaginaMasterDetail(new Home(), "sinc");
                listaJogos.ItemsSource = null;
                OnAppearing();
            }
            else
            {
                await DisplayAlert("Alerta!", message.message, "OK");
            }

        }
    }
}