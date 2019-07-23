using System.Threading.Tasks;

namespace Saplin.CPDT.UICore.Animations
{
    public class BounceAnimation : AnimationBase
    {
        public BounceAnimation()
        {
            Infinite = true;
        }

        #pragma warning disable CS4014
        protected override async Task Animate()
        {
            FadeTo(1.0, 750);
            var t = ScaleTo(1.25, 750);
            if (t != null) await t;

            t = FadeTo(0.5, 200);
            if (t != null) await t;
        }
    }
}