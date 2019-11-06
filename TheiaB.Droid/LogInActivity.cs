using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using System;
using Android.Content;
using Android.Support.V7.App;

namespace TheiaB.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/Sign_in_screen")]
    public class LogInActivity : AppCompatActivity, GestureDetector.IOnGestureListener
    {
        private GestureDetector _gestureDetector;
        const int SWIPE_DISTANCE_THRESHOLD = 10;
        const int SWIPE_VELOCITY_THRESHOLD = 10;

        //Button loginButton;
        //private EditText TextTest;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.log_in);

            _gestureDetector = new GestureDetector(this);

            //TextTest.SetText("salsa".ToCharArray(),0,5);
            //TextTest = FindViewById<EditText>(Resource.Id.TextTest);
            //loginButton = FindViewById<Button>(Resource.Id.loginButton);
            //loginButton.Click += LoginButton_Click;

        }

        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            //Toast.MakeText(this, $"Hello {userIdTextBox.Text}", ToastLength.Long).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        //Swipe controls
        public bool OnDown(MotionEvent e)
        {
            throw new System.NotImplementedException();
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            _gestureDetector.OnTouchEvent(e);
            return true;
        }


        public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
        {
            float distanceX = e2.GetX() - e1.GetX();
            float distanceY = e2.GetY() - e1.GetY();
            if (Math.Abs(distanceY) > Math.Abs(distanceX) && Math.Abs(distanceY) > SWIPE_DISTANCE_THRESHOLD && Math.Abs(velocityY) > SWIPE_VELOCITY_THRESHOLD)
            {
                
                if (distanceY > 0)
                    //Toast.MakeText(this, $"Total distance = {distanceY}", ToastLength.Long).Show();

                return true;
            }
            return false;
        }

        private void OnSwipeUp()
        {
            StartActivity(new Intent(Application.Context, typeof(SignIn)));
        }

        private void OnSwipeDown()
        {
            StartActivity(new Intent(Application.Context, typeof(SignUp)));
        }

        public void OnLongPress(MotionEvent e)
        {
            throw new System.NotImplementedException();
        }

        public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
        {
            throw new System.NotImplementedException();
        }

        public void OnShowPress(MotionEvent e)
        {
            throw new System.NotImplementedException();
        }

        public bool OnSingleTapUp(MotionEvent e)
        {
            throw new System.NotImplementedException();
        }
    }
}