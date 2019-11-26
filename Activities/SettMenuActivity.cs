using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace TheiaBProjectv2.Activities
{
    [Activity(Label = "Settings")]
    public class SettMenuActivity : AppCompatActivity
    {
        ImageButton bemer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.settings_menu_layout);

            // Create your application here

            bemer = FindViewById<ImageButton>(Resource.Id.bemer);

            bemer.Click += Bemer_Click;
        }

        private void Bemer_Click(object sender, EventArgs e)
        {
            //Intent intent = new Intent(this, typeof(AccelerometerTest));
            //StartActivity(intent);

        }
    }
}