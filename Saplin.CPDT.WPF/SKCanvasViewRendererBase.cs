using System;
using System.ComponentModel;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms.Platform.WPF;
using SKFormsView = SkiaSharp.Views.Forms.SKCanvasView;
using SKNativeView = SkiaSharp.Views.WPF.SKElement;

namespace Saplin.CPDT.WPF
{
    public abstract class SKCanvasViewRendererBase<TFormsView, TNativeView> : ViewRenderer<TFormsView, TNativeView>
        where TFormsView : SKFormsView
        where TNativeView : SKNativeView
    {
        protected SKCanvasViewRendererBase()
        {
            Initialize();
        }

        private void Initialize()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TFormsView> e)
        {
            if (e.OldElement != null)
            {
                var oldController = (ISKCanvasViewController)e.OldElement;

                // unsubscribe from events
                oldController.SurfaceInvalidated -= OnSurfaceInvalidated;
                oldController.GetCanvasSize -= OnGetCanvasSize;
            }

            if (e.NewElement != null)
            {
                var newController = (ISKCanvasViewController)e.NewElement;

                // create the native view
                if (Control == null)
                {
                    var view = CreateNativeControl();
                    view.PaintSurface += OnPaintSurface;
                    SetNativeControl(view);
                }

                // set the initial values
                //touchHandler.SetEnabled(Control, e.NewElement.EnableTouchEvents);
                Control.IgnorePixelScaling = e.NewElement.IgnorePixelScaling;

                // subscribe to events from the user
                newController.SurfaceInvalidated += OnSurfaceInvalidated;
                newController.GetCanvasSize += OnGetCanvasSize;

                // paint for the first time
                OnSurfaceInvalidated(newController, EventArgs.Empty);
            }

            base.OnElementChanged(e);
        }

#if __ANDROID__
		protected override TNativeView CreateNativeControl()
		{
			return (TNativeView)Activator.CreateInstance(typeof(TNativeView), new[] { Context });
		}
#elif TIZEN4_0
		protected virtual TNativeView CreateNativeControl()
		{
			TNativeView ret = (TNativeView)Activator.CreateInstance(typeof(TNativeView), new[] { TForms.NativeParent });
			return ret;
		}
#else
        protected virtual TNativeView CreateNativeControl()
        {
            return (TNativeView)Activator.CreateInstance(typeof(TNativeView));
        }
#endif

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == SKFormsView.IgnorePixelScalingProperty.PropertyName)
            {
                Control.IgnorePixelScaling = Element.IgnorePixelScaling;
            }
            else if (e.PropertyName == SKFormsView.EnableTouchEventsProperty.PropertyName)
            {
                //touchHandler.SetEnabled(Control, Element.EnableTouchEvents);
            }
        }

        protected override void Dispose(bool disposing)
        {
            // detach all events before disposing
            var controller = (ISKCanvasViewController)Element;
            if (controller != null)
            {
                controller.SurfaceInvalidated -= OnSurfaceInvalidated;
                controller.GetCanvasSize -= OnGetCanvasSize;
            }

            var control = Control;
            if (control != null)
            {
                control.PaintSurface -= OnPaintSurface;
            }

            // detach, regardless of state
            //touchHandler.Detach(control);

            base.Dispose(disposing);
        }

        private SKPoint GetScaledCoord(double x, double y)
        {
            if (Element.IgnorePixelScaling)
            {
#if __ANDROID__
				x = Context.FromPixels(x);
				x = Context.FromPixels(y);
#elif TIZEN4_0
				x = Tizen.ScalingInfo.FromPixel(x);
				x = Tizen.ScalingInfo.FromPixel(y);
#elif __IOS__ || __MACOS__ || WINDOWS_UWP
				// Tizen and Android are the reverse of the other platforms
#else
                // no mapping needed, assuming dpi = 100%
#endif
            }
            else
            {
#if __ANDROID__ || TIZEN4_0
				// Tizen and Android are the reverse of the other platforms
#elif __IOS__
				x = x * Control.ContentScaleFactor;
				y = y * Control.ContentScaleFactor;
#elif __MACOS__
				x = x * Control.Window.BackingScaleFactor;
				y = y * Control.Window.BackingScaleFactor;
#elif WINDOWS_UWP
				x = x * Control.Dpi;
				y = y * Control.Dpi;
#else
                // no mapping needed, assuming dpi = 100%
#endif
            }

            return new SKPoint((float)x, (float)y);
        }

        private void OnPaintSurface(object sender, SkiaSharp.Views.Desktop.SKPaintSurfaceEventArgs e)
        {
            var controller = Element as ISKCanvasViewController;

            // the control is being repainted, let the user know
            controller?.OnPaintSurface(new SKPaintSurfaceEventArgs(e.Surface, e.Info));
        }

        private void OnSurfaceInvalidated(object sender, EventArgs eventArgs)
        {
            // repaint the native control
#if __IOS__
			Control.SetNeedsDisplay();
#elif __MACOS__
			Control.NeedsDisplay = true;
#else
            Control.InvalidateVisual();
#endif
        }

        // the user asked for the size
        private void OnGetCanvasSize(object sender, GetPropertyValueEventArgs<SKSize> e)
        {
            e.Value = Control?.CanvasSize ?? SKSize.Empty;
        }
    }
}
