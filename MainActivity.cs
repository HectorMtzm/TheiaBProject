using System;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Support.V7.App;
using Android.Widget;
using Android.Content;
using Android.Support.V4.View;
using Android.Speech;
using Android.Graphics;
using Android.Media;
using Android.Content.PM;
using Android.Text;
using Android.Text.Style;
using Xamarin.Essentials;
using Android.Support.Design.Widget;
using TheiaBProjectv2.Helpers;
using TheiaBProjectv2.Listeners;
using TheiaBProjectv2.Activities;

namespace TheiaBProjectv2
{
    [Activity(Label = "Activity1", Theme = "@style/AppTheme.NoActionBar", LaunchMode = LaunchMode.SingleInstance)]
    public class MainActivity : AppCompatActivity, TextureView.ISurfaceTextureListener
    {
        private AutoCompleteTextView searchACTextView;
        private GestureDetector gestureDetector;
        private CameraGestureListener cameraGestureListener;
        private NavigationView navview;
        private IMenuItem menuItem;

        //accelerometer
        int fallCount = 0;

        //camera variables
        private TextureView cameraSurfaceView;
        Android.Hardware.Camera camera;

        //voice to text variables
        private readonly int VOICE = 10;
        private bool isRecording = false;
        private ImageButton micButton;

        //Drawer
        Android.Support.V4.Widget.DrawerLayout drawerLayout;

        //audio player
        protected MediaPlayer tryAgainAudio, strartingNavAudio, fallDetected;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            if (LogInActivity.instance != null)
            {
                try
                {
                    LogInActivity.instance.Finish();
                }
                catch (Exception e) { }
            }
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main_camera_layout);

            initializeVariables();

            //Autocomplete edittext
            var adapter = new ArrayAdapter<String>(this, Resource.Layout.list_item, Rooms.rooms);
            searchACTextView.Adapter = adapter;
            searchACTextView.ItemClick += SearchACTextView_ItemClick;
            
            //GestureDetector event handler
            cameraSurfaceView.Touch += (object sender, View.TouchEventArgs e) => {
                gestureDetector.OnTouchEvent(e.Event);
            };

            //Mic voice to text
            string rec = Android.Content.PM.PackageManager.FeatureMicrophone;
            micButton.Click += MicButton_Click;

            //Navigation item selection events
            navview.NavigationItemSelected += Navview_NavigationItemSelected;

