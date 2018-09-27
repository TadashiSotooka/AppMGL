using AppMGL.MGLDatabase.Model;
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
	public partial class Teste : ContentPage
	{
		public Teste ()
		{
			InitializeComponent ();
            //CarregarInformacoes();
            //CarregarAluno();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //CarregarAluno();
            CarregarInformacoes();
        }

        private void CarregarInformacoes()
        {
            var list = ((App)Application.Current).Conexao.Table<Usuario>().ToList();
            ListView.ItemsSource = list;
        }

        /*private void CarregarAluno()
        {
            MBAlunoDal dalAluno = new MBAlunoDal();
            MBPeriodoDal dalPeriodo = new MBPeriodoDal();
            var myAluno = dalAluno.Get();
            var myPeriodo = dalPeriodo.GetItemById(myAluno.codPeriodo);
            lblNome.Text = "Nome: " + myAluno.nome;
            lblPeriodo.Text = "Período: " + myPeriodo.descricao;
            lblEmail.Text = "Email: " + myAluno.email;
            lblCel.Text = "Celular: " + myAluno.cel;
            //Usuario myUsuario = new Usuario();
            //var myUsuario = ((App)Application.Current).Conexao.Table<Usuario>().ToList();
            //lblNome.Text = "Nome: " + myUsuario.nomeUsuario;
            //lblID.Text = "ID: " + myUsuario.idUsuario;
            //lblEmail.Text = "Email: " + myUsuario.email;

        }*/
    }
}