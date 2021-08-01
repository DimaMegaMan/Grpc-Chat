using Proto.Chat;

namespace Chat.Client.Factories
{
    public interface IConnectionFactory
    {
        public ChatService.ChatServiceClient CreateClient();
    }
}
