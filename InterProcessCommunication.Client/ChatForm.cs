using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chat.Client.Factories;
using Grpc.Core;
using Proto.Chat;

namespace Chat.Client
{
    public partial class ChatForm : Form
    {
        private IConnectionFactory ConnectionFactory { get; }
        private ChatService.ChatServiceClient MessageListner { get; set; }
        private string UserName { get; set; }

        public ChatForm(IConnectionFactory connectionFactory)
        {
            ConnectionFactory = connectionFactory;
            InitializeComponent();
            
            //Input user name
            UserName = NameInput.InputUserName();

            //Running a task that listens for new messages 
            Task.Run(async () =>
            {
                MessageListner = ConnectionFactory.CreateClient();

                var response = MessageListner.ConnectToChat(new ConnectMessage() { UserName = UserName });
                await foreach (var item in response.ResponseStream.ReadAllAsync())
                {
                    //delegate execution to a ui thread
                    Invoke((Action)(() => OnAddMessage($"{item.UserName}: {item.Message} \n")));
                }
            });

        }
        
        /// <summary>
        /// Add message to a ChatBox
        /// </summary>
        /// <param name="message"></param>
        private void OnAddMessage(string message)
        {
            ChatMessageBox.Text += message;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            //Creating client 
            var client = ConnectionFactory.CreateClient();

            //Send message to the server
            client.SendMessage(new ChatMessage()
            {
                Message = MessageBox.Text,
                UserName = UserName
            });

            //Clear input 
            MessageBox.Text = "";
        }
    }
}
