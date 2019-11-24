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

namespace TheiaBProjectv2
{
    [Activity(Label = "", Theme = "@style/AppTheme.NoActionBar", NoHistory = true)]
    public class SignIn : AppCompatActivity
    {

        Button signinButton, createAccountButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.sign_in_layout);

            signinButton = FindViewById<Button>(Resource.Id.signinButton);
            createAccountButton = FindViewById<Button>(Resource.Id.createAccountButton);

            signinButton.Click += signinButton_Click;
            createAccountButton.Click += CreateAccountButton_Click;


        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(Application.Context, typeof(SignUp)));
            this.OverridePendingTransition(Resource.Animation.abc_slide_in_top, Resource.Animation.abc_slide_out_bottom);

        }

        private void signinButton_Click(object sender, EventArgs e)
        {
            this.Finish();
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }

        public override void OnBackPressed()
        {
            this.Finish();
            this.OverridePendingTransition(Resource.Animation.abc_slide_in_top, Resource.Animation.abc_slide_out_bottom);
        }
    }
}