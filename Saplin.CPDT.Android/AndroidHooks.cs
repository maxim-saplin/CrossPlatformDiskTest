using Android.Content;
using Saplin.CPDT.UICore;
using Xamarin.Forms;

[assembly: Dependency(typeof(Saplin.CPDT.Droid.AndroidHooks))]
namespace Saplin.CPDT.Droid
{
    class AndroidHooks : IPlatformHooks
    {
        public void MinimizeApp()
        {
            Intent home = new Intent(Intent.ActionMain);
            home.AddCategory(Intent.CategoryHome);
            home.SetFlags(ActivityFlags.NewTask);
            MainActivity.Instance.StartActivity(home);
        }
    }
}