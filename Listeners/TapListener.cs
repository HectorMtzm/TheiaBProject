using System;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace TheiaBProjectv2
{
    internal class TapListener : GestureDetector.SimpleOnGestureListener
    {
        private Context context;

        public TapListener(Context context)
        {
            this.context = context;
        }


        public override bool OnDown(MotionEvent e)
        {
            return true;
        }

        public override bool OnDoubleTap(MotionEvent e)
        {
            return true;
        }
        public override void OnLongPress(MotionEvent e)
        {
            MakePhoneCall("2144917399");
        }

        public void MakePhoneCall(string number)
        {
            var intent = new Intent(Intent.ActionCall, Android.Net.Uri.Parse("tel:" + Uri.EscapeDataString(number)));
            intent.AddFlags(ActivityFlags.NewTask);
            Android.App.Application.Context.StartActivity(intent);
        }
    }
}
    
