using Learning.Core.Models;
using System;
using System.Threading.Tasks;

namespace Learning.Core.Services.Interfaces
{
    public interface IMessageService<T>
    {
        Task<ServiceResult<T>> SendMessage(T content);
        void ReceiveMessage(Action<T> receiveMessageCallback);
    }
}