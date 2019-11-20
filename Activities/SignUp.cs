using System;
using System.Collections.Generic;
using System.Linq;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using TheiaBProjectv2.Resources.Fragments;

namespace TheiaBProjectv2
{
    [Activity(Label = "Sign Up")]
    public class SignUp : AppCompatActivity
    {
        EditText firstname, lastname, username, password, passwordConfrimation;
        Button completeButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.sign_up_layout);

            firstname = FindViewById<EditText>(Resource.Id.firstNameEditText);
            lastname = FindViewById<EditText>(Resource.Id.lastNameEditText);
            username = FindViewById<EditText>(Resource.Id.username);
            password = FindViewById<EditText>(Resource.Id.password);
            passwordConfrimation = FindViewById<EditText>(Resource.Id.passwordConfirmation);
            completeButton = FindViewById<Button>(Resource.Id.completeButton);

            //Account account = new Account();

            completeButton.Click += CompleteButton_Click;

        }

        void userCreatedFragment()
        {
            UserCreatedFragment userCreatedFragment = new UserCreatedFragment();
            var trans = SupportFragmentManager.BeginTransaction();
            userCreatedFragment.Cancelable = false;
            userCreatedFragment.Show(trans, "Finish");
            userCreatedFragment.finish += UserCreatedFragment_finish; ;
        }

        private void UserCreatedFragment_finish(object sender, EventArgs e)
        {
            this.Finish();
        }

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            userCreatedFragment();

        }
    }

}