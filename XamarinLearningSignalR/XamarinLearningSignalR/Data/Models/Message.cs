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
using SQLite;

namespace XamarinLearningSignalR.Data.Models
{
    [Table("messages")]
    public class Message
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public Guid Id{ get; set; }

        //[Column("channel_id"), NotNull, Unique]
        //public string ChannelId { get; set; }

        [Column("from_user"), NotNull]
        public string FromUser { get; set; }

        [Column("to_user"), NotNull]
        public string ToUser { get; set; }

        [Column("message_type"), NotNull]
        public MessageType MessageType { get; set; }

        public byte[] data { get; set; }
    }
}