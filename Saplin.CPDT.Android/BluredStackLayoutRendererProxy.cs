using Android.Content;
using Saplin.CPDT.Droid;
using Saplin.CPDT.UICore.Controls;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(BluredStackLayoutRendererProxy), typeof(BluredStackLayout))]

namespace Saplin.CPDT.Droid
{
    public class BluredStackLayoutRendererProxy : BluredStackLayoutRenderer
    {
        public BluredStackLayoutRendererProxy(Context context) : base(context, MainActivity.Instance)
        {
        }
    }
}
