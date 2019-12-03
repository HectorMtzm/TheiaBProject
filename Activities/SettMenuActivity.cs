using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using TheiaBProjectv2.Fragments;

namespace TheiaBProjectv2.Activities
{
    [Activity(Label = "Settings")]
    public class SettMenuActivity : AppCompatActivity
    {
        Button bemer, permissions;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.settings_menu_layout);

            // Create your application here

            bemer = FindViewById<Button>(Resource.Id.bemer);
            permissions = FindViewById<Button>(Resource.Id.bper);

            bemer.Click += Bemer_Click;
            permissions.Click += permissions_Click;
        }

        private void permissions_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(PermissionsActivity));
            StartActivity(intent);
        }

        private void Bemer_Click(object sender, EventArgs e)
        {
            EmergencyContactFragment addECFragment = new EmergencyContactFragment();
            var trans = SupportFragmentManager.BeginTransaction();
            addECFragment.Cancelable = false;
            addECFragment.Show(trans, "Finish");
        }

    }
}