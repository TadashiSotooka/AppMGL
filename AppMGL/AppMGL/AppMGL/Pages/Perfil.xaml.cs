using AppMGL.Pages.AmigoPages;
using AppMGL.Pages.ListaPages;
using AppMGL.Pages.ProcurarPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMGL.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Perfil : ContentPage
	{
		public Perfil ()
		{
			InitializeComponent ();
		}

        private async void onClickLista(object sender, EventArgs args)
        {
            var action = await DisplayActionSheet("Minha Lista", "Cancel", "", "Todos os Jogos", "Completado", "Jogando", "Em Espera", "Desistiu");
            if(action == "Todos os Jogos")
            {
                //await Navigation.PushModalAsync(new Teste());
                await AppMGL.App.NavegarPaginaMasterDetail(new Home(), "sinc");
                //await Navigation.PushAsync(new Home());
            }
            if (action == "Completado")
            {
                await AppMGL.App.NavegarPaginaMasterDetail(new Completado(), "");
            }
            if (action == "Jogando")
            {
                await AppMGL.App.NavegarPaginaMasterDetail(new Jogando(), "");
            }
            if (action == "Em Espera")
            {
                await AppMGL.App.NavegarPaginaMasterDetail(new Espera(), "");
            }
            if (action == "Desistiu")
            {
                await AppMGL.App.NavegarPaginaMasterDetail(new Desistiu(), "");
            }

            //await DisplayAlert("Clicado", "Sair", "OK");

            /*ClienteApplication clienteApplication = new ClienteApplication();
            clienteApplication.DeleteAll();

            await GoodFoodV4.App.NavegarPaginaMasterDetail(new AutenticacaoPage(), "modal");*/

        }

        private async void onClickProcurar(object sender, EventArgs args)
        {
            var action = await DisplayActionSheet( "Procurar", "Cancel", "", "Buscar por Jogo", "Todos os Jogos", 
                                                  "Gênero", "Top Jogos", "Mais Populares", "Lançamentos", "Em Breve" );
            if (action == "Buscar por Jogo")
            {
                await Navigation.PushModalAsync(new Teste());
            }
            if (action == "Todos os Jogos")
            {
                await AppMGL.App.NavegarPaginaMasterDetail(new TodosJogos(), "");
            }
            if (action == "Gênero")
            {
                await Navigation.PushModalAsync(new Teste());
            }
            if (action == "Top Jogos")
            {
                await Navigation.PushModalAsync(new Teste());
            }
            if (action == "Mais Populares")
            {
                await Navigation.PushModalAsync(new Teste());
            }
            if (action == "Lançamentos")
            {
                await Navigation.PushModalAsync(new Teste());
            }
            if (action == "Em Breve")
            {
                await Navigation.PushModalAsync(new Teste());
            }
            //await DisplayAlert("Clicado", "Sair", "OK");

            /*ClienteApplication clienteApplication = new ClienteApplication();
            clienteApplication.DeleteAll();

            await GoodFoodV4.App.NavegarPaginaMasterDetail(new AutenticacaoPage(), "modal");*/

        }


        private async void onClickFavorito(object sender, EventArgs args)
        {
            //await DisplayAlert("Clicado", "Sair", "OK");

            //await Navigation.PushModalAsync(new Favorito());
            await AppMGL.App.NavegarPaginaMasterDetail(new Favorito(), "");
            //await Navigation.PushAsync(new Favorito());

            /*ClienteApplication clienteApplication = new ClienteApplication();
            clienteApplication.DeleteAll();

            await GoodFoodV4.App.NavegarPaginaMasterDetail(new AutenticacaoPage(), "modal");*/

        }

        private async void onClickDesejo(object sender, EventArgs args)
        {
            //await DisplayAlert("Clicado", "Sair", "OK");

            await AppMGL.App.NavegarPaginaMasterDetail(new ListaDesejo(), "");

            /*ClienteApplication clienteApplication = new ClienteApplication();
            clienteApplication.DeleteAll();

            await GoodFoodV4.App.NavegarPaginaMasterDetail(new AutenticacaoPage(), "modal");*/

        }


        private async void onClickAmigos(object sender, EventArgs args)
        {
            //await DisplayAlert("Clicado", "Sair", "OK");
            await AppMGL.App.NavegarPaginaMasterDetail(new Amigos(), "");
            /*ClienteApplication clienteApplication = new ClienteApplication();
            clienteApplication.DeleteAll();

            await GoodFoodV4.App.NavegarPaginaMasterDetail(new AutenticacaoPage(), "modal");*/

        }

        private async void onClickJogador(object sender, EventArgs args)
        {
            await DisplayAlert("Clicado", "Sair", "OK");

            //await Navigation.PushModalAsync(new Teste());

            /*ClienteApplication clienteApplication = new ClienteApplication();
            clienteApplication.DeleteAll();

            await GoodFoodV4.App.NavegarPaginaMasterDetail(new AutenticacaoPage(), "modal");*/
            

        }


        private async void onClickLogout(object sender, EventArgs args)
        {
            await DisplayAlert("Clicado", "Sair", "OK");

            /*ClienteApplication clienteApplication = new ClienteApplication();
            clienteApplication.DeleteAll();

            await GoodFoodV4.App.NavegarPaginaMasterDetail(new AutenticacaoPage(), "modal");*/

        }

        private async void onClickTeste(object sender, EventArgs args)
        {
            //await Navigation.PushModalAsync(new Teste2());
            await AppMGL.App.NavegarPaginaMasterDetail(new Teste2(), "");

            //await DisplayAlert("Clicado", "Sair", "OK");

            /*ClienteApplication clienteApplication = new ClienteApplication();
            clienteApplication.DeleteAll();

            await GoodFoodV4.App.NavegarPaginaMasterDetail(new AutenticacaoPage(), "modal");*/

        }

        private async void onClickTeste2(object sender, EventArgs args)
        {
            //await Navigation.PushModalAsync(new TodosJogos());
            await AppMGL.App.NavegarPaginaMasterDetail(new TodosJogos(), "");

            //await DisplayAlert("Clicado", "Sair", "OK");

            /*ClienteApplication clienteApplication = new ClienteApplication();
            clienteApplication.DeleteAll();

            await GoodFoodV4.App.NavegarPaginaMasterDetail(new AutenticacaoPage(), "modal");*/

        }

        private async void onClickPerfil(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new Teste());
            //await DisplayAlert("Clicado", "Sair", "OK");

            /*ClienteApplication clienteApplication = new ClienteApplication();
            clienteApplication.DeleteAll();

            await GoodFoodV4.App.NavegarPaginaMasterDetail(new AutenticacaoPage(), "modal");*/

        }

        

        /* private async void onClickTeste(object sender, EventArgs args)
         {
             await Navigation.PushModalAsync(new Teste());


         }

         private async void onClickTesteCard(object sender, EventArgs args)
         {
             await Navigation.PushModalAsync(new TesteCard());


         }*/
    }
}