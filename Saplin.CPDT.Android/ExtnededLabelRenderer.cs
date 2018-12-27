using Android.Content;
using Saplin.CPDT.UICore.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Saplin.CPDT.UICore.Controls.ExtendedLabel), typeof(Saplin.CPDT.Droid.ExtnededLabelRenderer))]
namespace Saplin.CPDT.Droid
{
    public class ExtnededLabelRenderer : Xamarin.Forms.Platform.Android.LabelRenderer
    {
        public ExtnededLabelRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var el = (Element as ExtendedLabel);

            if (el != null && el.JustifyText)
            {
                if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
                {
                    Control.JustificationMode = Android.Text.JustificationMode.InterWord;
                }
                    
            }
        }
    }
}
