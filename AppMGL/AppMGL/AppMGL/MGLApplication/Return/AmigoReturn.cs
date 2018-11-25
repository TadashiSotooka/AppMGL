using AppMGL.MGLApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMGL.MGLApplication.Return
{
    public class AmigoReturn
    {
        public List<Amigo> amigos { get; set; }
        public string message { get; set; }

        public AmigoReturn()
        {
            amigos = new List<Amigo>();
            message = "";
        }
    }
}
