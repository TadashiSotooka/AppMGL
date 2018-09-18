using AppMGL.MGLApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMGL.MGLApplication.Return
{
    public class PlataformaReturn
    {
        public List<Plataforma> plataformas { get; set; }
        public string message { get; set; }
        public PlataformaReturn()
        {
            plataformas = new List<Plataforma>();
            message = "";
        }
    }
}
