using AppMGL.MGLApplication.MApplication;
using AppMGL.MGLApplication.Model;
using AppMGL.MGLApplication.Request;
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
	public partial class DetalheJogo : ContentPage
	{
        private Jogo jogo;

		public DetalheJogo (Jogo jogo)
		{
			InitializeComponent ();

            if (jogo == null)
                throw new ArgumentNullException(nameof(jogo));
            //vincula o filme ao BindingContext 
            //para fazer o databinding na view
            BindingContext = jogo;
        }

       

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void BtnAddLista(object sender, EventArgs e)
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

        private async void BtnAddDesejo(object sender, EventArgs e)
        {
            // await DisplayAlert("Clicado", "Sair", "OK");
            //var mi = ((MenuItem)sender);
            //var myJogo = mi.CommandParameter as Jogo;
            Button button = sender as Button;
            string id = button.CommandParameter.ToString();

            var usuario = ((App)Application.Current).Conexao.Table<Usuario>().ToList().First();
            var codUsuario = usuario.idUsuario;

            DesejoRequest desejoRequest = new DesejoRequest();
            desejoRequest.idUsuario = Convert.ToInt32(codUsuario);
            desejoRequest.idJogo = Convert.ToInt32(id);

            AddDesejoApplication addDesejoApplication = new AddDesejoApplication();
            var message = addDesejoApplication.addDesejo(desejoRequest);

            if (message.message.Equals("Adicionado na lista de Desejo!"))
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
}