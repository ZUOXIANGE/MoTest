using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Grpc.Core;
using MagicOnion.Client;
using Mo.Service.Interface;
using Model;

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
            var r = new Random();

            for (int i = 0; i < 10000; i++)
            {
                var person = new Person
                {
                    No = r.Next(1000),
                    Sex = i % 2 == 0 ? Gender.Female : Gender.Male,
                    Age = r.Next(100),
                    Birthday = DateTime.Now.AddHours(-1 * i),
                    Name = r.Next(1000).ToString()
                };
                Stopwatch sw1 = new Stopwatch();
                sw1.Start();
                await CallService(person);
                sw1.Stop();
                Console.WriteLine($"单次耗时:{sw1.ElapsedMilliseconds}ms");
            }

            sw.Stop();
            Console.WriteLine($"总耗时:{sw.ElapsedMilliseconds}ms");
            Console.ReadLine();
        }

        private static async Task CallService()
        {
            // standard gRPC channel
            var channel = new Channel("localhost", 78945, ChannelCredentials.Insecure);

            // create MagicOnion dynamic client proxy
            var client = MagicOnionClient.Create<IMyFirstService>(channel);

            // call method.
            var result = await client.SumAsync(100, 200);

            Console.WriteLine("Client Received:" + result);
        }

        private static async Task CallService(Person person)
        {
            // standard gRPC channel
            var channel = new Channel("localhost", 78945, ChannelCredentials.Insecure);

            // create MagicOnion dynamic client proxy
            var client = MagicOnionClient.Create<IMyFirstService>(channel);

            // call method.
            var result = await client.ObjToStr(person);

            Console.WriteLine("Client Received:" + result);
        }
    }
}
