using System.ComponentModel;

namespace Saplin.CPDT.UICore.ViewModels
{
    public class DriveDetailed : BaseViewModel
    {
        public char DisplayIndex { get; set; }
        public bool AvailableForTest { get { return EnoughSpace && Accessible; } }
        public bool EnoughSpace { get; set; } = true;
        //public bool NotEnoughSpaceButAccessible => !EnoughSpace && Accessible;
        public bool Accessible { get; set; } = true; // there can be an exception while enumerating drive paths, e.g. due to lack of permissions
        public string Name { get; set; }
        public long BytesFree { get; set; }
        public long TotalBytes { get; set; }

        public double GbFree { get { return (double)BytesFree / 1024 / 1024 / 1024; } }
        public double GbTotal { get { return (double)TotalBytes / 1024 / 1024 / 1024; } }
        public string IndexAndName { get { return string.Format("[{0}]   {1}", DisplayIndex, Name); } }

        public bool ShowDiveIsSameMessage { get; set; }

        public DriveDetailed()
        {
            ViewModelContainer.L11n.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(ViewModelContainer.L11n._Locale))
                {
                    RaisePropertyChanged(nameof(HintText));
                }
            };
        }

        public string HintText
        {
            get
            {
                if (!Accessible)
                {
                    return ViewModelContainer.L11n.NotAccessibleDriveHint;
                }
                else
                {
                    var s = GbFree.ToString("0.00");
                    s += ViewModelContainer.L11n.GbFree;

                    if (!EnoughSpace) s += ", "+ ViewModelContainer.L11n.NotEnoughSpaceHint;

                    return s;
                }
            }
        }
    }
}