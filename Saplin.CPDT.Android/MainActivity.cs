using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;

namespace Saplin.CPDT.Droid
{
    [Activity(Label = "Cross Platfrom Disk Test", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity Instance { get; protected set; }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            AdjustFontScale(Resources.Configuration);

            Instance = this;

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new Saplin.CPDT.UICore.App());
        }

        public void AdjustFontScale(Configuration config)
        {
            var configuration = new Configuration(config);
            configuration.FontScale = 1.0f;
            var metrics = Resources.DisplayMetrics;
            var wm = GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
            wm.DefaultDisplay.GetMetrics(metrics);
            metrics.ScaledDensity = configuration.FontScale * metrics.Density;
            //Application.Context.CreateConfigurationContext(configuration);
            Application.Context.Resources.UpdateConfiguration(configuration, metrics);
        }
    }
}

