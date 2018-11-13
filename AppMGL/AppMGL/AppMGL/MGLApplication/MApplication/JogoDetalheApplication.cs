using AppMGL.MGLApplication.Return;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AppMGL.MGLApplication.MApplication
{
    public class JogoDetalheApplication
    {
        public JogoReturn RetornarJogo(string codJogo)
        {

            JogoReturn retorno = new JogoReturn();

            HttpClient client = new HttpClient();

            client.MaxResponseContentBufferSize = 256000;

            var uri = new Uri("http://tccmgl-com.umbler.net/webservices/mglservices/jogo/read_one.php?idJogo=" + codJogo);

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

