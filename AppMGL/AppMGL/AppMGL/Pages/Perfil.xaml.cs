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

        private async void onClickLogout(object sender, EventArgs args)
        {
            await DisplayAlert("Clicado", "Sair", "OK");

            /*ClienteApplication clienteApplication = new ClienteApplication();
            clienteApplication.DeleteAll();

            await GoodFoodV4.App.NavegarPaginaMasterDetail(new AutenticacaoPage(), "modal");*/

        }

        private async void onClickTeste(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new Teste());
            //await DisplayAlert("Clicado", "Sair", "OK");

            /*ClienteApplication clienteApplication = new ClienteApplication();
            clienteApplication.DeleteAll();

            await GoodFoodV4.App.NavegarPaginaMasterDetail(new AutenticacaoPage(), "modal");*/

        }
    }
}