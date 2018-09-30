using System.Threading.Tasks;

namespace Saplin.CPDT.UICore.Animations
{
    public class BounceAnimation : AnimationBase
    {
        public BounceAnimation()
        {
            Infinite = true;
        }

        protected override async Task Animate()
        {
            FadeTo(1.0, 750);
            await ScaleTo(1.25, 750);
            FadeTo(0.5, 200);
            await ScaleTo(1.00, 200);
        }
    }
}