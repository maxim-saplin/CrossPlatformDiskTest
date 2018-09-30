using Windows.UI.Xaml;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Saplin.CPDT.UICore.Controls.ExtendedLabel), typeof(Saplin.CPDT.UICore.UWP.ExtendedLabelRenderer))]

namespace Saplin.CPDT.UICore.UWP
{
    public class ExtendedLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.PointerEntered += (s, args) => { Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 0); };
                Control.PointerExited += (s, args) => { Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 0); };
            }
        }
    }
}
