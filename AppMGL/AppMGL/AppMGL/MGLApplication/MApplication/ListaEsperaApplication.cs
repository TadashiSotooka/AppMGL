using AppMGL.MGLApplication.Return;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AppMGL.MGLApplication.MApplication
{
    public class ListaEsperaApplication
    {
        public ListaReturn RetornarListaUsuario(string codUsuario)
        {

            ListaReturn retorno = new ListaReturn();

            HttpClient client = new HttpClient();

            client.MaxResponseContentBufferSize = 256000;

            var uri = new Uri("http://tccmgl-com.umbler.net/webservices/mglservices/lista/readEspera.php?idUsuario=" + codUsuario);

            var response = client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<ListaReturn>(content.Result);
            }

            return retorno;
        }
    }
}
