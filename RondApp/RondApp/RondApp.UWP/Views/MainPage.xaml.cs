using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace RondApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            // Dev Key
            //Xamarin.FormsMaps.Init("DOwE9c04FYANowXYO9hi~ZYjofh9rVDSPWP9-oRetBg~AuQh1S2XTqR1npW1wBJ5v3s9lPoOO-lwl-MOcbZetnEp0Sq2C3yGdWVna2KYjk71");
            // Prod Key
            Xamarin.FormsMaps.Init("dauOpNSWpEk3ryUQZlpp~WBVtKxZVM5DUo33CjM9qwA~AmIw0UTBTSK_QPtMrR4k5q_8UhP2G67Q1e25Qu-Wa1ImC5XIVxUjWK_hrfRC9Mik");
            LoadApplication(new RondApp.App());
        }
    }
}
