using System;
using System.Collections.Generic;
using System.Text;

namespace AppMGL.MGLApplication.Request
{
    public class AutenticarRequest
    {
        public string login { get; set; }
        public string senha { get; set; }
        public AutenticarRequest()
        {
            login = "";
            senha = "";
        }
    }
}
