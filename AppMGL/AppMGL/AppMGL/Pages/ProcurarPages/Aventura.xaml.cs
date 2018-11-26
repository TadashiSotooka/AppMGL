using System;
using System.Collections.Generic;
using AppMGL.MGLApplication.MApplication;
using AppMGL.MGLApplication.Model;
using AppMGL.MGLApplication.Request;
using AppMGL.MGLApplication.Return;
using AppMGL.Pages.DetalhePages;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMGL.Pages.ProcurarPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Aventura : ContentPage
	{
        DesejoReturn message = new DesejoReturn();
        public Aventura ()
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
            var codGenero = "2";

            JogoGeneroApplication jogoApplication = new JogoGeneroApplication();
            var retorno = await Task.Run(() => jogoApplication.RetornarJogo(codGenero));

            if (retorno.message.Equals(""))
            {
                listaJogos.ItemsSource = retorno.jogos;
            }
        }


        private async void OnDetalhe(object sender, EventArgs e)
        {

            //await DisplayAlert("Clicado", "Info", "OK");
            /*var item = e.Item;
            var codJogo = (item as Jogo);*/
            var mi = ((MenuItem)sender);
            var codJogo = mi.CommandParameter as Jogo;

            await Navigation.PushAsync(new DetalheJogo(codJogo));
        }

        private async void OnAdd(object sender, EventArgs e)
        {

            var mi = ((MenuItem)sender);
            var myJogo = mi.CommandParameter as Jogo;

            var usuario = ((App)Application.Current).Conexao.Table<Usuario>().ToList().First();
            var codUsuario = usuario.idUsuario;

            DesejoRequest desejoRequest = new DesejoRequest();
            desejoRequest.idUsuario = Convert.ToInt32(codUsuario);
            desejoRequest.idJogo = Convert.ToInt32(myJogo.idJogo);

            AddDesejoApplication addDesejoApplication = new AddDesejoApplication();
            message = addDesejoApplication.addDesejo(desejoRequest);

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

            //await DisplayAlert("Clicado", "Info", "OK");
        }

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