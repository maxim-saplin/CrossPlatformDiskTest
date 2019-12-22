using System;
using Android.OS;

namespace Saplin.CPDT.Droid.CachePurger
{
    public class PurheServiceHandler : Android.OS.Handler
    {
        WeakReference<PurgeService> serviceRef;

        public PurheServiceHandler(PurgeService service)
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
                case PurgeService.purgeMemCode:
                    Service?.PurgeMem();
                    break;
                default:
                    base.HandleMessage(msg);
                    break;
            }
        }
    }
}
