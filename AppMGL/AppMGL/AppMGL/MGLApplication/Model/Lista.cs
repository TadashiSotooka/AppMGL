using System;
using System.Collections.Generic;
using System.Text;

namespace AppMGL.MGLApplication.Model
{
    public class Lista
    {

        public int idUsuario{ get; set; }
        public int idJogo { get; set; }
        public int idFavorito { get; set; }
        public int idCategoriaLista { get; set; }
        public string nomeJogo { get; set; }
        public string notaGeral { get; set; }
        public string dataLancamento { get; set; }
        public string desenvolvedora { get; set; }
        public string estudio { get; set; }
        public string imagem { get; set; }
        public string trailer { get; set; }
        public string plataforma { get; set; }
        public string descricaoJogo { get; set; }

        public string descricaoFavorito { get; set; }
        public string DescricaoCategoria { get; set; }
        
            

    }
}
