using AppMGL.MGLApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMGL.MGLApplication.Return
{
    public class ListaReturn
    {
        public List<Lista> listas { get; set; }
        public string message { get; set; }

        public ListaReturn()
        {
            listas = new List<Lista>();
            message = "";
        }
    }
}
