using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMGL.MGLDatabase.Model
{
    public class Usuario
    {
        [PrimaryKey]
        public string idUsuario { get; set; }
        public string nomeUsuario { get; set; }
        public string nomePais { get; set; }
        public string email { get; set; }
        public string dataAniversario { get; set; }
        public string tagJogador { get; set; }
        public string nomePlataforma { get; set; }


        public string login { get; set; }
        public string senha { get; set; }
        public string autenticado { get; set; }
        public string mensagem { get; set; }
    }
}
