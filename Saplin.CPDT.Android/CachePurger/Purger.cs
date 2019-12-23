using Android.Content;
using Android.OS;
using Android.Widget;
using Java.Lang;
using Saplin.StorageSpeedMeter;

namespace Saplin.CPDT.Droid.CachePurger
{
    public class Purger : ICachePurger
    {
        private const int timeoutSeconds = 30000;
        private const int reconnectionTimeoutMs = 3000; // it took 2-3 secs to launch service on Nexus 5x
        private const int pollDelayMs = 100;
        private readonly Intent serviceToStart = new Intent(MainActivity.Instance, typeof(PurgeService));
        private static readonly PurgeServiceConnection serviceConnection = new PurgeServiceConnection(MainActivity.Instance);

        public Purger()
        { 
            MainActivity.Instance.BindService(serviceToStart, serviceConnection, Bind.AutoCreate);
        }

        /// <summary>
        /// !NEVER run on main thread
        /// </summary>
        public void Purge()
        {
            System.Diagnostics.Debug.WriteLine("Purger - starting");

            RestoreServiceConnection();

            System.Diagnostics.Debug.WriteLine("Purger - Running allocations");
            if (serviceConnection.Messenger != null)
            {
                try
                {
                    serviceConnection.Messenger.Send(Message.Obtain(null, PurgeService.resetAction));
                    serviceConnection.Messenger.Send(Message.Obtain(null, PurgeService.purgeMemAction));
                }
                catch (RemoteException ex)
                {
                    System.Diagnostics.Debug.WriteLine("Purger - Error sending message to PurgeService: " + ex.Message);
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Purger - No connection to PurgeService");
            }


            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            while (sw.ElapsedMilliseconds < timeoutSeconds)
            {
                if (!serviceConnection.IsConnected)
                {
                    System.Diagnostics.Debug.WriteLine("Purger - Connection to PurgeService lost, elapsed ms " + sw.ElapsedMilliseconds);
                    break;
                }

                Thread.Sleep(pollDelayMs);
            }

            sw.Stop();

            System.Diagnostics.Debug.WriteLine("Purger - done, elapsed ms " + sw.ElapsedMilliseconds);
        }

        public void Break()
        {
            System.Diagnostics.Debug.Write("Purger - Breaking");
            if (serviceConnection.Messenger != null)
            {
                try
                {
                    serviceConnection.Messenger.Send(Message.Obtain(null, PurgeService.breakAction));
                }
                catch (RemoteException ex)
                {
                    System.Diagnostics.Debug.WriteLine("Purger - Error sending message to PurgeService: " + ex.Message);
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Purger - No connection to PurgeService");
            }
            System.Diagnostics.Debug.WriteLine("... Done");

            Toast.MakeText(Android.App.Application.Context, "Purger.Break", ToastLength.Short).Show();
        }

        private void RestoreServiceConnection()
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            if (!serviceConnection.IsConnected)
            {
                System.Diagnostics.Debug.WriteLine("Purger - relaunching service, waiting for online status of the connection...");

                MainActivity.Instance.BindService(serviceToStart, serviceConnection, Bind.AutoCreate);

                while (sw.ElapsedMilliseconds < reconnectionTimeoutMs)
                {
                    if (serviceConnection.IsConnected)
                    {
                        System.Diagnostics.Debug.WriteLine("Purger - Connection elstblished, elapsed ms " + sw.ElapsedMilliseconds);
                        break;
                    }

                    Thread.Sleep(pollDelayMs);
                }

                if (!serviceConnection.IsConnected)
                    System.Diagnostics.Debug.WriteLine("Purger - Connection NOT elstblished, elapsed ms " + sw.ElapsedMilliseconds);
            }
        }

        public void Release()
        {
            throw new System.NotImplementedException();
        }
    }
}
