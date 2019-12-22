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
        public FreeMemeory()
        {
            MainActivity.Instance.memCritical = false;
            MainActivity.Instance.avaialToTotalThreshold = 0;
        }

        private float avaialToTotalThreshold = 0.05f;            // Some Samsung S10 devices tend to kill app at MemVaial below ~20-30% from total without calling onMemoryTrim event
        //private const float avaialToToalThresholdSecond = 0.27f; // hack for some nasty S10 killing the activity at 25%+ and android not always calling memoryTrim event.
                                                                // while testing android seem to call memory tream for the first read test cahche purging while not calling
                                                                // the event for the second purging. After the trim is called for the first time lower the mem threshiold.
                                                                // That's needed for the cases when the app is called with little RAM available and large mem threshold may lead to little or 0 blocks to be created for purging.
        
        public long GetBytesFree()
        {
            var activityManager = Android.App.Application.Context.GetSystemService(Context.ActivityService) as ActivityManager;

            MemoryInfo memInfo = new MemoryInfo();
            activityManager.GetMemoryInfo(memInfo);

            System.Diagnostics.Debug.WriteLine("MemoryInfo.AvailMem, MB: " + memInfo.AvailMem / 1024 / 1024 +
                "  Threshold, MB: " + memInfo.Threshold / 1024 / 1024 +
                " TotalMem " + memInfo.TotalMem +
                " LowMemory " + memInfo.LowMemory +
                " memCritical" + MainActivity.Instance.memCritical);

            if (MainActivity.Instance.memCritical)
            {
                MainActivity.Instance.memCritical = false;
                if (MainActivity.Instance.avaialToTotalThreshold > 0) avaialToTotalThreshold = MainActivity.Instance.avaialToTotalThreshold;
                //avaialToToalThreshold = memInfo.AvailMem / memInfo.TotalMem; //avaialToToalThresholdSecond;
                return 0;
            }

            if ((float)memInfo.AvailMem/memInfo.TotalMem < avaialToTotalThreshold)
            {
                System.Diagnostics.Debug.WriteLine("MemoryInfo.AvailMem/MemoryInfo.TotalMem below threshold " + avaialToTotalThreshold);
                return 0;
            }

            return Math.Max(memInfo.AvailMem, (long)(memInfo.TotalMem*0.7));
        }
    }
}