using Saplin.CPDT.UICore.Controls;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;
using Keyboard = System.Windows.Input.Keyboard;

[assembly: ExportRenderer(typeof(Saplin.CPDT.UICore.MainPage), typeof(Saplin.CPDT.WPF.MainPageRenderer))]

namespace Saplin.CPDT.WPF
{
    public class MainPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var nativeControl = Control;

            if ((nativeControl != null) && (e.NewElement != null))
            {
 
                nativeControl.PreviewTextInput += (s, eargs) =>
                {
                    if (eargs.Text.Length > 0)
                    {
                        var c = eargs.Text[0];
                        SysKeys? sysKey = null;
                        
                        if (c == '\u001b') sysKey = SysKeys.Esc;
                        else if (c == '\r') sysKey = SysKeys.Enter;

                        (e.NewElement as Saplin.CPDT.UICore.MainPage).OnKeyPressed(c, sysKey);
                    }
                };
            }
        }
    }
}
