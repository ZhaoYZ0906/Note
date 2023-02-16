using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;

namespace ClientCredentials
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //discovery endpoint
            var client = new HttpClient();
            var disco=  await client.GetDiscoveryDocumentAsync("http://localhost:5000");

            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }


            //request access token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest() {
                Address = disco.TokenEndpoint,
                ClientId = "console client",
                //密令，在idp的客户端配置那里有
                ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A",
                //请求范围
                Scope = "api1"
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            //call API
            var apiclient = new HttpClient();
            apiclient.SetBearerToken(tokenResponse.AccessToken);
            var respone= await apiclient.GetAsync("http://localhost:5001/identity");
            if (!respone.IsSuccessStatusCode)
            {
                Console.WriteLine(respone.StatusCode);
            }
            else {
                var content = await respone.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }


            Console.ReadLine();
        }
    }
}
