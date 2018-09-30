using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

[assembly: ExportRenderer(typeof(Xamarin.Forms.ScrollView), typeof(Saplin.CPDT.WPF.HiddenScrollViewRenderer))]

namespace Saplin.CPDT.WPF
{
    public class HiddenScrollViewRenderer : ScrollViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ScrollView> e)
        {
            base.OnElementChanged(e);

            var nativeControl = Control;

            if ((nativeControl != null) && (e.NewElement != null))
            {
                nativeControl.VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Hidden;
                nativeControl.HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Hidden;
            }
        }
    }
}
