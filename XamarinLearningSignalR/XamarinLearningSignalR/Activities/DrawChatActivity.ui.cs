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
using XamarinLearningSignalR.Widgets;

namespace XamarinLearningSignalR.Activities
{
    public partial class DrawChatActivity
    {

        private DrawCanvas drawCanvasWidget;
        public DrawCanvas DrawCanvasWidget
        {
            get
            {
                return drawCanvasWidget
                    ?? (drawCanvasWidget = FindViewById<DrawCanvas>(Resource.Id.drawCanvas));
            }
        }

        private Button sendDrawButton;
        public Button SendDrawButton
        {
            get
            {
                return sendDrawButton
                    ?? (sendDrawButton = FindViewById<Button>(Resource.Id.sendDrawButton));
            }
        }
    }
}