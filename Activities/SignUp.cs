using System;

using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using TheiaBProjectv2.Fragments;
using System.Data;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using TheiaBProjectv2.HttpRequests;

namespace TheiaBProjectv2
{
    [Activity(Label = "Sign Up", Theme = "@style/AppTheme.NoActionBar")]
    public class SignUp : AppCompatActivity
    {
        private EditText firstname, lastname, username, password, email, passwordConfrimation, phoneNumber, emergencyContact;
        private Button completeButton;

        private Request request = new Request();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.sign_up_layout);

            firstname = FindViewById<EditText>(Resource.Id.firstNameEditText);
            lastname = FindViewById<EditText>(Resource.Id.lastNameEditText);
            username = FindViewById<EditText>(Resource.Id.username);
            email = FindViewById<EditText>(Resource.Id.email);
            password = FindViewById<EditText>(Resource.Id.password);
            passwordConfrimation = FindViewById<EditText>(Resource.Id.passwordConfirmation);
            phoneNumber = FindViewById<EditText>(Resource.Id.phoneNumberEditText);
            emergencyContact = FindViewById<EditText>(Resource.Id.EmergencyContactEditText);
            completeButton = FindViewById<Button>(Resource.Id.completeButton);

            completeButton.Click += CompleteButton_Click;
        }

        private void userCreatedFragment()
        {
            AlertFragment userCreatedFragment = new AlertFragment("User Created successfuly", 1);
            var trans = SupportFragmentManager.BeginTransaction();
            userCreatedFragment.Cancelable = false;
            userCreatedFragment.Show(trans, "Finish");
            userCreatedFragment.finish += Fragment_finish;
        }

        private void emailTakenFragment()
        {
            AlertFragment userCreatedFragment = new AlertFragment("Email has already been taken", 3);
            var trans = SupportFragmentManager.BeginTransaction();
            userCreatedFragment.Cancelable = false;
            userCreatedFragment.Show(trans, "Finish");
        }

        private void Fragment_finish(object sender, EventArgs e)
        {
            this.Finish();
            this.OverridePendingTransition(Resource.Animation.abc_slide_in_bottom, Resource.Animation.abc_slide_out_bottom);
        }

        private async void CompleteButton_Click(object sender, EventArgs e)
        {
       
            var keys = await request.signup(firstname.Text, lastname.Text, username.Text, email.Text, password.Text, phoneNumber.Text, emergencyContact.Text);

            if (keys["success"] == 1 && keys["responseCode"] == 201)
                userCreatedFragment();
            else if (keys["responseCode"] == 400)
                emailTakenFragment();
            else
            {
                AlertFragment userCreatedFragment = new AlertFragment(keys["message"], 3);
                var trans = SupportFragmentManager.BeginTransaction();
                userCreatedFragment.Cancelable = false;
                userCreatedFragment.Show(trans, "Finish");
                userCreatedFragment.finish += Fragment_finish;
            }
        }

        public override void OnBackPressed()
        {
            this.Finish();
            this.OverridePendingTransition(Resource.Animation.abc_slide_in_bottom, Resource.Animation.abc_slide_out_bottom);
        }
    }

}
