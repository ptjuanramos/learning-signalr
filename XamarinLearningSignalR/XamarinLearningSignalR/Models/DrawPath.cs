using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinLearningSignalR.Models
{
    [Serializable]
    public class DrawPath
    {
        public int Color;

        public SerializablePath Path;

        public DrawPath(int color, SerializablePath path)
        {
            Color = color;
            Path = path;
        }
    }
}