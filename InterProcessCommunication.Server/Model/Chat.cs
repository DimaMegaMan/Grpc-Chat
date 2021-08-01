using System;
using System.Threading.Tasks;
using Proto.Chat;

namespace Chat.Server.Model
{
    public class Chat
    {
        public int Id { get; set; }
        public event Func<ChatMessage, Task> OnAddMessageHandler;

        public async Task AddMessage(ChatMessage chatMessage)
        {
            if (OnAddMessageHandler == null)
            {
                return;
            }

            Delegate[] invocationList = OnAddMessageHandler.GetInvocationList();
            Task[] handlerTasks = new Task[invocationList.Length];

            for (int i = 0; i < invocationList.Length; i++)
            {
                handlerTasks[i] = ((Func<ChatMessage, Task>)invocationList[i])(chatMessage);
            }

            await Task.WhenAll(handlerTasks);
        }
    }
}
