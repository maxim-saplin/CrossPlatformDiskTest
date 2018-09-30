using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

[assembly: ResolutionGroupName("Saplin")]
[assembly: ExportEffect(typeof(Saplin.CPDT.WPF.BlurPlatformEffect), "BlurPlatformEffect")]

namespace Saplin.CPDT.WPF
{
    public class BlurPlatformEffect : PlatformEffect
    {
        private DependencyPropertyChangedEventHandler visibleChanged;
        private SizeChangedEventHandler sizeChanged;
        private Window window;

        protected override void OnAttached()
        {
            var control = Control as Panel;

            if (control != null)
            {
                System.Windows.Controls.Image image = null;

                var effect = new BlurEffect
                {
                    Radius = 5,
                    KernelType = KernelType.Box,
                    RenderingBias = RenderingBias.Performance
                };

                window = System.Windows.Application.Current.MainWindow;

                var dpiX = 96;//(int)typeof(SystemParameters).GetProperty("DpiX", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null, null);
                var dpiY = 96;//(int)typeof(SystemParameters).GetProperty("Dpi", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null, null);

                var renderer = new RenderTargetBitmap((int)window.Width, (int)window.Height, dpiX, dpiY, PixelFormats.Pbgra32);

                visibleChanged = (s, e) =>
                {
                    if (control.IsVisible)
                    {
                        control.Children.Remove(image);
                        var children = control.Children.Cast<UIElement>().ToArray();
                        control.Children.Clear();

                        image = new System.Windows.Controls.Image();
                        image.Effect = effect;
                        image.Stretch = Stretch.Fill;
                        image.Source = renderer;
                        renderer.Render(window);

                        control.Children.Add(image);
                        foreach (var c in children)
                            control.Children.Add(c);

                        image.Width = window.Width;
                        image.Height = window.Height;
                        image.Measure(new System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity));
                        image.Arrange(new Rect(image.DesiredSize));
                    }
                };

                control.IsVisibleChanged += visibleChanged;

                sizeChanged = (s, e) =>
                {
                    if (control.IsVisible && image != null)
                    {
                        image.Width = window.Width;
                        image.Height = window.Height;
                        image.Measure(new System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity));
                        image.Arrange(new Rect(image.DesiredSize));
                    }
                    else
                    {
                        renderer = new RenderTargetBitmap((int)window.Width, (int)window.Height, dpiX, dpiY, PixelFormats.Pbgra32);
                    }
                };

                window.SizeChanged += sizeChanged;
            }
        }

        protected override void OnDetached()
        {
            (Control as Panel).IsVisibleChanged -= visibleChanged;
            window.SizeChanged -= sizeChanged;
        }
    }
}