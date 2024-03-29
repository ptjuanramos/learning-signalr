﻿using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Learning.Core.Services
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

        public bool IsConnected
        {
            get
            {
                return hubConnection.State == HubConnectionState.Connected;
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

        public async Task SendDraw(string username, byte[] drawAsByteArray)
        {
            await hubConnection.InvokeAsync("SendDraw", username, drawAsByteArray);
        }

        public void ReceiveDraw(Action<String, byte[]> receiveDrawCallBack)
        {
            hubConnection.On<String, byte[]>("NewDraw", (username, drawAsByteArray) => {
                receiveDrawCallBack.Invoke(username, drawAsByteArray);
            });
        }

        public void ReceiveMessage(Action<String, String> receiveMessageCallBack)
        {
            hubConnection.On<String, String>("SomethingAwesome", (username, message) => {
                receiveMessageCallBack.Invoke(username, message);
            });
        }
    }
}