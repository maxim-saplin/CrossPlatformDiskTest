using Android.OS;
using Android.Content;
using Android.App;
using Android.Widget;

namespace Saplin.CPDT.Droid.CachePurger
{
    public class PurgeServiceConnection : Java.Lang.Object, IServiceConnection
    {
        static readonly string TAG = typeof(PurgeServiceConnection).FullName;

        MainActivity mainActivity;
        public PurgeServiceConnection(MainActivity activity)
        {
            IsConnected = false;
            mainActivity = activity;
        }

        public bool IsConnected { get; private set; }
        public Messenger Messenger { get; private set; }

        public void OnServiceConnected(ComponentName name, IBinder service)
        {
            // = service as PurgerServiceBinder;

            Messenger = new Messenger(service);

            IsConnected = this.Messenger != null;

            string message = "onServiceConnected - ";

            System.Diagnostics.Debug.WriteLine($"OnServiceConnected {name.ClassName}");

            if (IsConnected)
            {
                message = message + " bound to service " + name.ClassName;
            }
            else
            {
                message = message + " not bound to service " + name.ClassName;
            }

            System.Diagnostics.Debug.WriteLine(message);
        }

        public void OnServiceDisconnected(ComponentName name)
        {
            Toast.MakeText(Android.App.Application.Context, "PurgeServiceConnection.OnServiceDisconnected", ToastLength.Short).Show();
            System.Diagnostics.Debug.WriteLine($"OnServiceDisconnected {name.ClassName}");
            IsConnected = false;
            Messenger = null;
        }
    }

}
