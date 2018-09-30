using Windows.UI.Xaml;
using Xamarin.Forms;

[assembly: Dependency(typeof(Saplin.CPDT.UICore.UWP.CloseApplication))]

namespace Saplin.CPDT.UICore.UWP
{
    public class CloseApplication : ICloseApplication
    {
        public void Close()
        {
            Windows.UI.Xaml.Application.Current.Exit();
        }
    }
}
