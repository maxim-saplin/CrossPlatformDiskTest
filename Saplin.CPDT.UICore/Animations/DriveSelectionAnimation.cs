using System.Threading.Tasks;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.Animations
{
    public class DriveSelectionAnimation : AnimationBase
    {
        #pragma warning disable CS4014
        protected override async Task Animate()
        {
            if (Trigger) // IsVisible
            {
                target.IsVisible = true;
                var t = FadeTo(1.0, 150);
                if (t != null) await t;

                t = TranslateTo(0, 0, 200);
                if (t != null) await t;
            }
            else 
            {
                //previousHeight = target.Height;
                //HeightRequestTo(0, false, 350);
                //await FadeTo(0.0, 350);

                var height = Device.RuntimePlatform == Device.macOS ? target.Height : -target.Height;
                TranslateTo(0, height, 300);
                var t = FadeTo(0.0, 350);
                if (t != null) await t.ContinueWith((e) => { Device.BeginInvokeOnMainThread(() => target.IsVisible = false); });
            }
        }
    }
}
