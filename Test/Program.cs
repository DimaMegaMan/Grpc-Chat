using System;
using Proto.Chat;
using Grpc.Net.Client;
using Grpc.Core;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ChatService.ChatServiceClient(channel);

            var response =  client.ConnectToChat(new ConnectMessage() { UserName = "Hello"});

            await foreach (var item in response.ResponseStream.ReadAllAsync())
            {

            }
        }
    }
}
