using AppMGL.Pages.DetalhePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMGL.Pages.ProcurarPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheGenero : ContentPage
    {
        public DetalheGenero()
        {
            InitializeComponent();
        }

        private async void BtnAcao(object sender, EventArgs e)
        {
            //await DisplayAlert("Clicado", "Sair", "OK
            //var mi = ((MenuItem)sender);
            //var codJogo = mi.CommandParameter as Jogo;
            //var codJogo = "1";

            await Navigation.PushAsync(new Acao());
        }

        private async void BtnAventura(object sender, EventArgs e)
        {
            //await DisplayAlert("Clicado", "Sair", "OK");
            await Navigation.PushAsync(new Aventura());
        }

        private async void BtnEstrategia(object sender, EventArgs e)
        {
            await DisplayAlert("Clicado", "Sair", "OK");
        }

        private async void BtnRPG(object sender, EventArgs e)
        {
            //await DisplayAlert("Clicado", "Sair", "OK")
            await Navigation.PushAsync(new RPG()); ;
        }

        private async void BtnEsporte(object sender, EventArgs e)
        {
            await DisplayAlert("Clicado", "Sair", "OK");
        }

        private async void BtnCorrida(object sender, EventArgs e)
        {
            await DisplayAlert("Clicado", "Sair", "OK");
        }

        private async void BtnOnline(object sender, EventArgs e)
        {
            //await DisplayAlert("Clicado", "Sair", "OK");
            await Navigation.PushAsync(new Online());
        }

        private async void BtnSimulacao(object sender, EventArgs e)
        {
            await DisplayAlert("Clicado", "Sair", "OK");
        }

        private async void BtnOutros(object sender, EventArgs e)
        {
            await DisplayAlert("Clicado", "Sair", "OK");
        }
    }
}