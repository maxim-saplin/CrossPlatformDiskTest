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
        }

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
                return 0;
            }

            const float avaialToToalThreshold = 0.25f; // Samsung devices tend to kill app at MemVaial below ~20% from total without calling onMemoryTrim event

            if ((float)memInfo.AvailMem/memInfo.TotalMem < avaialToToalThreshold)
            {
                System.Diagnostics.Debug.WriteLine("MemoryInfo.AvailMem/MemoryInfo.TotalMem below threshold " + avaialToToalThreshold);
                return 0;
            }

            return memInfo.AvailMem-memInfo.Threshold;
        }
    }
}