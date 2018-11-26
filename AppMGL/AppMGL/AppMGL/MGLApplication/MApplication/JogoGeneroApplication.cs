using AppMGL.MGLApplication.Return;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AppMGL.MGLApplication.MApplication
{
    public class JogoGeneroApplication
    {
        public JogoReturn RetornarJogo(string codGenero)
        {

            JogoReturn retorno = new JogoReturn();

            HttpClient client = new HttpClient();

            client.MaxResponseContentBufferSize = 256000;

            var uri = new Uri("http://tccmgl-com.umbler.net/webservices/mglservices/jogo/readGenero.php?idGenero=" + codGenero);

            var response = client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<JogoReturn>(content.Result);
            }

            return retorno;
        }
    }
}

