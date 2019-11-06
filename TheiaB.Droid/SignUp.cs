using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace TheiaB.Droid
{
    [Activity(Label = "SignUp")]
    public class SignUp : AppCompatActivity, GestureDetector.IOnGestureListener
    {
        private GestureDetector _gestureDetector;
        private TextView _textView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Sign_Up);

            // Create your application here

            _textView = FindViewById<TextView>(Resource.Id.velocity_text_view);
            _textView.Text = "Fling Velocity: ";

            _gestureDetector = new GestureDetector(this);
        }

        //controls
        public bool OnDown(MotionEvent e)
        {
            throw new NotImplementedException();
        }

        public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
        {
            _textView.Text = String.Format("Fling velocity: {0} x {1}", velocityX, velocityY);
            return false;
        }

        public void OnLongPress(MotionEvent e)
        {
            throw new NotImplementedException();
        }

        public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
        {
            throw new NotImplementedException();
        }

        public void OnShowPress(MotionEvent e)
        {
            throw new NotImplementedException();
        }

        public bool OnSingleTapUp(MotionEvent e)
        {
            throw new NotImplementedException();
        }

    }
}