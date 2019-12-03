using System;
using System.Threading.Tasks;
using XamarinLearningSignalR.Models;
using XamarinLearningSignalR.Services.Interfaces;

namespace XamarinLearningSignalR.Services
{
    public class ChatMessageService : IMessageService<ChatMessage>
    {
        private readonly ClientLearningHubChatService clientLearningHubChatService;

        public ChatMessageService(ClientLearningHubChatService clientLearningHubChatService)
        {
            this.clientLearningHubChatService = clientLearningHubChatService;
        }

        public void ReceiveMessage(Action<ChatMessage> receiveMessageCallback)
        {
            clientLearningHubChatService.ReceiveMessage((username, message) =>
            {
                ChatMessage chatMessage = new ChatMessage()
                {
                    Content = message,
                    FromUser = username
                };

                receiveMessageCallback.Invoke(chatMessage);
            });
        }

        public async Task<ServiceResult<ChatMessage>> SendMessage(ChatMessage content)
        {
            ServiceResult<ChatMessage> result = new ServiceResult<ChatMessage>(); //TODO doesnt return anything(no content)
            await clientLearningHubChatService.SendMessage(content.FromUser, content.Content);
            return result;
        }
    }
}