namespace Saplin.CPDT.UICore.ViewModels
{
    public class TestResultsDetailed
    {
        public bool NotEnoughMemory
        { get; }

        public TestResultsDetailed(Saplin.StorageSpeedMeter.TestResults tr,  bool notEnoughMem = false)
        {
            Result = tr;
            NotEnoughMemory = notEnoughMem;
        }

        public Saplin.StorageSpeedMeter.TestResults Result
        {
            get; private set;
        }

        public string BulletPoint { get; set; }
    }
}
