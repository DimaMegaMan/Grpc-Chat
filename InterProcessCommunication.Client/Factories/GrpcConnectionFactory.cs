using Grpc.Net.Client;
using Proto.Chat;

namespace Chat.Client.Factories
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
