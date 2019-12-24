using System;
using Android.App;
using Android.Content;
using Saplin.CPDT.UICore;
using Xamarin.Forms;
using static Android.App.ActivityManager;

[assembly: Dependency(typeof(Saplin.CPDT.Droid.FreeMemeory))]
namespace Saplin.CPDT.Droid
{
    public class FreeMemeory : IFreeMemory // if true (default) than also check for system events for low memory and return 0
    {

        public long GetBytesFree()
        {
            var activityManager = Android.App.Application.Context.GetSystemService(Context.ActivityService) as ActivityManager;

            MemoryInfo memInfo = new MemoryInfo();
            activityManager.GetMemoryInfo(memInfo);

            return memInfo.AvailMem;
        }
    }
}