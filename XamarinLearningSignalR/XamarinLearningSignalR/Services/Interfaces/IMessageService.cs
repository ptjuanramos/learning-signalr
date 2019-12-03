using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinLearningSignalR.Services.Interfaces
{
    public interface IMessageService<T>
    {
        Task<ServiceResult<T>> SendMessage(T content);
        void ReceiveMessage(Action<T> receiveMessageCallback);
    }
}