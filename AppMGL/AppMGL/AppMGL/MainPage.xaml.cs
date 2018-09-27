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

        protected override bool OnBackButtonPressed()
        {
            if (App.PosLogin == "S")
            {
                // If you want to stop the back button
                return true;
            }
            else
            {
                return false;
            }
            // If you want to continue going back
            //base.OnBackButtonPressed();
            //return false;

        }

    }
}
