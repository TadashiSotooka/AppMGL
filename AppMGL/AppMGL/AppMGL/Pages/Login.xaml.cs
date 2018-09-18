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
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
            txtLogin.Text = "tadashi";
            txtSenha.Text = "0000";
            //txtEmail.Text = "pardal@gmail.com";
            //txtSenha.Text = "1111";
            lblMensagem.IsVisible = false;
        }

        private async void BtnAutenticar(object sender, EventArgs args)
        {
            //await Navigation.PushAsync(new Home());
            //await Navigation.PushAsync(new Teste1());
            //await Navigation.PushModalAsync(new Home());
            await Navigation.PushModalAsync(new MainPage());

            /*var minhaConexao = Plugin.Connectivity.CrossConnectivity.Current.IsConnected;
            if (minhaConexao.Equals(true))
            {
                lblCadastro.IsVisible = false;
                lblQuestion.IsVisible = false;
                lblMensagem.IsVisible = true;

                Usuario usuario = new Usuario();

                AutenticacaoApplication autApp = new AutenticacaoApplication();

                lblMensagem.Text = "Aguarde, validando usuário";
                await Task.Delay(50);


                usuario = autApp.Autenticar(txtLogin.Text, txtSenha.Text);

                if (usuario.autenticado == "S")
                {
                    // CriarUsuario(cliente);
                    UsuarioApplication usuarioApplication = new UsuarioApplication();
                    usuarioApplication.Add(usuario);
                    await Navigation.PushModalAsync(new MainPage());
                    lblMensagem.Text = "";
                }
                else
                {
                    lblMensagem.Text = "";
                    await DisplayAlert("Erro", usuario.mensagem, "OK");
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
            await Navigation.PushAsync(new Cadastro());
        }

        protected override bool OnBackButtonPressed()
        {

            return true;

        }
    }
}