using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Android.Content;
using Android.OS;
using Java.Lang;
using Saplin.StorageSpeedMeter;
using Xamarin.Forms;

[assembly: Dependency(typeof(Saplin.CPDT.Droid.CachePurger.Purger))]
namespace Saplin.CPDT.Droid.CachePurger
{
    public class Purger : ICachePurger
    {
        const int filePurgeTimeMs = 7000;
        private const int serviceRunningTimeoutSeconds = 7000;
        private const int reconnectionTimeoutMs = 3000; // it took 2-3 secs to launch service on Nexus 5x
        private const int pollDelayMs = 100;
        const long blocksToWrite = 32;
        const long maxFileSize = Common.blockSize * 30;
        private Random rand = new Random();
        private readonly Intent serviceToStart = new Intent(MainActivity.Instance, typeof(PurgeService));
        private static readonly PurgeServiceConnection serviceConnection = new PurgeServiceConnection(MainActivity.Instance);
        private Func<bool> checkBreakCalled;
        private string cachePurgeFile;

        public Purger()
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop) // smth is wrong with KitKat, don't start the service
                MainActivity.Instance.BindService(serviceToStart, serviceConnection, Bind.AutoCreate);

            var appDir = MainActivity.Instance.GetExternalFilesDir(null);
            cachePurgeFile = Path.Combine(appDir.AbsolutePath, "CPDT_CachePurging.dat");
        }

        public void Purge()
        {
            System.Diagnostics.Debug.WriteLine("Purger - starting");
            try
            {
                Task t = null;

                if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop) t = Task.Run(() => SidePurgeInService());
                WriteDummyFile();

                t?.Wait();
            }
            catch{ }
        }

        private void WriteDummyFile()
        {
            if (checkBreakCalled()) return;

            Stream stream = null;

            try
            {
                stream = new FileStream(cachePurgeFile, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);

                var blocks = Common.AllocNBlocks(3);

                System.Diagnostics.Debug.WriteLine("Writign fake file");

                stream.Seek(0, SeekOrigin.Begin);
                long fileExtra = 0;
                var blockIndex = 0;

                if (blocks.Count > 0)
                {
                    var r = (byte)rand.Next();
                    var sw = new Stopwatch();
                    sw.Start();
                    for (int i = 0; i < blocksToWrite; i++)
                    {
                        if (checkBreakCalled() || sw.ElapsedMilliseconds > filePurgeTimeMs) { break; }

                        if (fileExtra >= maxFileSize)
                        {
                            stream.Seek(0, SeekOrigin.Begin);
                            fileExtra = 0;
                        }

                        if (blockIndex >= blocks.Count) blockIndex = 0;

                        for (int k = 0; k < blocks[blockIndex].Length; k += 256)
                            blocks[blockIndex][k] = r++;

                        stream.Write(blocks[blockIndex], 0, blocks[blockIndex].Length);

                        fileExtra += Common.blockSize;
                        blockIndex++;
                    }
                    sw.Stop();
                }
            }
            finally
            {
                if (!checkBreakCalled())
                {
                    if (!checkBreakCalled()) Thread.Sleep(321);
                }

                stream?.Close();
                File.Delete(cachePurgeFile);
            }
        }

        private void SidePurgeInService()
        {
            if (Android.OS.Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.Lollipop) return;

            if (checkBreakCalled()) return;

            RestoreServiceConnection();

            System.Diagnostics.Debug.WriteLine("Purger - Service - Running allocations");
            if (serviceConnection.Messenger != null)
            {
                try
                {
                    serviceConnection.Messenger.Send(Message.Obtain(null, PurgeService.resetAction));
                    serviceConnection.Messenger.Send(Message.Obtain(null, PurgeService.purgeMemAction));
                }
                catch (RemoteException ex)
                {
                    System.Diagnostics.Debug.WriteLine("Purger - Service - Error sending message to PurgeService: " + ex.Message);
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Purger - Service - No connection to PurgeService");
            }

            var sw = new Stopwatch();
            sw.Start();

            while (sw.ElapsedMilliseconds < serviceRunningTimeoutSeconds)
            {
                if (!serviceConnection.IsConnected)
                {
                    System.Diagnostics.Debug.WriteLine("Purger - Service - Connection to PurgeService lost, elapsed ms " + sw.ElapsedMilliseconds);
                    break;
                }

                if (checkBreakCalled())
                {
                    Break();
                    return;
                }
                Thread.Sleep(pollDelayMs);
            }

            System.Diagnostics.Debug.WriteLine("Purger - Service - done, Breaking as finalization " + sw.ElapsedMilliseconds);
            Break();

            sw.Stop();

            System.Diagnostics.Debug.WriteLine("Purger - Service - done, elapsed ms " + sw.ElapsedMilliseconds);
        }

        private void RestoreServiceConnection()
        {
            if (Android.OS.Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.Lollipop) return;

            var sw = new Stopwatch();
            sw.Start();

            if (!serviceConnection.IsConnected)
            {
                System.Diagnostics.Debug.WriteLine("Purger - Service - relaunching service, waiting for online status of the connection...");

                MainActivity.Instance.BindService(serviceToStart, serviceConnection, Bind.AutoCreate);

                while (sw.ElapsedMilliseconds < reconnectionTimeoutMs)
                {
                    if (serviceConnection.IsConnected)
                    {
                        System.Diagnostics.Debug.WriteLine("Purger - Service - Connection elstblished, elapsed ms " + sw.ElapsedMilliseconds);
                        break;
                    }

                    if (checkBreakCalled()) return;
                    Thread.Sleep(pollDelayMs);
                }

                if (!serviceConnection.IsConnected)
                    System.Diagnostics.Debug.WriteLine("Purger - Service - Connection NOT elstblished, elapsed ms " + sw.ElapsedMilliseconds);
            }
        }

        public void Break()
        {
            if (Android.OS.Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.Lollipop) return;

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

            //Toast.MakeText(Android.App.Application.Context, "Purger.Break", ToastLength.Short).Show();
        }

        public void SetBreackCheckFunc(Func<bool> checkBreakCalled)
        {
            this.checkBreakCalled = checkBreakCalled;
        }

        public void Release()
        {
            throw new System.NotImplementedException();
        }
    }
}
