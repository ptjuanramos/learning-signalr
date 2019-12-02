using System;
using System.Collections.Generic;
using SQLite;
using XamarinLearningSignalR.Data.Repositories.Interfaces;
using XamarinLearningSignalR.Data.Models;

namespace XamarinLearningSignalR.Data.Repositories
{
    public class MessageRepository : IMessageRepository, IDisposable
    {
        private readonly SQLiteConnection sqlLiteConnection;

        public MessageRepository()
        {
            sqlLiteConnection = new SQLiteConnection(DataConstants.SQL_LITE_DB_PATH);
        }

        public int Delete(Message message) => sqlLiteConnection.Delete<Message>(message);

        public int Insert(Message message) => sqlLiteConnection.Insert(message);

        public int Update(Message message) => sqlLiteConnection.Update(message);

        public List<Message> GetAll() => sqlLiteConnection.Table<Message>().ToList();

        //public List<Message> GetChannelMessages(string channelId) => sqlLiteConnection.Table<Message>().Where(m => m.ChannelId.Equals(channelId)).ToList();

        public void Dispose()
        {
            if(sqlLiteConnection != null)
                sqlLiteConnection.Close();
        }
    }
}