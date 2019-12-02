using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinLearningSignalR.Data
{
    public class DataConstants
    {

        public readonly static String SQL_LITE_DB_PATH = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Personal),
            "chat_database"
        );
    }
}