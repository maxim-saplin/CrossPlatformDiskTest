using Android.App;
using Xamarin.Forms;

[assembly: Dependency(typeof(Saplin.CPDT.Droid.ShareFilesProxy))]
namespace Saplin.CPDT.Droid
{
    public class ShareFilesProxy : ShareFiles
    {
        public ShareFilesProxy() : this(MainActivity.Instance)
        {
        }

        public ShareFilesProxy(Activity mainActivity) : base(MainActivity.Instance)
        {
        }
    }
}
