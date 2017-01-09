using Foundation;
using RondApp.Services;
using System;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(RondApp.iOS.Services.PhoneDialer))]
namespace RondApp.iOS.Services
{

    public class PhoneDialer : IDialer
    {

        public bool Dial(string number)
        {
            //Makes a new NSUrl
            var callURL = new NSUrl(string.Format("tel:{0}",number.Replace(" ","")));


            if (UIApplication.SharedApplication.CanOpenUrl(callURL))
            {
                //After checking if phone can open NSUrl, it either opens the URL or outputs to the console.
                return UIApplication.SharedApplication.OpenUrl(callURL);
            }
            else
            {
                //OUTPUT to console
                Console.WriteLine("Can't make call");
                return false;
            }

         
        }
    }
}

