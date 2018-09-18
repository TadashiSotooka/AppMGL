using AppMGL.MGLApplication.Return;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AppMGL.MGLApplication.MApplication
{
    public class PlataformaApplication
    {
        public PlataformaReturn RetornarPlataforma()
        {

            PlataformaReturn retorno = new PlataformaReturn();

            HttpClient client = new HttpClient();

            client.MaxResponseContentBufferSize = 256000;

            var uri = new Uri(" http://tccmgl-com.umbler.net/webservices/mglservices/plataforma/read.php ");

            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            //content.Headers.Add("Expect100Continue", "false");

            var response = client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<PlataformaReturn>(content.Result);
            }

            return retorno;
        }
    }
}
