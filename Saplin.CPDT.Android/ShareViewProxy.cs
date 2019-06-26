using Android.App;
using Xamarin.Forms;

[assembly: Dependency(typeof(Saplin.CPDT.Droid.ShareViewProxy))]
namespace Saplin.CPDT.Droid
{
    public class ShareViewProxy : ShareViewAsImage
    {
        public ShareViewProxy() : this(MainActivity.Instance)
        {
        }

        public ShareViewProxy(Activity mainActivity) : base(MainActivity.Instance)
        {
        }
    }
}
