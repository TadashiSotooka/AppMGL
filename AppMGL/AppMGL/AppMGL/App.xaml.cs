using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMGL.Pages;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppMGL
{
    public partial class App : Application
    {
        
        public static MasterDetailPage MasterDetail { get; set; }
        public async static Task NavegarPaginaMasterDetail(Page pagina, string x)
        {
            App.MasterDetail.IsPresented = false;
            if (x.Equals("sinc"))
            {
                MasterDetail.Detail = new NavigationPage(pagina);
            }
            else if (x.Equals("modal"))
            {
                await App.MasterDetail.Detail.Navigation.PushModalAsync(pagina);
            }
            else
            {
                await App.MasterDetail.Detail.Navigation.PushAsync(pagina);
            }
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new AppMGL.MainPage();
            MainPage = new NavigationPage(new Login());
            //MainPage = new NavigationPage(new Teste2());

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
