using Foundation;
using Saplin.CPDT.UICore;
using Xamarin.Forms;

[assembly: Dependency(typeof(Saplin.CPDT.iOS.FreeMemory))]
namespace Saplin.CPDT.iOS
{
    public class FreeMemory : IFreeMemory
    {
        public long GetBytesFree()
        {
            var mem = NSProcessInfo.ProcessInfo.PhysicalMemory *0.5; // as a rule of thumb iOS will allow an app to take 50% of total RAM

            return (long)mem;
        }
    }
}
