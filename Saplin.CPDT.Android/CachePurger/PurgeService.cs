using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public const int purgeMemAction = 1;
        public const int breakAction = 2;
        public const int resetAction = 3;

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

        public void Break()
        {
            Log.Debug(TAG, "Break");
            breakCalled = true;
        }

        public void Reset()
        {
            Log.Debug(TAG, "Reset");
            breakCalled = false;
        }

        private volatile bool breakCalled;

        public void PurgeMem()
        {
           Task.Run(() =>
           {
               //var blocksInMemMax = defaultMemCapacity / blockSize;
               //byte[] block = null;
               //var blocks = new List<byte[]>();

               const int blocks = 1024;

               Log.Debug(TAG, "PurgeMem, blocks to be allocated " + blocks);

               //for (var i = 0; i < blocksInMemMax; i++)
               //{
               //    if (breakCalled) break;
               //    Log.Debug(TAG, "AllockBlock: " + i);

               //    block = Common.AllocBlock();

               //    if (block != null) blocks.Add(block);
               //}

               Common.AllocNBlocks(blocks, () => breakCalled);
           });
        }

    }
}
