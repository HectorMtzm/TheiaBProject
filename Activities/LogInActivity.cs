using Android.App;
using Android.OS;
using Android.Views;
using TheiaBProjectv2.Listeners;
using Android.Widget;
using Android.Content.PM;
using Android.Support.V4.Content;
using Android;
using Android.Support.V4.App;
using System;

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
            
            reqPermissions();

            _gestureDetector = new GestureDetector(this, new LoginGestureListener(this, this));
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

        private void reqPermissions()
        {
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.CallPhone) != (int)Permission.Granted)
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.CallPhone, Manifest.Permission.Camera, 
                    Manifest.Permission.AccessFineLocation, Manifest.Permission.AccessCoarseLocation, Manifest.Permission.ReadContacts,
                    Manifest.Permission.SendSms}, 1);
        }
    }
}