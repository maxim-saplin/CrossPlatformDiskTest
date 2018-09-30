using System.ComponentModel;
using AppKit;
using CoreImage;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

[assembly: ResolutionGroupName("Saplin")]
[assembly: ExportEffect(typeof(Saplin.CPDT.UICore.Mac.BlurPlatformEffect), "BlurPlatformEffect")]

namespace Saplin.CPDT.UICore.Mac
{
    public class BlurPlatformEffect : PlatformEffect
    {

        private CIFilter filter;

        protected override void OnAttached()
        {
            if (Container is NSView)
            {
                var control = (Container as NSView);

                control.WantsLayer = true;
                control.LayerUsesCoreImageFilters = true;
                filter = CIFilter.FromName("CIGaussianBlur");
                filter.SetDefaults();
            }
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == "IsVisible")
            {
                if ((Element as VisualElement).IsVisible)
                {
                    Container.Layer.BackgroundFilters = new CIFilter[] { filter };
                }
                else 
                { 
                    Container.Layer.BackgroundFilters = null; 
                }
            }
        }
    }
}