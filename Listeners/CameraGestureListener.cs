using System;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Media;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace TheiaBProjectv2.Listeners
{
    class CameraGestureListener : GestureDetector.SimpleOnGestureListener
    {
        private Activity activity;
        private Context context;

        MediaPlayer locationSent, emergencyCall; 
        //MainActivity

        public CameraGestureListener(Activity activity, Context context)
        {
            this.activity = activity;
            this.context = context;
            locationSent = MediaPlayer.Create(context, Resource.Raw.locationSent);
            emergencyCall = MediaPlayer.Create(context, Resource.Raw.callingEmergencyContact);
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

            // Is it Vertical?
            if (Math.Abs(velocityY) >= 2.0 * Math.Abs(velocityX))
            {
                if (distanceY > 300.0)
                    sendLocation(MainActivity.account.emergencyContact, true);
                usedThisFling = true;
            }
            return usedThisFling;
        }

        public override void OnLongPress(MotionEvent e)
        {
            MakePhoneCall(MainActivity.account.emergencyContact, true);
        }



        public async System.Threading.Tasks.Task sendLocation(string number, bool playAudio)
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Best);
            var location = await Geolocation.GetLocationAsync(request);
            string message = "I got lost around here: http://www.google.com/maps/place/" + location.Latitude + "," + location.Longitude;
            SmsManager.Default.SendTextMessage(number, null, message, null, null);
            if(playAudio)
                locationSent.Start();
        }

        public void MakePhoneCall(string number, bool playAudio)
        {
            if (playAudio)
            {
                emergencyCall.Start();
                Thread.Sleep(1500);
            }
            var intent = new Intent(Intent.ActionCall, Android.Net.Uri.Parse("tel:" + Uri.EscapeDataString(number)));
            intent.AddFlags(ActivityFlags.NewTask);
            Android.App.Application.Context.StartActivity(intent);
        }
    }
}