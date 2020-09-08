using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestApiNugetOrg
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using var client = new HttpClient();

            var response = await client.GetStringAsync("https://api.nuget.org/v3/index.json");
            //var response = await client.GetStringAsync("https://google.com");

            Console.WriteLine("Received response");
            Console.WriteLine();
            Console.WriteLine(response);
        }
    }
}
