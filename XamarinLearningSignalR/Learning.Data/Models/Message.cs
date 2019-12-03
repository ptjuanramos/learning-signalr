using System;
using SQLite;

namespace XamarinLearningSignalR.Data.Models
{
    [Table("messages")]
    public class Message
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public Guid Id{ get; set; }

        //[Column("channel_id"), NotNull, Unique, Indexed]
        //public string ChannelId { get; set; }

        [Column("from_user"), NotNull]
        public string FromUser { get; set; }

        [Column("to_user"), NotNull]
        public string ToUser { get; set; }

        [Column("message_type"), NotNull]
        public MessageType MessageType { get; set; }

        //[Column("date_time"), Default(value: null)]
        //public DateTime MessageDateTime { get; set; }

        public byte[] data { get; set; }
    }

    public enum MessageType
    {
        CHAT_MESSAGE,
        DRAW
    }
}