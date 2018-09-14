using AppMGL.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMGL
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Master = new Perfil();
            this.Detail = new NavigationPage(new Home());
            App.MasterDetail = this;
        }

    }
}
