using System.Threading.Tasks;

namespace Saplin.CPDT.UICore.Animations
{
    public class HighlightAnimation : AnimationBase
    {

        protected override async Task Animate()
        {
            await FadeTo(0.2, 50);
            await FadeTo(0.4, 60);
            await FadeTo(0.1, 60);
            await ScaleTo(0.8,60);
            await ScaleTo(1.0, 60);
            await FadeTo(1.0, 200);
        }
    }
}
