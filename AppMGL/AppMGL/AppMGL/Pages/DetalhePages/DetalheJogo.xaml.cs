using AppMGL.MGLApplication.MApplication;
using AppMGL.MGLApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMGL.Pages.DetalhePages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalheJogo : ContentPage
	{
        private Jogo jogo;

		public DetalheJogo ()
		{
			InitializeComponent ();
		}

    }
}