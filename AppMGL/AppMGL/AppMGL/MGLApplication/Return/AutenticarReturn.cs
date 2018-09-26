using AppMGL.MGLApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMGL.MGLApplication.Return
{
    public class AutenticarReturn
    {
        public Usuario usuario { get; set; }
        public string message { get; set; }

        public AutenticarReturn()
        {
            usuario = new Usuario();
            message = "";
        }
    }
}
