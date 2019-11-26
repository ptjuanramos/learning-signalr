using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinLearningSignalR.Activities
{
    public partial class MainActivity
    {
        private TextView userNameTextView;
        public TextView UserNameTextView
        {
            get
            {
                return userNameTextView 
                    ?? (userNameTextView = FindViewById<TextView>(Resource.Id.usernameEditText));
            }
        }

        private Button connectToChatButton;
        public Button ConnectToChatButton
        {
            get
            {
                return connectToChatButton
                    ?? (connectToChatButton = FindViewById<Button>(Resource.Id.connectToChatButton));
            }
        }

        private Button connectToDrawButton;
        public Button ConnectToDrawButton
        {
            get
            {
                return connectToDrawButton
                    ?? (connectToDrawButton = FindViewById<Button>(Resource.Id.connectToDrawButton));
            }
        }
    }
}