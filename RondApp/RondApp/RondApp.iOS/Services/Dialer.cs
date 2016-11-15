using Foundation;
using RondApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace RondApp.iOS.Services
{


    public class PhoneDialer : IDialer
    {

        public bool Dial(string number)
        {
        
            return UIApplication.SharedApplication.OpenUrl(
                new NSUrl("tel:" + number));
        }
    }
}

