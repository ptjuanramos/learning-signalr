using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace XamarinLearningSignalR.Activities
{
    public partial class ChatActivity
    {
        private RecyclerView chatList;
        public RecyclerView ChatList
        {
            get
            {
                return chatList ?? (chatList = FindViewById<RecyclerView>(Resource.Id.chatRecyclerView));
            }
        }

        private Button sendButton;
        public Button SendButton
        {
            get
            {
                return sendButton ?? (sendButton = FindViewById<Button>(Resource.Id.sendButton));
            }
        }

        private EditText newMessageEditText;
        public EditText NewMessageEditText
        {
            get
            {
                return newMessageEditText ?? (newMessageEditText = FindViewById<EditText>(Resource.Id.messageText));
            }
        }
    }
}