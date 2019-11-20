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

namespace TheiaBProjectv2.Listeners
{
    class GestureListener : Java.Lang.Object, GestureDetector.IOnGestureListener
    {
        private Context context;

        public GestureListener(Context context)
        {
            this.context = context;
        }


        private void UpSwipeActions()
        {
            Intent intent = new Intent(context, typeof(SignIn));
            context.StartActivity(intent);
        }

        private void DownSwipeActions()
        {
            Intent intent = new Intent(context, typeof(SignUp));
            context.StartActivity(intent);
        }


  

        public void Dispose()
        {
            
        }

        public bool OnDown(MotionEvent e)
        {
            return true;
        }

        public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
        {
            bool usedThisFling = false;

            // Is it horizontal?
            if (Math.Abs(velocityY) >= 2.0 * Math.Abs(velocityX))
            {
                if (velocityY < 0.0)
                    DownSwipeActions();
                else
                    UpSwipeActions();
                usedThisFling = true;
            }
            return usedThisFling;
        }

        public void OnLongPress(MotionEvent e)
        {
        }

        public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
        {
            return false;
        }

        public void OnShowPress(MotionEvent e)
        {
        }

        public bool OnSingleTapUp(MotionEvent e)
        {
            return false;
        }
    }
}


//public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
//{
//    bool usedThisFling = false;

//    // Is it horizontal?
//    if (Math.Abs(velocityY) >= 2.0 * Math.Abs(velocityX))
//    {
//        if (velocityY < 0.0)
//            DownSwipeActions();
//        else
//            UpSwipeActions();
//        usedThisFling = true;
//    }
//    return usedThisFling;
//}

//private void UpSwipeActions()
//{
//    Intent intent = new Intent(this, typeof(SignIn));
//    StartActivity(intent);
//}

//private void DownSwipeActions()
//{
//    Intent intent = new Intent(this, typeof(SignUp));
//    StartActivity(intent);
//}