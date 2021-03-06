﻿using AppMGL.MGLApplication.Return;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AppMGL.MGLApplication.MApplication
{
    public class ListaDesejoApplication
    {

        public DesejoReturn RetornarListaDesejo(string codUsuario)
        {

            DesejoReturn retorno = new DesejoReturn();

            HttpClient client = new HttpClient();

            client.MaxResponseContentBufferSize = 256000;

            var uri = new Uri("http://tccmgl-com.umbler.net/webservices/mglservices/lista/readDesejo.php?idUsuario=" + codUsuario);

            var response = client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<DesejoReturn>(content.Result);
            }

            return retorno;
        }
    }
}
