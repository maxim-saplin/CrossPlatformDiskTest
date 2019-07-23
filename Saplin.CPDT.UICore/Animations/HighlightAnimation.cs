using System.Threading.Tasks;

namespace Saplin.CPDT.UICore.Animations
{
    public class HighlightAnimation : AnimationBase
    {

        protected override async Task Animate()
        {
            var t = FadeTo(0.2, 50);
            if (t != null) await t;

            t = FadeTo(0.4, 60);
            if (t != null) await t;

            t = FadeTo(0.1, 60);
            if (t != null) await t;

            t = ScaleTo(0.8,60);
            if (t != null) await t;

            t = ScaleTo(1.0, 60);
            if (t != null) await t;

            t = FadeTo(1.0, 200);
            if (t != null) await t;
        }
    }
}
