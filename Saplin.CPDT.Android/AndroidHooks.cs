using System.Threading.Tasks;
using Android.Content;
using Saplin.CPDT.Droid.CachePurger;
using Saplin.CPDT.UICore;
using Xamarin.Forms;

[assembly: Dependency(typeof(Saplin.CPDT.Droid.AndroidHooks))]
namespace Saplin.CPDT.Droid
{
    class AndroidHooks : IPlatformHooks
    {
        private Purger purger = null;
        private volatile bool inProgress = false;

        public void MinimizeApp()
        {
            Intent home = new Intent(Intent.ActionMain);
            home.AddCategory(Intent.CategoryHome);
            home.SetFlags(ActivityFlags.NewTask);
            MainActivity.Instance.StartActivity(home);
        }

        public void TestClick()
        {
            if (!inProgress)
            {
                Task.Run(
                () =>
                {
                    inProgress = true;
                    purger = new Purger();
                    purger.Purge();
                });
            }
            else
            {
                inProgress = false;
                purger?.Break();
            }
        }
    }
}