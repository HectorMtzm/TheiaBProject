using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Support.V7.App;
using Android.Widget;
using TheiaBProjectv2.Helpers;
using Android.Content;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Speech;
using Android.Graphics;
using Android.Media;
using Android.Telephony;
using Xamarin.Essentials;
using TheiaBProjectv2.Listeners;

namespace TheiaBProjectv2
{
    [Activity(Label = "Activity1", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity, TextureView.ISurfaceTextureListener
    {
        private AutoCompleteTextView searchACTextView;
        private GestureDetector gestureDetector;
        private bool backPressedOnce = false;
        private NavigationView navview;

        //camera variables
        private TextureView cameraSurfaceView;
        Android.Hardware.Camera camera;

        //voice to text variables
        private readonly int VOICE = 10;
        private bool isRecording = false;
        public ImageButton micButton;

        //Drawer
        Android.Support.V4.Widget.DrawerLayout drawerLayout;

        //audio player
        protected MediaPlayer tryAgainAudio;
        protected MediaPlayer strartingNavAudio;
        protected MediaPlayer locationSent;
        protected MediaPlayer CallingEC;

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

            searchACTextView = FindViewById<AutoCompleteTextView>(Resource.Id.searchACTextView);
            cameraSurfaceView = FindViewById<TextureView>(Resource.Id.cameraSurfaceView);
            navview = FindViewById<NavigationView>(Resource.Id.navview);
            micButton = FindViewById<ImageButton>(Resource.Id.micButton);
            drawerLayout = FindViewById<Android.Support.V4.Widget.DrawerLayout>(Resource.Id.drawerLayout);

            //camera preview. Obsolete btw.
            cameraSurfaceView.SurfaceTextureListener = this;

            //Autocomplete edittext
            var adapter = new ArrayAdapter<String>(this, Resource.Layout.list_item, Rooms.rooms);
            searchACTextView.Adapter = adapter;

            //Set up listener
            //gestureDetector = new GestureDetector(this, new CameraGestureListener(this, this));

            //set audio files
            tryAgainAudio = MediaPlayer.Create(this, Resource.Raw.pleaseTryAgain);
            strartingNavAudio = MediaPlayer.Create(this, Resource.Raw.startingNavigation);

            //Double tap detector
            GestureDetector gestureDetector = new GestureDetector(this, new CameraGestureListener(this));
            
            //tap detector event handler
            cameraSurfaceView.Touch += (object sender, View.TouchEventArgs e) => {
                gestureDetector.OnTouchEvent(e.Event);
            };

            //Mic voice to text
            string rec = Android.Content.PM.PackageManager.FeatureMicrophone;

            micButton.Click += MicButton_Click;
        }

        private void MicButton_Click(object sender, EventArgs e)
        {
            // change the text on the button
            isRecording = !isRecording;
            if (isRecording)
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

            searchACTextView.Text = "";
            if (requestCode == VOICE)
            {
                if (resultVal == Result.Ok)
                {
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

        //Snackbar preventing accidental exit
        public override void OnBackPressed()
        {
            if (drawerLayout.IsDrawerOpen(GravityCompat.Start))
            {
                drawerLayout.CloseDrawers();
            }

            else
            {
                if (backPressedOnce)
                    base.OnBackPressed();

                backPressedOnce = true;

                Snackbar snackbar = Snackbar.Make((View)cameraSurfaceView, "Press again to exit", Snackbar.LengthShort);
                Snackbar.SnackbarLayout layout = (Snackbar.SnackbarLayout)snackbar.View;    //get the snackbar layout
                layout.SetMinimumHeight(110);
                TextView snackbarTextView = snackbar.View.FindViewById<TextView>(Resource.Id.snackbar_text);    //change text size
                snackbarTextView.SetTextSize(Android.Util.ComplexUnitType.Dip, 30);                             //

                snackbar.Show();

                new Handler().PostDelayed(() =>         //reset the double back to exit after 2 seconds
                { backPressedOnce = false; }, 2000);

            }
        }
    }
}