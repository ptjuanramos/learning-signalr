using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using XamarinLearningSignalR.Helpers;
using XamarinLearningSignalR.Models;
using XamarinLearningSignalR.Services;

namespace XamarinLearningSignalR.Activities
{
    [Activity(Label = "DrawChatActivity")]
    public partial class DrawChatActivity : Activity
    {

        private string ourUsername;
        private ClientLearningHubChatService learningHubChatService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_draw_main);

            ourUsername = this.Intent.GetStringExtra("usernameValue");
            learningHubChatService = ClientLearningHubChatService.Instance;
            ConnectToChatHub();

            PrepareCanvas();

            learningHubChatService.ReceiveDraw(HandleReceiveDraw());
            SendDrawButton.Click += SendDrawButton_Click;
        }

        private async void SendDrawButton_Click(object sender, EventArgs e)
        {
            byte[] allPathsInByteArray = SerializablesHelper.ToByteArray<List<DrawPath>>(DrawCanvasWidget.DrawPaths);
            await learningHubChatService.SendDraw(ourUsername, allPathsInByteArray);
        }

        private Action<String, byte[]> HandleReceiveDraw()
        {
            return (username, drawAsByteArray) =>
            {
                ChangeLastDrawAuthor(username);
                if (username != ourUsername)
                {
                    List<DrawPath> receivedDraw = SerializablesHelper.FromByteArray<List<DrawPath>>(drawAsByteArray);
                    DrawCanvasWidget.MakeNewDraw(receivedDraw);
                }
            };
        }

        private void ChangeLastDrawAuthor(string username)
        {
            LastDrawUser.Text = $"Last draw by {username}";
        }

        private void PrepareCanvas()
        {
            DisplayMetrics displayMetrics = new DisplayMetrics();
            WindowManager.DefaultDisplay.GetMetrics(displayMetrics);
            DrawCanvasWidget.Initialize(displayMetrics);
        }

        private async void ConnectToChatHub()
        {
            if (!learningHubChatService.IsConnected)
            {
                await learningHubChatService.Connect();
            }
        }
    }
}