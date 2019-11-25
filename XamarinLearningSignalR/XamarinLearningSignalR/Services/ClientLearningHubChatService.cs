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
using Microsoft.AspNetCore.SignalR.Client;

namespace XamarinLearningSignalR.Services
{
    public class ClientLearningHubChatService
    {
        private static ClientLearningHubChatService _clientLearningHubChatServiceInstance;
        public static ClientLearningHubChatService Instance
        {
            get
            {
                if(_clientLearningHubChatServiceInstance == null)
                {
                    _clientLearningHubChatServiceInstance = new ClientLearningHubChatService();
                }

                return _clientLearningHubChatServiceInstance;
            }
        }

        private readonly HubConnection hubConnection;
        private ClientLearningHubChatService()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl("http://10.1.99.10/SignalRNotificationHub/chatHub")
                .Build();
        }

        public async Task Connect()
        {
            await hubConnection.StartAsync();
        }

        public async Task Disconnect()
        {
            await hubConnection.StopAsync();
        }

        public async Task SendMessage(string user, string message)
        {
            await hubConnection.InvokeAsync("SendMessage", user, message);
        }

        public void ReceiveMessage(Action<String, String> receiveMessageCallBack)
        {
            hubConnection.On<String, String>("SomethingAwesome", (username, message) => {
                receiveMessageCallBack.Invoke(username, message);
            });
        }
    }
}