﻿using AppMGL.MGLApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMGL.MGLApplication.Return
{
    public class DesejoReturn
    {
        public List<Jogo> listas { get; set; }
        public string message { get; set; }
        public DesejoReturn()
        {
            message = "";
        }
    }
}
