using System;
using RestSharp;

namespace restful_client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            try
            {
                var client = new RestClient(@"http://localhost:8081") { ReadWriteTimeout = 1000000, Timeout = 1000000 };
                var request = new RestRequest("connect/token", Method.POST, DataFormat.Json) { ReadWriteTimeout = 1000000, Timeout = 1000000 };

                request.AddParameter("grant_type", "client_credentials", ParameterType.GetOrPost);
                request.AddParameter("client_id", "app_lds", ParameterType.GetOrPost);
                request.AddParameter("client_secret", "jgktjgkt99", ParameterType.GetOrPost);

                var resp = client.Execute<Token>(request);
                Console.WriteLine(resp.StatusCode);
                Console.WriteLine(resp.Content);

                Console.WriteLine("请输入获取数量：");
                var num = Console.ReadLine();

                request = new RestRequest($"api/values/{num}", Method.GET);
                request.AddHeader("Authorization", $"{resp.Data.TokenType} {resp.Data.AccessToken}");
                var respc = client.Execute(request);
                Console.WriteLine(respc.StatusCode);
                Console.WriteLine(respc.StatusDescription);
                Console.WriteLine(respc.Content);
                Console.WriteLine(respc.ErrorMessage);
                Console.WriteLine(respc.ErrorException);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                var key = string.Empty;

                do
                {
                    key = Console.ReadLine();
                } while (key.ToUpper() != "EXIT");
            }
        }
    }
}
