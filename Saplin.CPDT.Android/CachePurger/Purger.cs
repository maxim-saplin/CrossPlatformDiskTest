using System.Threading;
using Android.Content;
using Android.OS;
using Saplin.StorageSpeedMeter;

namespace Saplin.CPDT.Droid.CachePurger
{
    public class Purger : ICachePurger
    {
        private const int timeoutSeconds = 30;
        private const int connectionTimeoutMs = 900;
        private const int pollDelayMs = 100;
        private readonly Intent serviceToStart = new Intent(MainActivity.Instance, typeof(PurgeService));
        private readonly PurgeServiceConnection serviceConnection = new PurgeServiceConnection(MainActivity.Instance);

        public Purger()
        { 
            MainActivity.Instance.BindService(serviceToStart, serviceConnection, Bind.AutoCreate | Bind.Important);
        }

        public void Purge()
        {
            System.Diagnostics.Debug.WriteLine("Purger - starting");
            var sw = new System.Diagnostics.Stopwatch();

            if (!serviceConnection.IsConnected)
            {
                MainActivity.Instance.BindService(serviceToStart, serviceConnection, Bind.AutoCreate | Bind.Important);

            }

            if (serviceConnection.Messenger != null)
            {
                var msg = Message.Obtain(null, PurgeService.purgeMemCode);
                try
                {
                    serviceConnection.Messenger.Send(msg);
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

            sw.Restart();

            while (sw.ElapsedMilliseconds / 1000 < timeoutSeconds)
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

        public void Release()
        {
            throw new System.NotImplementedException();
        }
    }
}
