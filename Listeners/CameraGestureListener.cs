using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace TheiaBProjectv2.Listeners
{
    class CameraGestureListener : GestureDetector.SimpleOnGestureListener
    {
        private Activity activity;

        public CameraGestureListener(Activity activity)
        {
            this.activity = activity;
        }

        public override bool OnDown(MotionEvent e)
        {
            return true;
        }

        public override bool OnDoubleTap(MotionEvent e)
        {
            activity.FindViewById<ImageButton>(Resource.Id.micButton).PerformClick();
            return true;
        }

        public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
        {
            bool usedThisFling = false;
            float distanceY = e2.GetY() - e1.GetY();
            //float distanceX = e2.GetX() - e1.GetX();

            // Is it horizontal?
            if (Math.Abs(velocityY) >= 2.0 * Math.Abs(velocityX))
            {
                if (distanceY > 300.0)
                    sendLocation();
                usedThisFling = true;
            }
            return usedThisFling;
        }

        public override void OnLongPress(MotionEvent e)
        {
            MakePhoneCall("2144917399");
        }



        private async System.Threading.Tasks.Task sendLocation()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Best);
            var location = await Geolocation.GetLocationAsync(request);
            string message = "I got lost around here: http://www.google.com/maps/place/" + location.Latitude + "," + location.Longitude;
            SmsManager.Default.SendTextMessage("2144917399", null, message, null, null);

            //Play audio for "Location sent"}
        }

        public void MakePhoneCall(string number)
        {
            var intent = new Intent(Intent.ActionCall, Android.Net.Uri.Parse("tel:" + Uri.EscapeDataString(number)));
            intent.AddFlags(ActivityFlags.NewTask);
            Android.App.Application.Context.StartActivity(intent);
        }
    }
}