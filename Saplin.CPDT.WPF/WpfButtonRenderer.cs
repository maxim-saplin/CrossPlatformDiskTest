using System.Windows.Input;
using System.Windows.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

[assembly: ExportRenderer(typeof(Button), typeof(Saplin.CPDT.WPF.WpfButtonRenderer))]

namespace Saplin.CPDT.WPF
{
    public class WpfButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if ((Control != null) && (e.NewElement is Button))
            {
                Control.Cursor = Cursors.Hand;
                
                var defColor = Control.Foreground;
                Control.BorderBrush = Control.Background;

                var hoverColor = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
                
                Control.MouseLeave += (s, eargs) =>
                {
                    Control.Foreground = defColor;
                };

                Control.MouseEnter += (s, eargs) =>
                {
                    Control.Foreground = hoverColor;
                };
            }
        }
    }
}
