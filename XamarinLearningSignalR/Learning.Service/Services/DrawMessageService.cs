using Learning.Core.Models;
using Learning.Core.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Learning.Core.Services
{
    public class DrawMessageService : IMessageService<DrawMessage>
    {
        private readonly ClientLearningHubChatService clientLearningHubChatService;
        public DrawMessageService(ClientLearningHubChatService clientLearningHubChatService)
        {
            this.clientLearningHubChatService = clientLearningHubChatService;
        }

        public void ReceiveMessage(Action<DrawMessage> receiveMessageCallback)
        {
            clientLearningHubChatService.ReceiveDraw((username, receivedDraw) =>
            {
                DrawMessage drawMessage = new DrawMessage()
                {
                    Content = receivedDraw,
                    FromUser = username
                };

                receiveMessageCallback.Invoke(drawMessage);
            });
        }

        public async Task<ServiceResult<DrawMessage>> SendMessage(DrawMessage content)
        {
            ServiceResult<DrawMessage> result = new ServiceResult<DrawMessage>(); //TODO - doesnt't actual return anything
            await clientLearningHubChatService.SendDraw(content.FromUser, content.Content);
            return result;
        }
    }
}