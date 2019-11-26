using System;

using Android.App;
using Android.Content;
using Android.Views;

namespace TheiaBProjectv2.Listeners
{
    class LoginGestureListener : Java.Lang.Object, GestureDetector.IOnGestureListener
    {
        private Context context;
        private Activity activity;

        public LoginGestureListener(Context context, Activity activity)
        {
            this.context = context;
            this.activity = activity;
        }

        private void UpSwipeActions()
        {
            Intent intent = new Intent(context, typeof(SignIn));
            context.StartActivity(intent);
            activity.OverridePendingTransition(Resource.Animation.abc_slide_in_bottom, Resource.Animation.abc_slide_in_bottom);
        }

        private void DownSwipeActions()
        {
            Intent intent = new Intent(context, typeof(SignUp));
            context.StartActivity(intent);
            activity.OverridePendingTransition(Resource.Animation.abc_slide_in_top, Resource.Animation.abc_slide_out_bottom);
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
            float distanceY = e2.GetY() - e1.GetY();
            //float distanceX = e2.GetX() - e1.GetX();

            // Is it horizontal?
            if (Math.Abs(velocityY) >= 2.0 * Math.Abs(velocityX))
            {
                if (distanceY > 0.0)
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