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

namespace TheiaBProjectv2.DataModels
{
    
    public class Account
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string username { get; set; }
        public string emergencyContact { get; set; }

        public Account(string firstname, string lastname, string email, string phoneNumber, string username, string emergencyContact)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.username = username;
            this.emergencyContact = emergencyContact;

        }

    }
}