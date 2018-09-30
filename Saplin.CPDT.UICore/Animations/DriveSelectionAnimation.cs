using System.Threading.Tasks;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.Animations
{
    public class DriveSelectionAnimation : AnimationBase
    {
        //private double previousHeight = -1;

        protected override async Task Animate()
        {
            if (Trigger) // IsVisible
            {
                //if (previousHeight == -1) return;

                //HeightRequestTo(previousHeight, true, 350);
                //await FadeTo(1.0, 350);

                //previousHeight = -1;

                target.IsVisible = true;
                await FadeTo(1.0, 150);
                await TranslateTo(0, 0, 200);
            }
            else 
            {
                //previousHeight = target.Height;
                //HeightRequestTo(0, false, 350);
                //await FadeTo(0.0, 350);

                var height = Device.RuntimePlatform == Device.macOS ? target.Height : -target.Height;
                TranslateTo(0, height, 300);
                var t = FadeTo(0.0, 350);
                await t.ContinueWith((e) => { Device.BeginInvokeOnMainThread(() => target.IsVisible = false); });
            }
        }
    }
}
