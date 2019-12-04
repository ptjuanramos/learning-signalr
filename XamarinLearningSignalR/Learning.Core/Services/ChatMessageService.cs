using Learning.Core.Models;
using Learning.Core.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Learning.Core.Services
{
    public class ChatMessageService : IChatMessageService
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