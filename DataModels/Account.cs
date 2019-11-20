using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TheiaB.Droid.DataModels
{
    
    class Account
    {
        string username { get; set; }
        string firstname { get; set; }
        string lastname { get; set; }
        string password { get; set; }
    }
}