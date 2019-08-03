using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;

namespace Saplin.CPDT.Droid
{
    [Activity(Label = "Cross Platfrom Disk Test", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.FontScale)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity Instance { get; protected set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Instance = this;

            //var t = typeof(BluredStackLayoutRenderer);//load CPDT.Extra.Android to have renderers in place

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            var app = new Saplin.CPDT.UICore.App();

            LoadApplication(app);

            try // JIC, in Vitals there was an Exception in here, White Theme shouldn't break app launch
            {
                if (app.WhiteTheme)
                {
                    Window.ClearFlags(WindowManagerFlags.TranslucentStatus);
                    Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                    if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
                    {
                        Window.SetStatusBarColor(Android.Graphics.Color.White);
                        Window.SetNavigationBarColor(Android.Graphics.Color.White);
                    }
                    var ui = (int)Window.DecorView.SystemUiVisibility;
                    ui |= (int)Android.Views.SystemUiFlags.LightStatusBar;
                    ui |= (int)Android.Views.SystemUiFlags.LightNavigationBar;
                    Window.DecorView.SystemUiVisibility = (Android.Views.StatusBarVisibility)ui;
                }
            }
            catch { };
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

            var config = Android.App.Application.Context.CreateConfigurationContext(configuration);

            base.AttachBaseContext(config);
        }
    }
}

