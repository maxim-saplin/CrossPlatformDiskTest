namespace Saplin.CPDT.UICore.ViewModels
{
    public class DriveDetailed
    {
        public char DisplayIndex { get; set; }
        public bool AvailableForTest { get; set; }
        public string Name { get; set; }
        public long BytesFree { get; set; }

        public double GbFree { get { return (double)BytesFree / 1024 / 1024 / 1024; } }
        public string IndexAndName { get { return string.Format("[{0}]   {1}", DisplayIndex, Name); } }

        public bool ShowDiveIsSameMessage { get; set; }
    }
}