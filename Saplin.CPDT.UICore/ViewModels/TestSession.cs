using System;
using System.Windows.Input;
using Saplin.StorageSpeedMeter;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.ViewModels
{
    public class TestSession : BaseViewModel
    {
        public DateTime TestStartedTime { get; set; }
        public string FileNameAndTime { get; set; }
        public string FileName { get; set; }
        public string DriveName { get; set; }
        public string CsvFileName { get; set; }
        public bool MemCache { get; set; }
        public bool WriteBuffering { get; set; }
        public long FileSizeBytes { get; set; }
        public long FreeSpaceBytes { get; set; }
        public long TotalSpaceBytes { get; set; }
        public int OrderNumber { get; set; }

        public string Options
        {
            get
            {
                var l11n = ViewModelContainer.L11n;

                return string.Format(l11n.TestSummaryFormatString,
                                 (((float)FileSizeBytes)/1024/1024/1024).ToString("0.0"),
                                 (double)FreeSpaceBytes/1024/1024/1024,
                                 WriteBuffering ? l11n.On : l11n.Off,
                                 MemCache ? l11n.On : l11n.Off);
            }
        }

        public string ShortOptions
        {
            get
            {
                var l11n = ViewModelContainer.L11n;

                return string.Format(l11n.TestSummaryShortFormatString,
                                 (((float)FileSizeBytes) / 1024 / 1024 / 1024).ToString("0.0"),
                                 (double)FreeSpaceBytes / 1024 / 1024 / 1024,
                                 WriteBuffering ? l11n.On : l11n.Off,
                                 MemCache ? l11n.On : l11n.Off);
            }
        }

        public double SeqRead
        {
			get; private set;
        }

        public double SeqWrite
        {
			get; private set;
        }

        public double RandRead
        {
            get; private set;
        }

        public double RandWrite
        {
            get; private set;
        }

        public double MemCopy
        {
            get; private set;
        }

        private bool selected;

        public bool Selected
        {
            get { return selected; }
            set
            {
                if (value != selected)
                {
                    selected = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(SelectedNodeText));

                    if (value)
                    {
                        ViewModelContainer.ResultsDbViewModel.PreLoadComparison(this);
                    }
                }
            }
        }

        public bool HideShare
        {
            get { return false; }
        }

        public string SelectedNodeText
        {
            get
            {
                //if (Selected) return "(-)";
                //return "(+)";

                if (Selected) return "   \n   \n  ↘";
                return "  →\n  →\n   ";

            }
        }

        private Command openCsvFolder;

        public ICommand OpenCsvFolder
        {
            get
            {
                return 
                    openCsvFolder ?? 
                    (openCsvFolder = 
                        new Command(
                            () =>
                            {
                                var srv = DependencyService.Get<IShellOpenFileFolder>() as IShellOpenFileFolder;
                                srv?.OpenContainingFolder(CsvFileName);
                            })
                     );
            }
        }

        public const long randBlockToShowInSum = 4096;

        public TestResultsDetailed[] results;

        public TestResultsDetailed[] Results
        {
            get
            {
                return results;
            }
            set
            {
                if (value != null && value.Length > 0)
                {
                    results = value;

                    for(var i = 0; i < value.Length; i++)
                    {
                        if (value[i].Result.TestType == typeof(Saplin.StorageSpeedMeter.SequentialWriteTest)) SeqWrite = value[i].Result.AvgThroughput;
                        else if (value[i].Result.TestType == typeof(Saplin.StorageSpeedMeter.SequentialReadTest)) SeqRead = value[i].Result.AvgThroughput;
                        else if (value[i].Result.TestType == typeof(Saplin.StorageSpeedMeter.RandomWriteTest) && value[i].Result.BlockSizeBytes == randBlockToShowInSum) RandWrite = value[i].Result.AvgThroughput;
                        else if (value[i].Result.TestType == typeof(Saplin.StorageSpeedMeter.RandomReadTest) && value[i].Result.BlockSizeBytes == randBlockToShowInSum) RandRead = value[i].Result.AvgThroughput;
                        else if (value[i].Result.TestType == typeof(Saplin.StorageSpeedMeter.MemCopyTest)) MemCopy = value[i].Result.AvgThroughput;
                    }
                }
            }
        }
    }

}
