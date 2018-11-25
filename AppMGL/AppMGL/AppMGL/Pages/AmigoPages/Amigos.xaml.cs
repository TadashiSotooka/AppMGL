using AppMGL.MGLApplication.MApplication;
using AppMGL.MGLApplication.Model;
using AppMGL.MGLApplication.Request;
//using AppMGL.MGLDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMGL.Pages.AmigoPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Amigos : ContentPage
    {

            public string codUsuario;

            public Amigos()
            {
                InitializeComponent();
                DesabilitarSelecao();
            }

            protected override void OnAppearing()
            {
                base.OnAppearing();
                ListarAmigos();
            }

            private void DesabilitarSelecao()
            {
                listaAmigos.ItemSelected += (sender, e) =>
                {
                    ((ListView)sender).SelectedItem = null;
                };
            }

            private async void ListarAmigos()
            {

                var usuario = ((App)Application.Current).Conexao.Table<Usuario>().ToList().First();
                codUsuario = usuario.idUsuario;

                AmigoApplication listaApplication = new AmigoApplication();
                var retorno = await Task.Run(() => listaApplication.RetornarAmigo(codUsuario));

                if (retorno.message.Equals(""))
                {
                    listaAmigos.ItemsSource = retorno.amigos;
                }
            }

           

            private async void OnInfo(object sender, EventArgs e)
            {

            //await DisplayAlert("Clicado", "Info", "OK");
            var mi = ((MenuItem)sender);
            var codAmigo = mi.CommandParameter as Amigo;

            await Navigation.PushAsync(new ListaAmigo(codAmigo));

        }

            private async void OnDelete(object sender, EventArgs e)
            {

            //await DisplayAlert("Clicado", "Info", "OK");
            //await DisplayAlert("Clicado", "Info", "OK");
            var mi = ((MenuItem)sender);
            var myAmigo = mi.CommandParameter as Amigo;

            var usuario = ((App)Application.Current).Conexao.Table<Usuario>().ToList().First();
            var codUsuario = usuario.idUsuario;

            AmigoRequest amigoRequest = new AmigoRequest();
            amigoRequest.idUsuario = Convert.ToInt32(codUsuario);
            amigoRequest.idUsuarioAmigo = Convert.ToInt32(myAmigo.idUsuarioAmigo);
            amigoRequest.idSituacao = 2;

            //AddDesejoApplication addDesejoApplication = new AddDesejoApplication();
            //var message = addDesejoApplication.addDesejo(listaRequest);

            AmigoUpdateApplication amigoUpdateApplication = new AmigoUpdateApplication();
            var message = amigoUpdateApplication.TrocarAmigo(amigoRequest);

            if (message.message.Equals("Situação de Amizade Trocada!"))
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

        private async void OnClickPendente(object sender, EventArgs e)
        {

            //await DisplayAlert("Clicado", "Info", "OK");
            //await Navigation.PushModalAsync(new AmigoPendente());
            await Navigation.PushAsync(new AmigoPendente());
            //await Task.Delay(50);
            //await AppMGL.App.NavegarPaginaMasterDetail(new Home(), "sinc");
        }

        private async void OnClickRejeitado(object sender, EventArgs e)
        {

            //await DisplayAlert("Clicado", "Info", "OK");
            //await Navigation.PushModalAsync(new AmigoRejeitado());
            await Navigation.PushAsync(new AmigoRejeitado());
            //await Task.Delay(50);
            //await AppMGL.App.NavegarPaginaMasterDetail(new Home(), "sinc");
        }


    }
    
}