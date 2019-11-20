using Android.App;
using Android.OS;
using Android.Views;
using TheiaBProjectv2.Listeners;
using Android.Widget;
using Android.Content.PM;

namespace TheiaBProjectv2
{
    [Activity(Label = "@string/app_name", Theme = "@style/Sign_in_screen", LaunchMode = LaunchMode.SingleInstance)]
    public class LogInActivity : Activity
    {
        private GestureDetector _gestureDetector;

        public static LogInActivity instance = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            instance = this;
            SetContentView(Resource.Layout.login_layout);
                                  
            _gestureDetector = new GestureDetector(this, new GestureListener(this));

        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            return _gestureDetector.OnTouchEvent(e);
        }

        public override void Finish()
        {
            base.Finish();
            instance = null;
        }
    }
}