using AppMGL.MGLApplication.Model;
using AppMGL.MGLApplication.Request;
using AppMGL.MGLApplication.Return;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AppMGL.MGLApplication.MApplication
{
    public class DeletarDesejoApplication
    {
        public DesejoReturn DeletarJogo(DesejoRequest listaRequest)
        {
            DesejoReturn myMessage = new DesejoReturn();
            //Jogo myJogo = new Jogo();
            try
            {

                //myJogo.idJogo = idJogo;
              


                var json = JsonConvert.SerializeObject(listaRequest);

                HttpClient client = new HttpClient();

                client.MaxResponseContentBufferSize = 256000;

                //CONFIGURA A URL BASE
                var uri = new Uri("http://tccmgl-com.umbler.net/webservices/mglservices/service/service_deleteDesejo.php");

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                //content.Headers.Add("Expect100Continue", "false");

                var response = client.PostAsync(uri, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content2 = response.Content.ReadAsStringAsync();

                    myMessage = JsonConvert.DeserializeObject<DesejoReturn>(content2.Result);
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
