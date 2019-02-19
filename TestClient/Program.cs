using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Grpc.Core;
using MagicOnion.Client;
using Mo.Service.Interface;

namespace TestClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Test Client";
            Console.WriteLine("Test Client Start...");

            // call method.
            Stopwatch sw = new Stopwatch();
            sw.Start();


            for (int i = 0; i < 10000; i++)
            {
                await CallService();
            }


            sw.Stop();
            Console.WriteLine($"耗时:{sw.ElapsedMilliseconds}ms");
            Console.ReadLine();
        }

        private static async Task CallService()
        {
            // standard gRPC channel
            var channel = new Channel("localhost", 12345, ChannelCredentials.Insecure);

            // create MagicOnion dynamic client proxy
            var client = MagicOnionClient.Create<IMyFirstService>(channel);

            // call method.
            var result = await client.SumAsync(100, 200);
            Console.WriteLine("Client Received:" + result);
        }
    }
}
