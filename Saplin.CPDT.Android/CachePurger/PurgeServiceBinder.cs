using Android.OS;

namespace Saplin.CPDT.Droid.CachePurger
{
    public class PurgerServiceBinder : Binder
    {
        public PurgerServiceBinder(PurgeService service)
        {
            this.Service = service;
        }

        public PurgeService Service { get; private set; }

        public void PurgeMem()
        {
            Service?.PurgeMem();
        }
    }
}
