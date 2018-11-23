using AppMGL.MGLApplication.MApplication;
using AppMGL.MGLApplication.Model;
using AppMGL.MGLApplication.Request;
using AppMGL.MGLApplication.Return;
using AppMGL.Pages.DetalhePages;
using AppMGL.Pages.ListaPages;
//using AppMGL.MGLDatabase.Model;
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
        ListaReturn message = new ListaReturn();
        public string codUsuario;

        public Home()
        {
            InitializeComponent();
            DesabilitarSelecao();

            _refreshCommand = new Command(RefreshList);

            listaJogos.IsPullToRefreshEnabled = true;
            listaJogos.RefreshCommand = OnRefresh;
            listaJogos.SetBinding(ListView.IsRefreshingProperty, nameof(IsBusy));
        }

        Command _refreshCommand;
        public Command OnRefresh
        {
            get { return _refreshCommand; }
        }

        private async void RefreshList()
        {
            listaJogos.ItemsSource = null;
            //lblDuvida.Text = "";
            var minhaConexao = Plugin.Connectivity.CrossConnectivity.Current.IsConnected;
            if (minhaConexao.Equals(true))
            {
                ListarJogos();
            }
            else
            {
                await DisplayAlert("Alerta", "Sem conexão com a internet!", "OK");
            }
            listaJogos.SetBinding(ListView.IsRefreshingProperty, nameof(IsBusy));
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

            ListaApplication listaApplication = new ListaApplication();
            var retorno = await Task.Run(() => listaApplication.RetornarListaUsuario(codUsuario));

            if (retorno.message.Equals(""))
            {
                listaJogos.ItemsSource = retorno.listas;
            }
        }

        /*private async void onTapped(object sender, EventArgs args)
        {
            var action = await DisplayActionSheet("", "Cancel", "", "Detalhes do Jogo", "Trocar Status do Jogo", "Adicionar aos Favoritos", "Excluir da Lista");
            if (action == "Detalhes do Jogo")
            {
                //await Navigation.PushModalAsync(new Teste());
                await AppMGL.App.NavegarPaginaMasterDetail(new DetalheJogoLista(), "");
                //await Navigation.PushAsync(new Home());
            }
            if (action == "Trocar Status do Jogo")
            {
                await AppMGL.App.NavegarPaginaMasterDetail(new StatusJogo(), "");
            }
            if (action == "Adicionar aos Favoritos")
            {
                await AppMGL.App.NavegarPaginaMasterDetail(new Home(), "sinc");
            }
            if (action == "Excluir da Lista")
            {
                await AppMGL.App.NavegarPaginaMasterDetail(new Home(), "sinc");
            }

        }*/


        private async void OnDetalhe(object sender, EventArgs e)
        {

            //await DisplayAlert("Clicado", "Info", "OK");
            var mi = ((MenuItem)sender);
            var codJogo = mi.CommandParameter as Lista;

            await Navigation.PushAsync(new DetalheJogoLista(codJogo));
        }

        private async void OnTroca(object sender, EventArgs e)
        {

            //await DisplayAlert("Clicado", "Info", "OK");
            //Button button = sender as Button;
            //string id = button.CommandParameter.ToString();
            var mi = ((MenuItem)sender);
            var myJogo = mi.CommandParameter as Lista;

            var usuario = ((App)Application.Current).Conexao.Table<Usuario>().ToList().First();
            var codUsuario = usuario.idUsuario;

            ListaRequest listaRequest = new ListaRequest();
            listaRequest.idUsuario = Convert.ToInt32(codUsuario);
            listaRequest.idJogo = Convert.ToInt32(myJogo.idJogo);
            listaRequest.idFavorito = 1;

            //AddDesejoApplication addDesejoApplication = new AddDesejoApplication();
            //var message = addDesejoApplication.addDesejo(listaRequest);

            FavoritoApplication favoritoApplication = new FavoritoApplication();
            var message = favoritoApplication.addFavorito(listaRequest);

            if (message.message.Equals("Status do Favorito Trocado!"))
            {
                //await AppMGL.App.NavegarPaginaMasterDetail(new Home(), "sinc");
                //listaJogos.ItemsSource = null;
                OnAppearing();
            }
            else
            {
                await DisplayAlert("Alerta!", message.message, "OK");
            }
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var myJogo = mi.CommandParameter as Lista;
            
            var minhaConexao = Plugin.Connectivity.CrossConnectivity.Current.IsConnected;
            if (minhaConexao.Equals(true))
            {
                DeletarListaApplication appDelete = new DeletarListaApplication();
                //var retorno = appDelete.DeletarJogo(myJogo.idJogo);
                message = appDelete.DeletarJogo(myJogo.idJogo);

                if (message.message.Equals("Excluido da sua Lista!"))
                {
                    listaJogos.ItemsSource = null;
                    OnAppearing();
                    //await AppMGL.App.NavegarPaginaMasterDetail(new Home(), "sinc");

                }
            }
            else
            {
                await DisplayAlert("Alerta!", message.message, "OK");
                //await DisplayAlert("Alerta", "Algo deu errado!", "OK");
            }
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