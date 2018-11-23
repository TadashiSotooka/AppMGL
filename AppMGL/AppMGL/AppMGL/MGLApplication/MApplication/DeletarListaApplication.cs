using AppMGL.MGLApplication.Model;
using AppMGL.MGLApplication.Return;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AppMGL.MGLApplication.MApplication
{
    public class DeletarListaApplication
    {
        public ListaReturn DeletarJogo(int idJogo)
        {
            ListaReturn myMessage = new ListaReturn();
            Lista myJogo = new Lista();
            try
            {

                myJogo.idJogo = idJogo;



                var json = JsonConvert.SerializeObject(myJogo);

                HttpClient client = new HttpClient();

                client.MaxResponseContentBufferSize = 256000;

                //CONFIGURA A URL BASE
                var uri = new Uri("http://tccmgl-com.umbler.net/webservices/mglservices/service/service_deleteLista.php");

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                //content.Headers.Add("Expect100Continue", "false");

                var response = client.PostAsync(uri, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content2 = response.Content.ReadAsStringAsync();

                    myMessage = JsonConvert.DeserializeObject<ListaReturn>(content2.Result);
                }

            }
            catch (Exception ex)
            {
                myMessage.message = ex.Message;
            }

            return myMessage;
        }
    }
}
