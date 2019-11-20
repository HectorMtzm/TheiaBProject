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
    }
}
    
