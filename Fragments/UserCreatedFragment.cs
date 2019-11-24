using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TheiaBProjectv2.Fragments
{
    public class UserCreatedFragment : Android.Support.V4.App.DialogFragment
    {
        Button okButton;

        public event EventHandler finish;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.user_added_layout, container, false);

            okButton = view.FindViewById<Button>(Resource.Id.okButton);

            okButton.Click += OkButton_Click;
            return view;

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Dismiss();
            finish?.Invoke(this, new EventArgs());
        }
    }
}