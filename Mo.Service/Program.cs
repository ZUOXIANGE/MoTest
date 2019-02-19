using System;
using Grpc.Core;
using Grpc.Core.Logging;
using MagicOnion.Server;

namespace Mo.Service
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "Service";
            GrpcEnvironment.SetLogger(new ConsoleLogger());

            // setup MagicOnion and option.
            var service = MagicOnionEngine.BuildServerServiceDefinition(true);

            var server = new Server
            {
                Services = { service },
                Ports = { new ServerPort("localhost", 12345, ServerCredentials.Insecure) }
            };

            // launch gRPC Server.
            server.Start();
            Console.WriteLine($"Service start at {server.Ports}");

            // and wait.
            Console.ReadLine();
        }
    }
}