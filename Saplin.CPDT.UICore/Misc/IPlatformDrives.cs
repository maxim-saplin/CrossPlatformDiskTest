using System.Collections.Generic;


namespace Saplin.CPDT.UICore
{
    public interface IPlatformDrives
    {
        IEnumerable<PlatformDrive> GetDrives();
    }
}
