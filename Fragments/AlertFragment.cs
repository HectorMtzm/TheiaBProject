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
    public class AlertFragment : Android.Support.V4.App.DialogFragment
    {
        Button okButton;
        View statusView;
        TextView descriptionTextView;

        public event EventHandler finish;

        private string text;
        private int status;

        public AlertFragment(string text, int status)
        {
            this.text = text;
            this.status = status;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.alert_fragment, container, false);

            okButton = view.FindViewById<Button>(Resource.Id.okButton);
            statusView = view.FindViewById<View>(Resource.Id.statusView);
            descriptionTextView = view.FindViewById<TextView>(Resource.Id.fragmentDescriptionTextView);

            descriptionTextView.Text = text;

            switch (status)
            {
                //account created
                case 1:
                    statusView.SetBackgroundResource(Resource.Drawable.personadd);
                    break;
                
                //negative
                case 2:
                    statusView.SetBackgroundResource(Resource.Drawable.bad);
                    break;
                
                //Alert
                case 3:
                    statusView.SetBackgroundResource(Resource.Drawable.alert);
                    break;

            }

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