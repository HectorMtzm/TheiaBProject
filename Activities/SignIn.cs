using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Newtonsoft.Json;
using TheiaBProjectv2.DataModels;
using TheiaBProjectv2.Fragments;
using TheiaBProjectv2.HttpRequests;

namespace TheiaBProjectv2
{
    [Activity(Label = "Sign in", Theme = "@style/AppTheme.NoActionBar", NoHistory = true)]
    public class SignIn : AppCompatActivity
    {
        private Button signinButton, createAccountButton;
        private EditText emailEditText, passwordEditText;
        private Account account;
        private Request request = new Request();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.sign_in_layout);

            signinButton = FindViewById<Button>(Resource.Id.signinButton);
            createAccountButton = FindViewById<Button>(Resource.Id.createAccountButton);
            emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);

            signinButton.Click += signinButton_Click;
            createAccountButton.Click += CreateAccountButton_Click;

        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(Application.Context, typeof(SignUp)));
            this.OverridePendingTransition(Resource.Animation.abc_slide_in_top, Resource.Animation.abc_slide_out_bottom);

        }

        private async void signinButton_Click(object sender, EventArgs e)
        {
            var keys = await request.login(emailEditText.Text, passwordEditText.Text);

            if(keys["success"] == 1 && keys["responseCode"] == 200)
            {
                account = await request.GetAccountDetails(emailEditText.Text);
                this.Finish();
                var intent = new Intent(Application.Context, typeof(MainActivity));
                intent.PutExtra("account", JsonConvert.SerializeObject(account));

                this.StartActivity(intent);
            }
            else if (keys["responseCode"] == 401 || keys["responseCode"] == 402)
            {
                notMatchingFragment();
            }
        }

        private void notMatchingFragment()
        {
            AlertFragment userCreatedFragment = new AlertFragment("The email and password you entered did not match our records", 2);
            var trans = SupportFragmentManager.BeginTransaction();
            userCreatedFragment.Cancelable = false;
            userCreatedFragment.Show(trans, "Finish");
        }

        public override void OnBackPressed()
        {
            this.Finish();
            this.OverridePendingTransition(Resource.Animation.abc_slide_in_top, Resource.Animation.abc_slide_out_bottom);
        }
    }
}