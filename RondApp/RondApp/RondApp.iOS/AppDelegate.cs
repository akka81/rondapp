﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace RondApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {


            UIWindow.Appearance.BackgroundColor = UIColor.FromRGB(245,245,245);
            UIToolbar.Appearance.TintColor = UIColor.FromRGB(63, 81, 181);
            UIToolbar.Appearance.BarTintColor = UIColor.White;
            UINavigationBar.Appearance.TintColor = UIColor.FromRGB(63, 81, 181);
            UINavigationBar.Appearance.BarTintColor = UIColor.White;

            UIButton.Appearance.BackgroundColor = UIColor.FromRGB(3,169,244);
            UIButton.Appearance.TintColor = UIColor.White;

            UIButton.Appearance.SetTitleColor(UIColor.White, UIControlState.Normal);
           


            global::Xamarin.Forms.Forms.Init();
            Xamarin.FormsMaps.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
