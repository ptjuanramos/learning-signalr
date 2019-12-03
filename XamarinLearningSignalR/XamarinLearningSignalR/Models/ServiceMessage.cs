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

namespace XamarinLearningSignalR.Models
{
    public class ServiceMessage<T>
    {
        public string FromUser { get; set; }
        public string ToUser{ get; set; }
        public T Content { get; set; }
    }
}