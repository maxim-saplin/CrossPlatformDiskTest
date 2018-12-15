using AppKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;
using Saplin.CPDT.UICore.Controls;

[assembly: ExportRenderer(typeof(Saplin.CPDT.UICore.MainPage), typeof(Saplin.CPDT.UICore.Mac.MainPageRenderer))]

namespace Saplin.CPDT.UICore.Mac
{
    public class MainPageRenderer : PageRenderer
    {
        Saplin.CPDT.UICore.MainPage xamarinPage;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            xamarinPage = e.NewElement as Saplin.CPDT.UICore.MainPage;
            NSEvent.AddLocalMonitorForEventsMatchingMask(NSEventMask.KeyDown, KeyboardEventHandler);

            NSApplication.Notifications.ObserveWillTerminate(
                (s, eargs) => 
                {
                    xamarinPage?.CloseAplication();
                }
            );

            NSWindow.Notifications.ObserveWillClose(
                (s, eargs) =>
                {
                    //xamarinPage?.CloseAplication();
                }
            );


        }

        private NSEvent KeyboardEventHandler(NSEvent keyEvent)
        {
            if (xamarinPage != null)
            {
                var key = char.MinValue;

                if (!string.IsNullOrWhiteSpace(keyEvent.CharactersIgnoringModifiers) && keyEvent.CharactersIgnoringModifiers.ToLower().ToCharArray().Length > 0)
                    key = keyEvent.CharactersIgnoringModifiers.ToLower().ToCharArray()[0];

                SysKeys? sysKey = null;

                if (keyEvent.KeyCode == 53) sysKey = SysKeys.Esc;
                else if (keyEvent.KeyCode == 36) sysKey = SysKeys.Enter;

                xamarinPage.OnKeyPressed(key, sysKey);
            }

            //return null; // remove beep after press
            return (keyEvent);
        }

    }
}
