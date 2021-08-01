using Proto.Chat;

namespace InterProcessCommunication.Client.Factories
{
    public interface IConnectionFactory
    {
        public ChatService.ChatServiceClient CreateClient();
    }
}
