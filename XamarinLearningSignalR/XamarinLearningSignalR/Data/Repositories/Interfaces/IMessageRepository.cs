using System.Collections.Generic;
using XamarinLearningSignalR.Data.Models;

namespace XamarinLearningSignalR.Data.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        int Insert(Message message);
        int Update(Message message);
        int Delete(Message message);
        List<Message> GetAll();
        List<Message> GetChannelMessages(string channel);
    }
}