using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TheiaBProjectv2.Fragments
{
    public class EmergencyContactFragment : Android.Support.V4.App.DialogFragment
    {
        private TextView descriptionTextView;
        private EditText newECNumberEditText;
        private Button okECButton, cancelECButton;

        public event EventHandler finishEC;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.emergency_contact_layout, container, false);

            okECButton = view.FindViewById<Button>(Resource.Id.okECButton);
            cancelECButton = view.FindViewById<Button>(Resource.Id.cancelECButton);
            descriptionTextView = view.FindViewById<TextView>(Resource.Id.fragmentECDescriptionTextView);
            newECNumberEditText = view.FindViewById<EditText>(Resource.Id.newECNumberEditText);

            cancelECButton.Click += CancelECButton_Click;
            okECButton.Click += OkECButton_Click;
            return view;
        }

        private void CancelECButton_Click(object sender, EventArgs e)
        {
            this.Dismiss();
            finishEC?.Invoke(this, new EventArgs());
        }

        private void OkECButton_Click(object sender, EventArgs e)
        {
            MainActivity.account.emergencyContact = newECNumberEditText.Text;
            this.Dismiss();
            finishEC?.Invoke(this, new EventArgs());
        }


    }
}