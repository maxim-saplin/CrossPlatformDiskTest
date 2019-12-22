using Android.Util;
using Android.OS;
using Android.Content;

namespace Saplin.CPDT.Droid.CachePurger
{
    public class PurgeServiceConnection : Java.Lang.Object, IServiceConnection
    {
        static readonly string TAG = typeof(PurgeServiceConnection).FullName;

        MainActivity mainActivity;
        public PurgeServiceConnection(MainActivity activity)
        {
            IsConnected = false;
            //Binder = null;
            mainActivity = activity;
        }

        public bool IsConnected { get; private set; }
        //public PurgerServiceBinder Binder { get; private set; }
        public Messenger Messenger { get; private set; }

        public void OnServiceConnected(ComponentName name, IBinder service)
        {
            // = service as PurgerServiceBinder;

            Messenger = new Messenger(service);

            IsConnected = this.Messenger != null;

            string message = "onServiceConnected - ";

            //Log.Debug(TAG, $"OnServiceConnected {name.ClassName}");
            System.Diagnostics.Debug.WriteLine($"OnServiceConnected {name.ClassName}");

            if (IsConnected)
            {
                message = message + " bound to service " + name.ClassName;
            }
            else
            {
                message = message + " not bound to service " + name.ClassName;
            }

            //Log.Info(TAG, message);
            System.Diagnostics.Debug.WriteLine(message);

            //var msg = Message.Obtain(null, PurgeService.purgeMemCode);
            //try
            //{
            //    Messenger.Send(msg);
            //}
            //catch (RemoteException ex)
            //{
            //    System.Diagnostics.Debug.WriteLine("Purger - Error sending message to PurgeService: " + ex.Message);
            //}

        }

        public void OnServiceDisconnected(ComponentName name)
        {
            //Log.Debug(TAG, $"OnServiceDisconnected {name.ClassName}");
            System.Diagnostics.Debug.WriteLine($"OnServiceDisconnected {name.ClassName}");
            IsConnected = false;
            Messenger = null;
            //Binder = null;
            //mainActivity.UpdateUiForUnboundService();
        }

        //public bool PurgeMem()
        //{
        //    if (!IsConnected)
        //    {
        //        return false;
        //    }

        //    if (Messenger != null)
        //    { 
        //        Binder.PurgeMem();
        //        return true;
        //    }

        //    return false;
        //}
    }

}
