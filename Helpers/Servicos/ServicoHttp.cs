using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Remeberme.Helpers.Servicos
{
    public class ServicoHttp
    {
        public string Get(string url)
        {
            string resposta = string.Empty;

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    Uri uri = new Uri(url);
                    httpClient.BaseAddress = uri;
                    Task<HttpResponseMessage> task = httpClient.GetAsync(uri);
                    task.Wait();

                    HttpResponseMessage httpResponseMessage = task.Result;
                    Task<string> taskContent = httpResponseMessage.Content.ReadAsStringAsync();
                    taskContent.Wait();

                    //logComunicacao.CorpoResposta = taskContent.Result;

                    if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                    {
                        //SUCESSI
                        resposta = taskContent.Result;
                    }
                    else
                    {
                        //ERRO
                    }
                }

                return resposta;
            }
            catch (Exception)
            {
                throw new NotSupportedException();
            }
        }
    }
}
