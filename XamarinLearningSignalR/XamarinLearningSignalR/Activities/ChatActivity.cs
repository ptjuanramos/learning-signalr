using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using XamarinLearningSignalR.Adapters;
using XamarinLearningSignalR.Services;

namespace XamarinLearningSignalR.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public partial class ChatActivity : AppCompatActivity 
    {
        private string ourUsername;
        private ClientLearningHubChatService learningHubChatService;
        private ObservableCollection<String> chatMessages = new ObservableCollection<String>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_chat);
            
            PrepareRecyclerViewAdapter();

            ourUsername = this.Intent.GetStringExtra("usernameValue");
            learningHubChatService = ClientLearningHubChatService.Instance;
            ConnectToChatHub();

            learningHubChatService.ReceiveMessage(HandleReceiveMessage());

            SendButton.Click += SendButton_Click;
        }

        private void PrepareRecyclerViewAdapter() //TODO buscar lista de mensagens iniciais colocar no outro constructor
        {
            LinearLayoutManager linearLayoutManager = new LinearLayoutManager(this);
            linearLayoutManager.Orientation = LinearLayoutManager.Vertical;
            ChatList.SetLayoutManager(linearLayoutManager);

            ChatListAdapter chatListAdapter = new ChatListAdapter(chatMessages);
            ChatList.SetAdapter(chatListAdapter);
        }

        private Action<String, String> HandleReceiveMessage()
        {
            return (username, message) =>
            {
                if (username != ourUsername)
                {
                    string newMessageToSetOnAdapter = username + " -> " + message;
                    chatMessages.Add(newMessageToSetOnAdapter);
                    ChatList.GetAdapter().NotifyDataSetChanged();
                }
            };
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            string newTextMessage = NewMessageEditText.Text;
            if(!String.IsNullOrEmpty(newTextMessage))
            {
                await learningHubChatService.SendMessage(ourUsername, newTextMessage);
                string textMessageToAddOnAdapterList = ourUsername + "->" + newTextMessage;
                chatMessages.Add(textMessageToAddOnAdapterList);
                ChatList.GetAdapter().NotifyDataSetChanged();
            }
            
        }

        private async void ConnectToChatHub()
        {
            await learningHubChatService.Connect();
        }
    }
}