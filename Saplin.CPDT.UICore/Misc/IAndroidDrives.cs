using System.Collections.Generic;


namespace Saplin.CPDT.UICore
{
    public interface IAndroidDrives
    {
        IEnumerable<AndroidDrive> GetDrives();
    }
}
