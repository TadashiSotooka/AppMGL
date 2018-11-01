//using AppMGL.MGLApplication.Model;
using AppMGL.MGLApplication.Request;
using AppMGL.MGLApplication.Return;
using AppMGL.MGLDatabase.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AppMGL.MGLApplication.MApplication
{
    public class AutenticarApplication
    {
        public Usuario Autenticar(String login, String senha)
        {
            Usuario usuario = new Usuario();
            usuario.autenticado = "N";
            usuario.mensagem = "";

            try
            {
                if (String.IsNullOrEmpty(login))
                {
                    usuario.mensagem = "Email não informado";
                    return usuario;
                }

                if (String.IsNullOrEmpty(senha))
                {
                    usuario.mensagem = "Senha não informada";
                    return usuario;
                }

                AutenticarRequest autenticacaoRequest = new AutenticarRequest();
                AutenticarReturn retorno = new AutenticarReturn();

                autenticacaoRequest.login = login.Trim();
                autenticacaoRequest.senha = senha.Trim();

                var json = JsonConvert.SerializeObject(autenticacaoRequest);
                HttpClient client = new HttpClient();
                client.MaxResponseContentBufferSize = 256000;

                var uri = new Uri("http://tccmgl-com.umbler.net/webservices/mglservices/service/service_usuario.php");
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync(uri, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content2 = response.Content.ReadAsStringAsync();
                    retorno = JsonConvert.DeserializeObject<AutenticarReturn>(content2.Result);
                }

                if (retorno.message.Equals("") || retorno.message.Equals(null))
                {
                    usuario.idUsuario = retorno.usuario.idUsuario;
                    usuario.nomeUsuario = retorno.usuario.nomeUsuario;
                    usuario.email = retorno.usuario.email;
                    usuario.nomePais = retorno.usuario.nomePais;
                    usuario.dataAniversario = retorno.usuario.dataAniversario;
                    usuario.tagJogador = retorno.usuario.tagJogador;
                    usuario.nomePlataforma = retorno.usuario.nomePlataforma;
                    usuario.login = retorno.usuario.login;
                    usuario.mensagem = "Usuário Autenticado";
                    usuario.autenticado = "S";
                }

                else
                {
                    usuario.mensagem = "Email ou Senha Invalidos";
                }
            }
            catch (Exception ex)
            {

                usuario.mensagem = ex.Message;
            }
            return usuario;
        }
    }
}
