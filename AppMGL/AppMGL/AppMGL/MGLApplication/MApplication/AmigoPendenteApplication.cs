using AppMGL.MGLApplication.Return;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AppMGL.MGLApplication.MApplication
{
    public class AmigoPendenteApplication
    {
        public AmigoReturn RetornarAmigo(string codUsuario)
        {

            AmigoReturn retorno = new AmigoReturn();

            HttpClient client = new HttpClient();

            client.MaxResponseContentBufferSize = 256000;

            var uri = new Uri("http://tccmgl-com.umbler.net/webservices/mglservices/amigo/readByPendente.php?idUsuario=" + codUsuario);

            var response = client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<AmigoReturn>(content.Result);
            }

            return retorno;
        }
    }
}
