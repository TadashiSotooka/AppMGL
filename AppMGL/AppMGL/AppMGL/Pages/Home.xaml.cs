using AppMGL.MGLApplication.MApplication;
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
	public partial class Home : ContentPage
	{
        public string idUsuario = "1";
		public Home ()
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

        private void ListarJogos()
        {
            ListaApplication listaApplication = new ListaApplication();
            var retorno = listaApplication.RetornarListaUsuario(idUsuario);

            if (retorno.message.Equals(""))
            {
                listaJogos.ItemsSource = retorno.listas;
            }
        }


        private async void OnClickInfo(object sender, EventArgs e)
        {

            await DisplayAlert("Clicado", "Info", "OK");
        }

        private async void OnClickSair(object sender, EventArgs e)
        {
            await DisplayAlert("Clicado", "Sair", "OK");

            /*UsuarioApplication usuarioApplication = new UsuarioApplication();
            usuarioApplication.DeleteAll();

            await AppMGL.App.NavegarPaginaMasterDetail(new Autenticacao(), "modal");*/
        }
    }
}