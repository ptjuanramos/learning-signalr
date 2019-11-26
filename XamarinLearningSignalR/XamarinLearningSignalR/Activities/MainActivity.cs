using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace XamarinLearningSignalR.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public partial class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            ConnectToChatButton.Click += ConnectToChatButton_Click;
            ConnectToDrawButton.Click += ConnectToDrawButton_Click;
        }

        private bool ValidateUsername(string username)
        {
            if(String.IsNullOrEmpty(username))
            {
                Toast.MakeText(this, "Please provide a username", ToastLength.Short).Show();
                return false;
            }

            return true;
        }

        private void ConnectToChatButton_Click(object sender, EventArgs e)
        {
            string username = UserNameTextView.Text;
            if(ValidateUsername(username))
            {
                Intent chatActivityIntent = new Intent(this, typeof(ChatActivity));
                chatActivityIntent.PutExtra("usernameValue", username);
                StartActivity(chatActivityIntent);
            }
        }

        private void ConnectToDrawButton_Click(object sender, EventArgs e)
        {
            string username = UserNameTextView.Text;
            if (ValidateUsername(username))
            {
                Intent drawChatActivityIntent = new Intent(this, typeof(DrawChatActivity));
                drawChatActivityIntent.PutExtra("usernameValue", username);
                StartActivity(drawChatActivityIntent);
            }
        }
    }
}

