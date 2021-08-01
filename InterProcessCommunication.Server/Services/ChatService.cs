using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Proto.Chat;

namespace Chat.Server.Services
{
    /// <summary>
    /// Service that implements publisher subscriber pattern 
    /// </summary>
    public class ChatService : Proto.Chat.ChatService.ChatServiceBase
    {
        public Model.Chat Chat { get; }

        public ChatService(Model.Chat chat)
        {
            Chat = chat;
        }

        /// <summary>
        /// Subscribe the client to be notified of new messages 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="responseStream"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ConnectToChat(ConnectMessage request, IServerStreamWriter<ChatMessage> responseStream, ServerCallContext context)
        {
            Chat.OnAddMessageHandler += responseStream.WriteAsync;
            return WaitForCancellation(context.CancellationToken);
        }

        /// <summary>
        /// Send message to the client
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task<Empty> SendMessage(ChatMessage request, ServerCallContext context)
        {
            await Chat.AddMessage(request);
            return new Empty();
        }

        /// <summary>
        /// Await cancellationToken cancelation 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private static Task WaitForCancellation(CancellationToken cancellationToken)
        {
            var taskSource = new TaskCompletionSource();
            //add handler to cancellation of cancellationToken
            cancellationToken.Register(() => taskSource.SetResult());
            return taskSource.Task;
        }

    }
}
