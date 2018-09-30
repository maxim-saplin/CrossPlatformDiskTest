using Windows.UI.Xaml;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Saplin.CPDT.UICore.MainPage), typeof(Saplin.CPDT.UICore.UWP.MainPageRenderer))]

namespace Saplin.CPDT.UICore.UWP
{
    public class MainPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var nativeControl = this as FrameworkElement;

            if ((nativeControl != null) && (e.NewElement != null))
            {
                Window.Current.CoreWindow.KeyDown += (s, eargs) =>
                {
                    var key = char.MinValue;

                    if (!string.IsNullOrWhiteSpace(eargs.VirtualKey.ToString()) && eargs.VirtualKey.ToString().ToLower().ToCharArray().Length > 0)
                        key = eargs.VirtualKey.ToString().ToLower().ToCharArray()[0];

                    (e.NewElement as Saplin.CPDT.UICore.MainPage).OnKeyPressed(key);
                };
            }
        }
    }
}
