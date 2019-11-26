using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace XamarinLearningSignalR.Adapters
{

    #region ViewHolder
    public class ChatListViewHolder : RecyclerView.ViewHolder
    {
        private TextView messageTextView;
        public TextView MessageTextView
        {
            get
            {
                return messageTextView;
            }
        }

        public ChatListViewHolder(View messageView) : base(messageView) {
            this.messageTextView = messageView.FindViewById<TextView>(Resource.Id.chatItemTextView);
        }
    }
    #endregion

    #region Adapter
    public class ChatListAdapter : RecyclerView.Adapter
    {
        private ObservableCollection<String> chatMessages;
        public ObservableCollection<String> ChatMessages
        {
            get
            {
                return chatMessages;
            }
        }

        public ChatListAdapter(ObservableCollection<String> chatMessages)
        {
            this.chatMessages = chatMessages;
        }

        public override int ItemCount => chatMessages.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            string messageToSet = chatMessages[position];
            ChatListViewHolder holderCastedAsMineViewHolder= (ChatListViewHolder)holder;
            holderCastedAsMineViewHolder.MessageTextView.Text = messageToSet;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.chat_message_item, parent, false);
            ChatListViewHolder viewHolder = new ChatListViewHolder(itemView);
            return viewHolder;
        }
    }
    #endregion
}