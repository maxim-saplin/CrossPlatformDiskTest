using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Views;

namespace Saplin.CPDT.Droid
{
    [Activity(Label = "Cross Platfrom Disk Test", Icon = "@mipmap/ic_launcher", Theme = "@style/BlackTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.FontScale)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity Instance { get; protected set; }

        protected override void OnCreate(Bundle bundle)
        {

#if DEBUG
            var sw = new Stopwatch();
            var sb = new StringBuilder();
            sw.Start();
#endif

            base.OnCreate(bundle);
#if DEBUG
            sb.AppendLine("OnCreate " + sw.ElapsedMilliseconds);
#endif

            Instance = this;

            global::Xamarin.Forms.Forms.Init(this, bundle);
#if DEBUG
            sb.AppendLine("Forms.Init " + sw.ElapsedMilliseconds);
#endif

            var app = new Saplin.CPDT.UICore.App();
#if DEBUG
            sb.AppendLine("new UICore.App " + sw.ElapsedMilliseconds);
#endif

            LoadApplication(app);
#if DEBUG
            sb.AppendLine("LoadApplication " + sw.ElapsedMilliseconds);
#endif

            if (app.WhiteTheme)
            {
                Window.ClearFlags(WindowManagerFlags.TranslucentStatus);
                Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                Window.SetStatusBarColor(Android.Graphics.Color.White);
                Window.SetNavigationBarColor(Android.Graphics.Color.White);
                var ui = (int)Window.DecorView.SystemUiVisibility;
                ui |= (int)Android.Views.SystemUiFlags.LightStatusBar;
                ui |= (int)Android.Views.SystemUiFlags.LightNavigationBar;
                Window.DecorView.SystemUiVisibility = (Android.Views.StatusBarVisibility)ui;
            }
#if DEBUG
            sw.Stop();
            sb.AppendLine("Done " + sw.ElapsedMilliseconds);
            System.Diagnostics.Debug.WriteLine(sb);
#endif
        }

        protected override void AttachBaseContext(Context @base)
        {
            var configuration = new Configuration(@base.Resources.Configuration);

            int minDimension = @base.Resources.Configuration.ScreenWidthDp > @base.Resources.Configuration.ScreenHeightDp
               ? @base.Resources.Configuration.ScreenHeightDp : @base.Resources.Configuration.ScreenWidthDp;

            if (minDimension > 640)
            {
                configuration.FontScale = 1.2f;
            }
            else if (minDimension > 360)
            {
                configuration.FontScale = 1f;
            }
            else configuration.FontScale = 0.8f;

            var config =  Application.Context.CreateConfigurationContext(configuration);

            base.AttachBaseContext(config);
        }
    }
}

