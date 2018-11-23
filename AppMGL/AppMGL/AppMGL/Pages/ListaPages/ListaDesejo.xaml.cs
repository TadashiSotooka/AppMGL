using AppMGL.MGLApplication.MApplication;
using AppMGL.MGLApplication.Model;
using AppMGL.MGLApplication.Return;
using AppMGL.Pages.DetalhePages;
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
	public partial class ListaDesejo : ContentPage
	{
        public string codUsuario;

        DesejoReturn message = new DesejoReturn();

        public ListaDesejo ()
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

            ListaDesejoApplication listaApplication = new ListaDesejoApplication();
            var retorno = await Task.Run(() => listaApplication.RetornarListaDesejo(codUsuario));

            if (retorno.message.Equals(""))
            {
                listaJogos.ItemsSource = retorno.listas;
            }
        }

        private async void OnDetalhe(object sender, EventArgs e)
        {

            await DisplayAlert("Clicado", "Info", "OK");
        }

        private async void OnAdd(object sender, EventArgs e)
        {

            await DisplayAlert("Clicado", "Info", "OK");
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var myJogo = mi.CommandParameter as Lista;

            var minhaConexao = Plugin.Connectivity.CrossConnectivity.Current.IsConnected;
            if (minhaConexao.Equals(true))
            {
                DeletarDesejoApplication appDelete = new DeletarDesejoApplication();
                //var retorno = appDelete.DeletarJogo(myJogo.idJogo);
                message = appDelete.DeletarJogo(myJogo.idJogo);

                if (message.message.Equals("Excluido da lista de desejo!"))
                {
                    listaJogos.ItemsSource = null;
                    OnAppearing();

                }
            }
            else
            {
                await DisplayAlert("Alerta!", message.message, "OK");
                //await DisplayAlert("Alerta", "Algo deu errado!", "OK");
            }
        }

        /* private async void onTapped(object sender, EventArgs args)
         {
             var action = await DisplayActionSheet("", "Cancel", "", "Detalhes do Jogo", "Adicionar Jogo na Lista", "Remover Jodo da Lista de Desejo");
             if (action == "Detalhes do Jogo")
             {
                 //await Navigation.PushModalAsync(new Teste());
                 await AppMGL.App.NavegarPaginaMasterDetail(new DetalheJogo(), "");
                 //await Navigation.PushAsync(new Home());
             }

             if (action == "Adicionar Jogo na Lista")
             {
                 await AppMGL.App.NavegarPaginaMasterDetail(new Home(), "sinc");
             }

             if (action == "Remover Jodo da Lista de Desejo")
             {
                 await AppMGL.App.NavegarPaginaMasterDetail(new Home(), "sinc");
             }


         }*/

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