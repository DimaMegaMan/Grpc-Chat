using Grpc.Net.Client;
using Proto.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterProcessCommunication.Client.Factories
{
    public class GrpcConnectionFactory : IConnectionFactory
    {
        public ChatService.ChatServiceClient CreateClient()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ChatService.ChatServiceClient(channel);

            return client;
        }
    }
}
