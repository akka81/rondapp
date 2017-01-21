using RondApp.Services;
using Xamarin.Forms;
using Windows.ApplicationModel.Calls;

[assembly: Dependency(typeof(RondApp.UWP.Services.PhoneDialer))]
namespace RondApp.UWP.Services
{
    public class PhoneDialer : IDialer
    {
        public bool Dial(string number)
        {
            PhoneCallManager.ShowPhoneCallUI(number, "");
            return true;
        }
    }
}
