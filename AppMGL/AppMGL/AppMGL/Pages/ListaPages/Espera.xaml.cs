using AppMGL.MGLApplication.MApplication;
using AppMGL.MGLApplication.Model;
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
	public partial class Espera : ContentPage
	{
        public string codUsuario;

        public Espera ()
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

            ListaEsperaApplication listaApplication = new ListaEsperaApplication();
            var retorno = await Task.Run(() => listaApplication.RetornarListaUsuario(codUsuario));

            if (retorno.message.Equals(""))
            {
                listaJogos.ItemsSource = retorno.listas;
            }
        }



        private async void OnInfo(object sender, EventArgs e)
        {

            await DisplayAlert("Clicado", "Info", "OK");
        }

        private async void OnDelete(object sender, EventArgs e)
        {

            await DisplayAlert("Clicado", "Info", "OK");
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