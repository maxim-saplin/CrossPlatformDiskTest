using Android.App;
using Android.Content;
using Saplin.CPDT.UICore;
using Xamarin.Forms;
using static Android.App.ActivityManager;

[assembly: Dependency(typeof(Saplin.CPDT.Droid.FreeMemeory))]
namespace Saplin.CPDT.Droid
{
    public class FreeMemeory : IFreeMemory
    {
        public long GetBytesFree()
        {
            var activityManager = Android.App.Application.Context.GetSystemService(Context.ActivityService) as ActivityManager;

            MemoryInfo memInfo = new MemoryInfo();
            activityManager.GetMemoryInfo(memInfo);

            return (long)(memInfo.AvailMem);
        }
    }
}
