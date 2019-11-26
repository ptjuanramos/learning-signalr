using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace HubSignalRLearning.Services
{
    public class LearningHubService : Hub
    {
        public async Task SendMessage(String user, String message)
        {
            await Clients.All.SendAsync("SomethingAwesome", user, message);
        }

        public async Task SendDraw(string username, byte[] drawObjectAsByteArray)
        {
            await Clients.All.SendAsync("NewDraw", username, drawObjectAsByteArray);
        }
    }
}
