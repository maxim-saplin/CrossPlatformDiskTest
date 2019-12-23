using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Saplin.CPDT.Droid.CachePurger;
using static Android.App.ActivityManager;

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

            try // JIC, in GPlay Vitals there was an Exception in here, White Theme shouldn't break app launch
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
                else if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
                {
                    Window.SetStatusBarColor(Android.Graphics.Color.Black);
                    Window.SetNavigationBarColor(Android.Graphics.Color.Black);
                }
            }
            catch { };
        }

        protected override void OnStart()
        {
            base.OnStart();
            System.Diagnostics.Debug.WriteLine("Activity started");
            //Toast.MakeText(Android.App.Application.Context, "Main Activity", ToastLength.Short).Show();
            //try
            //{
            //    Task.Run(() =>
            //   {
            //       Intent intent = new Intent(this, typeof(SecondActivity));
            //       StartActivity(intent);
            //   });
            //}
            //catch(Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine("Exception " + ex.Message);
            //}

            //var purger = new Purger();
            //purger.Purge();           
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

        protected internal volatile bool memCritical = false;
        protected internal volatile float avaialToTotalThreshold = 0;

        public override void OnTrimMemory([GeneratedEnum] TrimMemory level)
        {
            base.OnTrimMemory(level);

            System.Diagnostics.Debug.WriteLine("OnTrimMemory - " + level.ToString());

            if (level == TrimMemory.RunningCritical)
            {
                memCritical = true;
                var activityManager = Android.App.Application.Context.GetSystemService(Context.ActivityService) as ActivityManager;
                MemoryInfo memInfo = new MemoryInfo();
                activityManager.GetMemoryInfo(memInfo);
                avaialToTotalThreshold = (float)memInfo.AvailMem / memInfo.TotalMem;
            }
        }
    }
}

