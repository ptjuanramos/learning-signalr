using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinLearningSignalR.Models;
using XamarinLearningSignalR.Services.Interfaces;

namespace XamarinLearningSignalR.Services
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