using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Widget;
using TheiaBProjectv2.Helpers;
using Android.Content;

namespace TheiaBProjectv2
{
    [Activity(Label = "Activity1", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
        private Android.Hardware.Camera camera;
        private ISurfaceHolder mHolder;
        private SurfaceView cameraSurfaceView;
        private AutoCompleteTextView searchACTextView;
        private GestureDetector.IOnDoubleTapListener _tapDetector;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            if (LogInActivity.instance != null)
            {
                try
                {
                    LogInActivity.instance.Finish();
                }
                catch (Exception e) { }
            }
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main_camera_layout);

            searchACTextView = FindViewById<AutoCompleteTextView>(Resource.Id.searchACTextView);
            cameraSurfaceView = FindViewById<SurfaceView>(Resource.Id.cameraSurfaceView);

            //Autocomplete editbar
            var adapter = new ArrayAdapter<String>(this, Resource.Layout.list_item, Rooms.rooms);
            searchACTextView.Adapter = adapter;

            //Double tap detector
            GestureDetector _tapDetector = new GestureDetector(this, new TapListener(this));
            _tapDetector.DoubleTap += (object sender, GestureDetector.DoubleTapEventArgs e) =>
            {
                StartActivity(new Intent(this, typeof(SettMenuActivity)));
            };

            cameraSurfaceView.Touch += (object sender, View.TouchEventArgs e) => {
                _tapDetector.OnTouchEvent(e.Event);
            };

        }


    }
}