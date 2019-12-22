using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Widget;

namespace Saplin.CPDT.Droid.CachePurger
{
    [Service(Name = "com.Saplin.CPDT.CachePurger", Process = ":com.Saplin.CPDT.CachePurger", Exported = false)]
    public class PurgeService : Service
    {
        static readonly string TAG = typeof(PurgeService).FullName;

        public const int purgeMemCode = 1;
        public const int breakCode = 1;

        private Messenger messenger;

        public override void OnCreate()
        {
            base.OnCreate();
            messenger = new Messenger(new PurheServiceHandler(this));
            Log.Debug(TAG, "OnCreate");
            Toast.MakeText(Android.App.Application.Context, "PurgeService.OnCreate", ToastLength.Short).Show();
        }

        public override IBinder OnBind(Intent intent)
        {
            Log.Debug(TAG, "OnBind");
            Toast.MakeText(Android.App.Application.Context, "PurgeService.OnBind", ToastLength.Short).Show();

            return messenger.Binder;
        }

        public override bool OnUnbind(Intent intent)
        {
            Log.Debug(TAG, "OnUnbind");
            return base.OnUnbind(intent);
        }

        public override void OnDestroy()
        {
            Log.Debug(TAG, "OnDestroy");
            //Binder = null;
            base.OnDestroy();
        }

        const long blockSize = 16 * 1024 * 1024;
        const long defaultMemCapacity = (long)128 * 1024 * 1024 * 1024;
        private volatile bool breakCalled = false;
        private readonly Random rand = new Random();

        public void PurgeMem()
        {
            var blocksInMemMax = defaultMemCapacity / blockSize;
            byte[] block = null;
            var blocks = new List<byte[]>();

            Log.Debug(TAG, "PurgeMem, blocks to be allocated "+ blocksInMemMax);

            for (var i = 0; i < blocksInMemMax - 3; i++)
            {
                if (breakCalled) return;
                //System.Diagnostics.Debug.WriteLine("AllockBlock: " + i);
                Log.Debug(TAG, "AllockBlock: " + i);

                block = AllocBlock();

                if (block != null) blocks.Add(block);
            }
        }

        private byte[] AllocBlock()
        {
            byte[] block = null;

            block = new byte[blockSize];

            if (breakCalled) return null;
            Array.Clear(block, 0, block.Length);

            var randN = (byte)rand.Next();

            if (breakCalled) return null;
            for (int i = 0; i < block.Length; i += 128)
                block[i] = randN++;

            return block;
        }
    }
}
