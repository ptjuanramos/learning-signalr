using System;
using System.IO;

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