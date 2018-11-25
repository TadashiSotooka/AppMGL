using AppMGL.MGLApplication.Request;
using AppMGL.MGLApplication.Return;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AppMGL.MGLApplication.MApplication
{
    public class AmigoUpdateApplication
    {
        public MessageReturn TrocarAmigo(AmigoRequest amigoRequest)
        {
            MessageReturn retorno = new MessageReturn();

            try
            {

                var json = JsonConvert.SerializeObject(amigoRequest);

                HttpClient client = new HttpClient();

                client.MaxResponseContentBufferSize = 256000;

                var uri = new Uri("http://tccmgl-com.umbler.net/webservices/mglservices/amigo/updateAmigo.php");

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync(uri, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content2 = response.Content.ReadAsStringAsync();

                    retorno = JsonConvert.DeserializeObject<MessageReturn>(content2.Result);
                }

            }
            catch (Exception ex)
            {

                retorno.message = ex.Message;
            }
            return retorno;
        }
    }
}


