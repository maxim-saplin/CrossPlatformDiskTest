using System.Threading.Tasks;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.Animations
{
    public class VisibilityFadeAnimation : AnimationBase
    {
        protected override async Task Animate()
        {
            if (Trigger) // IsVisible
            {
                target.Opacity = 0;
                target.IsVisible = true;
                var t = FadeTo(1.0, 300, Easing.CubicIn);
                if (t != null) await t;
            }
            else 
            {
                var t = FadeTo(0.0, 300);
                if (t != null) await t.ContinueWith((e) => { Device.BeginInvokeOnMainThread(() => target.IsVisible = false); });
            }
        }
    }
}
