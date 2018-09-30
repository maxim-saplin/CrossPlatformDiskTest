using System.Threading.Tasks;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.Animations
{
    public class VisibilityFadeAnimation2 : AnimationBase
    {
        protected override async Task Animate()
        {
            if (Trigger) // IsVisible
            {
                target.Opacity = 0;
                target.IsVisible = true;
                await FadeTo(0.0, 500, Easing.CubicIn);
                await FadeTo(1.0, 500, Easing.CubicIn);
            }
            else 
            {
                var t = FadeTo(0.0, 300);
                await t.ContinueWith((e) => { Device.BeginInvokeOnMainThread(() => target.IsVisible = false); });
            }
        }
    }
}
