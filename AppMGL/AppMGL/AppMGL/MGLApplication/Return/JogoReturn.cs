using AppMGL.MGLApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMGL.MGLApplication.Return
{
    public class JogoReturn
    {
        public List<Jogo> jogos { get; set; }
        public string message { get; set; }
        public JogoReturn()
        {
            jogos = new List<Jogo>();
            message = "";
        }
    }
}

