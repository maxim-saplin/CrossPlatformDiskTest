using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Java.IO;
using Saplin.CPDT.UICore.Misc;
using Xamarin.Forms;

[assembly: Dependency(typeof(Saplin.CPDT.Droid.FileSync))]
namespace Saplin.CPDT.Droid
{
    public class FileSync: IFileSync 
    {
        ParcelFileDescriptor descriptor;

        public void OpenFile(string path)
        {
            var cr = Android.App.Application.Context.ContentResolver;

            descriptor = cr.OpenFileDescriptor(Uri.FromFile(new File(path)), "rw");
            
        }

        public void Flush()
        {
            descriptor.FileDescriptor.Sync();
        }

        public void Close()
        {
            descriptor?.FileDescriptor?.Sync();
            descriptor?.Close();
            descriptor = null;
        }
    }
}
