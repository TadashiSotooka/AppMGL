using AppMGL.MGLApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMGL.MGLApplication.Return
{
    public class NacionalidadeReturn
    {
        public List<Nacionalidade> nacionalidades { get; set; }
        public string message { get; set; }
        public NacionalidadeReturn()
        {
            nacionalidades = new List<Nacionalidade>();
            message = "";
        }
    }
}
