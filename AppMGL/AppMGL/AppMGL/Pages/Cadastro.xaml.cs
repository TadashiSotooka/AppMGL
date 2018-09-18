using AppMGL.MGLApplication.MApplication;
using AppMGL.MGLApplication.Model;
using AppMGL.MGLApplication.Request;
using AppMGL.MGLApplication.Return;
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
    public partial class Cadastro : ContentPage
    {
        //RetornoMessage message = new RetornoMessage();
        CadastroReturn message = new CadastroReturn();
        public int idNacionalidade = 0;
        public int idPlataforma = 0;
        List<Nacionalidade> ListaNacionalidade;
        List<Plataforma> ListaPlataforma;

        public Cadastro()
        {
            InitializeComponent();
            CarregarNacionalidade();
            CarregarPlataforma();
            lblMessage.IsVisible = false;
        }

        private async void CarregarPlataforma()
        {
            PlataformaApplication plataformaApplication = new PlataformaApplication();
            var retorno = plataformaApplication.RetornarPlataforma();

            if (retorno.message == "" && !retorno.plataformas.Count().Equals(0))
            {
                ListaPlataforma = new List<Plataforma>();
                pickerPlataforma.Items.Clear();

                foreach (var plataforma in retorno.plataformas)
                {
                    pickerPlataforma.Items.Add(plataforma.nomePlataforma);
                    ListaPlataforma.Add(plataforma);
                }

                //pickerPlataforma.SelectedIndex = 0;
            }
            else
            {
                await DisplayAlert("Alerta!", retorno.message, "OK");
            }
        }

        private async void CarregarNacionalidade()
        {
            NacionalidadeApplication nacionalidadeApplication = new NacionalidadeApplication();
            var retorno = nacionalidadeApplication.RetornarNacionalidade();

            if (retorno.message == "" && !retorno.nacionalidades.Count().Equals(0))
            {
                ListaNacionalidade = new List<Nacionalidade>();
                pickerNacionalidade.Items.Clear();

                foreach (var nacionalidade in retorno.nacionalidades)
                {
                    pickerNacionalidade.Items.Add(nacionalidade.nomePais);
                    ListaNacionalidade.Add(nacionalidade);
                }

                //pickerNacionalidade.SelectedIndex = 0;
            }
            else
            {
                await DisplayAlert("Alerta!", retorno.message, "OK");
            }
        }

        public void OnSelectPlataforma(object sender, EventArgs e)
        {
            var plataformaSelecionado = ListaPlataforma[pickerPlataforma.SelectedIndex];
            idPlataforma = plataformaSelecionado.idPlataforma;
        }

        public void OnSelectNacionalidade(object sender, EventArgs e)
        {
            var nacionalidadeSelecionado = ListaNacionalidade[pickerNacionalidade.SelectedIndex];
            idNacionalidade = nacionalidadeSelecionado.idNacionalidade;
        }

        public async void BtnCadastrar(object sender, EventArgs e)
        {
            var minhaConexao = Plugin.Connectivity.CrossConnectivity.Current.IsConnected;
            if (minhaConexao.Equals(true))
            {
                lblMessage.IsVisible = true;
                lblMessage.Text = "Aguarde, criando sua conta!";
                await Task.Delay(50);

                CadastroRequest cadastroRequest = new CadastroRequest();
                cadastroRequest.nomeUsuario = txtNome.Text;
                cadastroRequest.email = txtEmail.Text;
                cadastroRequest.tagJogador = txtTag.Text;
                cadastroRequest.login = txtLogin.Text;
                cadastroRequest.senha = txtSenha.Text;

                cadastroRequest.idPlataforma = idPlataforma.ToString();
                cadastroRequest.idNacionalidade = idNacionalidade.ToString();

                CadastroApplication cadastroApplication = new CadastroApplication();
                message = cadastroApplication.Cadastrar(cadastroRequest);

                if (message.message.Equals("Usuario registrado."))
                {
                    lblMessage.IsVisible = false;
                    //await Navigation.PopAsync();
                    await DisplayAlert("Bem vindo!", "Sua conta foi criada com sucesso!", "OK");
                    await Navigation.PushModalAsync(new Login());
                }
                else
                {
                    lblMessage.IsVisible = false;
                    await DisplayAlert("Erro", message.message, "OK");

                }
            }
            else
            {
                await DisplayAlert("Alerta", "Sem conexão com a internet!", "OK");
            }

        }
    }
}
