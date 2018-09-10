using AppMGL.Pages.TestePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMGL.Pages.AutenticacaoPage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Autenticacao : ContentPage
	{
        /*public Autenticacao ()
		{
			InitializeComponent();
		}*/

        public Autenticacao()
        {
            InitializeComponent();
            txtEmail.Text = "andrey.tadashi@hotmail.com";
            txtSenha.Text = "0000";
            lblMensagem.IsVisible = false;
        }

        private async void BtnAutenticar(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new Teste1());

            /* var minhaConexao = Plugin.Connectivity.CrossConnectivity.Current.IsConnected;
             if (minhaConexao.Equals(true))
             {
                 lblCadastro.IsVisible = false;
                 lblQuestion.IsVisible = false;
                 lblMensagem.IsVisible = true;

                 Cliente cliente = new Cliente();

                 AutenticarApplication autApp = new AutenticarApplication();

                 lblMensagem.Text = "Aguarde, validando usuário";
                 await Task.Delay(50);


                 cliente = autApp.Autenticar(txtUsuario.Text, txtSenha.Text);

                 if (cliente.autenticado == "S")
                 {
                     // CriarUsuario(cliente);
                     ClienteApplication clienteApplication = new ClienteApplication();
                     clienteApplication.Add(cliente);
                     await Navigation.PushModalAsync(new MainPage());
                     lblMensagem.Text = "";
                 }
                 else
                 {
                     lblMensagem.Text = "";
                     await DisplayAlert("Erro", cliente.mensagem, "OK");
                     lblMensagem.IsVisible = false;
                     lblQuestion.IsVisible = true;
                     lblCadastro.IsVisible = true;
                 }
             }
             else
             {
                 await DisplayAlert("Alerta", "Sem conexão com a internet!", "OK");
             }*/
        }

        private async void onClickCadastrar(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Teste2());
        }

        protected override bool OnBackButtonPressed()
        {

            return true;

        }

    }
}
