namespace Saplin.CPDT.UICore.Misc
{
    public interface IDeviceInfo
    {
        string GetModelName();
        string GetCPU();
        float GetRamSizeGb();
    }
}