            //Accelerometer / Fall detector
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
        }

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var data = e.Reading;
            var acceleration = Math.Sqrt((data.Acceleration.X * data.Acceleration.X) + (data.Acceleration.Y * data.Acceleration.Y) + (data.Acceleration.Z * data.Acceleration.Z));

            Console.WriteLine(acceleration);
            if (acceleration < 0.2)
                fallCount++;
            else if (fallCount > 4 && acceleration > 0.9)
            {
                fallDetected.Start();
            }
            else
                fallCount = 0;
        }

        private void Navview_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            switch (e.MenuItem.ItemId)
            {
                case Resource.Id.navHome:
                    drawerLayout.CloseDrawers();
                    break;

                case Resource.Id.navProfile:
                    break;

                case Resource.Id.navSettings:
                    Intent intent = new Intent(this, typeof(SettMenuActivity));
                    StartActivity(intent);
                    break;

                case Resource.Id.navCall:
                    cameraGestureListener.MakePhoneCall("4693439123");
                    break;
                case Resource.Id.navLocation:
                    cameraGestureListener.sendLocation();
                    break;
                case Resource.Id.navLogout:
                    StartActivity(typeof(LogInActivity));
                    this.OverridePendingTransition(Resource.Transition.fade_in, Resource.Transition.fade_out);
                    this.Finish();
                    break;
            }
        }

        private void SearchACTextView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            strartingNavAudio.Start();
            searchACTextView.OnEditorAction(Android.Views.InputMethods.ImeAction.Done);
        }

        private void initializeVariables()
        {
            searchACTextView = FindViewById<AutoCompleteTextView>(Resource.Id.searchACTextView);
            cameraSurfaceView = FindViewById<TextureView>(Resource.Id.cameraSurfaceView);
            navview = FindViewById<NavigationView>(Resource.Id.navview);
            micButton = FindViewById<ImageButton>(Resource.Id.micButton);
            drawerLayout = FindViewById<Android.Support.V4.Widget.DrawerLayout>(Resource.Id.drawerLayout);
            colorMenu();

            //Accelerometer
            Accelerometer.Start(SensorSpeed.Game);

            //camera preview. Obsolete btw.
            cameraSurfaceView.SurfaceTextureListener = this;

            //set audio files
            tryAgainAudio = MediaPlayer.Create(this, Resource.Raw.pleaseTryAgain);
            strartingNavAudio = MediaPlayer.Create(this, Resource.Raw.startingNavigation);
            fallDetected = MediaPlayer.Create(this, Resource.Raw.fallDetected);

            //Double tap detector
            cameraGestureListener = new CameraGestureListener(this, this);
            gestureDetector = new GestureDetector(this, cameraGestureListener);
        }

        private void MicButton_Click(object sender, EventArgs e)
        {
            //create the intent and start the activity
            var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
            voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);

            //message on the modal dialog
            voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, "Speak now");

            //if there is more then 1.5s of silence, consider the speech over
            voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
            voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);
            voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 15000);
            voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);

            //Languages to be recognized
            voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);
            StartActivityForResult(voiceIntent, VOICE);
        }

        //Camera stuff
        public void OnSurfaceTextureAvailable(Android.Graphics.SurfaceTexture surface, int w, int h)
        {
            camera = Android.Hardware.Camera.Open();

            cameraSurfaceView.LayoutParameters = new RelativeLayout.LayoutParams(w, h);

            try
            {
                camera.SetPreviewTexture(surface);
                camera.SetDisplayOrientation(90);
                camera.StartPreview();

            }
            catch (Java.IO.IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool OnSurfaceTextureDestroyed(Android.Graphics.SurfaceTexture surface)
        {
            camera.StopPreview();
            camera.Release();

            return true;
        }

        public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
        {
        }

        public void OnSurfaceTextureUpdated(SurfaceTexture surface)
        {
        }

        //voice to text.
        protected override void OnActivityResult(int requestCode, Result resultVal, Intent data)
        {
            string[] roomsArray = new string[Rooms.rooms.Length];
            Rooms.rooms.CopyTo(roomsArray, 0);

            if (requestCode == VOICE)
            {
                if (resultVal == Result.Ok)
                {
                    searchACTextView.Text = "";
                    var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);
                    if (matches.Count != 0)
                    {
                        string textInput = searchACTextView.Text + matches[0];

                        // limit the output to 30 characters
                        if (textInput.Length >= 10)
                        {
                            textInput = textInput.Substring(0, 10);
                            textInput = textInput.ToUpper();
                            for (int i = 0; i < roomsArray.Length; i++)
                            {
                                if (textInput == roomsArray[i])
                                {
                                    searchACTextView.Text = textInput;
                                    strartingNavAudio.Start();
                                    searchACTextView.DismissDropDown();
                                    return;
                                }
                            }   
                                tryAgainAudio.Start();
                        }
                        else if (textInput.Length == 5)
                        {
                            for (int i = 0; i < roomsArray.Length; i++)
                            {
                                if (textInput == roomsArray[i].Substring(5, 5))
                                {
                                    searchACTextView.Text = roomsArray[i];
                                    strartingNavAudio.Start();
                                    searchACTextView.DismissDropDown();
                                    return;
                                }
                            }
                                tryAgainAudio.Start();
                        }
                        else
                        {
                            tryAgainAudio.Start();
                        }
                    }
                }
            }

            base.OnActivityResult(requestCode, resultVal, data);
        }

        //Color menu items
        private void colorMenu()
        {
            menuItem = navview.Menu.FindItem(Resource.Id.navCall);
            SpannableString s = new SpannableString(menuItem.TitleFormatted);
            s.SetSpan(new ForegroundColorSpan(Color.DarkOrange), 0, s.Length(), 0);
            menuItem.SetTitle(s);

            menuItem = navview.Menu.FindItem(Resource.Id.navLocation);
            s = new SpannableString(menuItem.TitleFormatted);
            s.SetSpan(new ForegroundColorSpan(Color.DarkOrange), 0, s.Length(), 0);
            menuItem.SetTitle(s);

            menuItem = navview.Menu.FindItem(Resource.Id.navLogout);
            s = new SpannableString(menuItem.TitleFormatted);
            s.SetSpan(new ForegroundColorSpan(Color.Red), 0, s.Length(), 0);
            menuItem.SetTitle(s);

        }

        //Snackbar preventing accidental exit
        public override void OnBackPressed()
        {
            if (drawerLayout.IsDrawerOpen(GravityCompat.Start))
                drawerLayout.CloseDrawers();

            else
            {
                Snackbar snackbar = Snackbar.Make((View)cameraSurfaceView, "Use the home button to exit", Snackbar.LengthShort);
                Snackbar.SnackbarLayout layout = (Snackbar.SnackbarLayout)snackbar.View;    //get the snackbar layout
                layout.SetMinimumHeight(110);
                layout.SetBackgroundColor(Android.Graphics.Color.DarkOrange);
                
                TextView snackbarTextView = snackbar.View.FindViewById<TextView>(Resource.Id.snackbar_text);    //change text size
                snackbarTextView.SetTextSize(Android.Util.ComplexUnitType.Dip, 29);                             //

                snackbar.Show();
            }
        }
    }
}