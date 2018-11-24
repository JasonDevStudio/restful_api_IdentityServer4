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
                var client = new RestClient(@"http://localhost:8081");
                var request = new RestRequest("connect/token", Method.POST,DataFormat.Json);
                request.AddParameter("grant_type", "client_credentials", ParameterType.RequestBody);
                request.AddParameter("client_id", "app_lds", ParameterType.RequestBody);
                request.AddParameter("client_secret", "jgktjgkt99", ParameterType.RequestBody);

                var resp = client.Execute(request);
                Console.WriteLine(resp.StatusCode);
                Console.WriteLine(resp.Content);

                request = new RestRequest("api/default",Method.GET);
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
