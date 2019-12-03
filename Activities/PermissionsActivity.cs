using System;
using Android;
using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Widget;
using System.Threading;
using System.Threading.Tasks;

namespace TheiaBProjectv2.Activities
{
    [Activity(Label = "Settings")]
    public class PermissionsActivity : AppCompatActivity
    {
        private Button telephoneButton, locationButton, cameraButton, SMSButton, contactsButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.permissions_layout);

            telephoneButton = FindViewById<Button>(Resource.Id.telephoneButton);
            locationButton = FindViewById<Button>(Resource.Id.locationButton);
            cameraButton = FindViewById<Button>(Resource.Id.cameraButton);
            SMSButton = FindViewById<Button>(Resource.Id.SMSButon);
            contactsButton = FindViewById<Button>(Resource.Id.contactsButton);

            setColors();

            telephoneButton.Click += TelephoneButton_Click;
            locationButton.Click += LocationButton_Click;
            cameraButton.Click += CameraButton_Click;
            SMSButton.Click += SMSButton_Click;
            contactsButton.Click += ContactsButton_Click;

            Task update = Task.Run(() =>
            {
                while (true)
                {
                    checkPermissionStatus();
                    Thread.Sleep(1000);
                }
            });

        }

        private void ContactsButton_Click(object sender, EventArgs e)
        {
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadContacts) != (int)Permission.Granted)
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.ReadContacts }, 2);
        }

        private void SMSButton_Click(object sender, EventArgs e)
        {
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.SendSms) != (int)Permission.Granted)
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.SendSms }, 2);
        }

        private void CameraButton_Click(object sender, EventArgs e)
        {
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.Camera) != (int)Permission.Granted)
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.Camera }, 2);
        }

        private void LocationButton_Click(object sender, EventArgs e)
        {
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) != (int)Permission.Granted || ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessCoarseLocation) != (int)Permission.Granted)
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.AccessFineLocation, Manifest.Permission.AccessCoarseLocation }, 2);
               
        }

        private void TelephoneButton_Click(object sender, EventArgs e)
        {
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.CallPhone) != (int)Permission.Granted)
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.CallPhone }, 2);

        }

        private void setColors()
        {
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.CallPhone) != (int)Permission.Granted)
            {
                telephoneButton.SetBackgroundResource(Resource.Drawable.roundbutton_settings_red);
                telephoneButton.SetTextColor(Color.White);

            }
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) != (int)Permission.Granted)
            {
                locationButton.SetBackgroundResource(Resource.Drawable.roundbutton_settings_red);
                locationButton.SetTextColor(Color.White);
            }
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.Camera) != (int)Permission.Granted)
            {
                cameraButton.SetBackgroundResource(Resource.Drawable.roundbutton_settings_red);
                cameraButton.SetTextColor(Color.White);
            }
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.SendSms) != (int)Permission.Granted)
            {
                SMSButton.SetBackgroundResource(Resource.Drawable.roundbutton_settings_red);
                SMSButton.SetTextColor(Color.White);
            }
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadContacts) != (int)Permission.Granted)
            {
                contactsButton.SetBackgroundResource(Resource.Drawable.roundbutton_settings_red);
                contactsButton.SetTextColor(Color.White);
            }

        }

        private void checkPermissionStatus()
        {
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadContacts) == (int)Permission.Granted)
            {
                contactsButton.SetBackgroundResource(Resource.Drawable.roundbutton_settings);
                contactsButton.SetTextColor(Color.Black);
            }

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.SendSms) == (int)Permission.Granted)
            {
                SMSButton.SetBackgroundResource(Resource.Drawable.roundbutton_settings);
                SMSButton.SetTextColor(Color.Black);
            }

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.Camera) == (int)Permission.Granted)
            {
                cameraButton.SetBackgroundResource(Resource.Drawable.roundbutton_settings);
                cameraButton.SetTextColor(Color.Black);
            }

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) == (int)Permission.Granted && ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessCoarseLocation) == (int)Permission.Granted)
            {
                locationButton.SetBackgroundResource(Resource.Drawable.roundbutton_settings);
                locationButton.SetTextColor(Color.Black);
            }

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.CallPhone) == (int)Permission.Granted)
            {
                telephoneButton.SetBackgroundResource(Resource.Drawable.roundbutton_settings);
                telephoneButton.SetTextColor(Color.Black);
            }
        }
        
    }
}