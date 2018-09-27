using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMGL.Pages;
using PCLExt.FileStorage.Folders;
using SQLite;
using PCLExt.FileStorage;
using AppMGL.MGLDatabase.Model;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppMGL
{
    public partial class App : Application
    {
        public static string PosLogin { get; set; }
        public static MasterDetailPage MasterDetail { get; set; }
        public SQLiteConnection Conexao { get; set; }

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
            var pasta = new LocalRootFolder();
            var arquivo = pasta.CreateFile("banco.db", CreationCollisionOption.OpenIfExists);
            Conexao = new SQLiteConnection(arquivo.Path);
            Conexao.CreateTable<Usuario>();

            InitializeComponent();
            //MainPage = new NavigationPage(new Login());
            //MainPage = new AppMGL.MainPage();  
            //MainPage = new NavigationPage(new Teste2());

            //ClienteApplication myCliente = new ClienteApplication();
            //var cliente = myCliente.GetAll().ToList().Count();
            //var list = ((App)Application.Current).Conexao.Table<Usuario>().ToList();
            //ListView.ItemsSource = list;
            var usuario = ((App)Application.Current).Conexao.Table<Usuario>().ToList().Count();

            if (usuario.Equals(0))
            //if (cliente == null)
            {
                PosLogin = "S";
                MainPage = new NavigationPage(new Login());
            }
            else
            {
                PosLogin = "N";
                MainPage = new AppMGL.MainPage();
            }

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
