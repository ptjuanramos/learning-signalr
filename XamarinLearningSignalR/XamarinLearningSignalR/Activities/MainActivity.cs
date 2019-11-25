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

            ConnectButton.Click += ConnectButton_Click;
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            string username = UserNameTextView.Text;
            if(String.IsNullOrEmpty(username))
            {
                Toast.MakeText(this, "Please provide a username", ToastLength.Short).Show();
            } else
            {
                Intent chatActivityIntent = new Intent(this, typeof(ChatActivity));
                chatActivityIntent.PutExtra("usernameValue", username);
                StartActivity(chatActivityIntent);
            }
        }
	}
}

