using System;
using Android.OS;

namespace Saplin.CPDT.Droid.CachePurger
{
    public class PurgeServiceHandler : Android.OS.Handler
    {
        WeakReference<PurgeService> serviceRef;

        public PurgeServiceHandler(PurgeService service) : base(Looper.MainLooper)
        {
            serviceRef = new WeakReference<PurgeService>(service);
        }

        PurgeService Service
        {
            get
            {
                PurgeService service;
                if (serviceRef.TryGetTarget(out service))
                {
                    return service;
                }
                return null;
            }
        }

        public override void HandleMessage(Message msg)
        {
            int messageType = msg.What;

            switch (messageType)
            {
                case PurgeService.purgeMemAction:
                    Service?.PurgeMem();
                    break;
                case PurgeService.resetAction:
                    Service?.Reset();
                    break;
                case PurgeService.breakAction:
                    Service?.Break();
                    break;
                default:
                    base.HandleMessage(msg);
                    break;
            }
        }
    }
}
