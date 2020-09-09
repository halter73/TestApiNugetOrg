using System;
using System.Net.Http;
using System.Net.Security;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TestApiNugetOrg
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //using var client = new HttpClient(new WinHttpHandler());
            //using var client = new HttpClient();
            using var tcpClient = new TcpClient();
            await tcpClient.ConnectAsync("api.nuget.org", 443);
            using var tcpStream = tcpClient.GetStream();

            using var sslStream = new SslStream(tcpStream);
            await sslStream.AuthenticateAsClientAsync(new SslClientAuthenticationOptions
            {
                TargetHost = "api.nuget.org"
            });

            //var response = await client.GetStringAsync("https://api.nuget.org/v3/index.json");
            //var response = await client.GetStringAsync("https://google.com");

            Console.WriteLine("Received response");
            Console.WriteLine();
            //Console.WriteLine(response);
            Console.ReadLine();
        }
    }
}
