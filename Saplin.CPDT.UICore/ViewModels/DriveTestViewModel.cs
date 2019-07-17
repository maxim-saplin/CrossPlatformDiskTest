using Saplin.CPDT.UICore.Misc;
using Saplin.StorageSpeedMeter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.ViewModels
{
    public class DriveTestViewModel : BaseViewModel
    {
        private string pickedDriveIndex;

        public string PickedDriveIndex
        {
            get { return pickedDriveIndex; }
            set
            {
                if (value != pickedDriveIndex)
                {
                    pickedDriveIndex = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DriveTestViewModel()
        {
            TestResults = new ObservableCollection<TestResultsDetailed>();

            InitDrives();

            ViewModelContainer.OptionsViewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(OptionsViewModel.FileSizeGb))
                {
                    RefreshDrives();
                }
            };

            ViewModelContainer.L11n.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(L11n._Locale))
                {
                    RaisePropertyChanged(nameof(StatusMessage));
                }
            };

            Device.StartTimer(
                new TimeSpan(0, 0, 7),
                () =>
                {
                    if (!TestStarted)
                    {

                        if (AtLeastOneDriveWithNotEnoughSpace)
                        {
                            StatusMessage = nameof(ViewModelContainer.L11n.CantTestNotEnough);
                        }
                        else
                        {
                            if (Device.RuntimePlatform == Device.Android)
                            {
                                StatusMessage = nameof(ViewModelContainer.L11n.HintAndroid);
                            }
                            else StatusMessage = nameof(ViewModelContainer.L11n.HintMisc);
                        }
                    }
                    return false;
                }
            );

        }

        private string firstAvailableDrive = null;

        private void InitDrives()
        {
            Action<DriveDetailed, int> setEnoughSpaceAndIndex = (DriveDetailed d, int i) =>
            {
                const int extraSpace = 512 * 1024 * 1024;
                d.EnoughSpace = d.BytesFree > FileSize + extraSpace;
                d.DisplayIndex = d.BytesFree > FileSize + extraSpace ? (i < 9 ? (i+1).ToString()[0] : '.') : ' ';

                if (!d.EnoughSpace) AtLeastOneDriveWithNotEnoughSpace = true;
            };

            try
            {
                availbleDrivesCount = 0;
                AtLeastOneDriveWithNotEnoughSpace = false;
                var i = 0;
                firstAvailableDrive = null;

                if (Device.RuntimePlatform == Device.Android)
                {

                    androidDrives = DependencyService.Get<IAndroidDrives>()?.GetDrives();

                    string prevDrive = "";

                    const string d1 = "/data/user";
                    const string d2 = "/storage/emulated/0";

                    foreach (var ad in androidDrives)
                    {
                        setEnoughSpaceAndIndex(ad, i);

                        if (ad.AvailableForTest)
                        {
                            availbleDrivesCount++;
                            if (firstAvailableDrive == null)
                            {
                                firstAvailableDrive = ad.Name;
                            }
                        }

                        i++;

                        if ( (prevDrive.Contains(d1) && ad.Name.Contains(d2)) || (prevDrive.Contains(d2) && ad.Name.Contains(d1))) ad.ShowDiveIsSameMessage = true;

                        prevDrive = ad.Name;
                    }
                }
                else
                {
                    var drives = new List<DriveDetailed>();

                    foreach (var d in RamDiskUtil.GetEligibleDrives())
                    {
                        var dd = new DriveDetailed();

                        dd.Name = d.Name;

                        long size = -1;
                        long free = -1;

                        try
                        {
                            free = d.TotalFreeSpace; // requesting disk size might throw access exceptions
                            size = d.TotalSize;
                        }
                        catch { dd.Accessible = false; }

                        
                        dd.BytesFree = free;
                        dd.TotalBytes = size;

                        setEnoughSpaceAndIndex(dd, i);

                        if (dd.AvailableForTest)
                        {
                            availbleDrivesCount++;
                            if (firstAvailableDrive == null)
                            {
                                firstAvailableDrive = dd.Name;
                            }
                        }

                        i++;

                        drives.Add(dd);

                        this.posixDrives = drives;
                    }
                }
            }
            catch (Exception ex)
            {
                ViewModelContainer.ErrorViewModel.DoShow(ViewModelContainer.L11n.InitDrivesError, ex);
            }
        }

        public void RefreshDrives()
        {
            InitDrives();
            RaisePropertyChanged(nameof(Drives));
        }

        private IEnumerable<AndroidDrive> androidDrives = null;
        private IEnumerable<DriveDetailed> posixDrives = null;
        private int availbleDrivesCount = 0;

        public IEnumerable<DriveDetailed> Drives
        {
            get
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    if (androidDrives == null) InitDrives();

                    return androidDrives;
                }
                else
                {
                    if (posixDrives == null) InitDrives();

                    return posixDrives;
                }
            }
        }

        public int AvailableDrivesCount { get { return availbleDrivesCount; } }
        public bool AtLeastOneDriveWithNotEnoughSpace { get; protected set; }

        private string statusMessage;

        public string StatusMessage
        {
            get { return string.IsNullOrEmpty(statusMessage) ? "" : ViewModelContainer.L11n[statusMessage]; }
            set
            {
                if (statusMessage != value)
                {
                    statusMessage = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(StatusMessageVisible));
                }
            }
        }

        public bool StatusMessageVisible
        {
            get
            {
                return !string.IsNullOrEmpty(StatusMessage) && !TestStarted;
            }
        }

        private string fileNameAndTime;

        public string FileNameAndTime
        {
            get { return fileNameAndTime; }
            set
            {
                if (fileNameAndTime != value)
                {
                    fileNameAndTime = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set
            {
                if (fileName != value)
                {
                    fileName = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string selectedDrive;

        public string SelectedDrive
        {
            get { return selectedDrive; }
            set
            {
                if (selectedDrive != value)
                {
                    selectedDrive = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string options;

        public string Options
        {
            get { return options; }
            set
            {
                if (options != value)
                {
                    options = value;
                    RaisePropertyChanged();
                }
            }
        }

        private DateTime testStartedTime;

        public DateTime TestStartedTime
        {
            get { return testStartedTime; }
            set
            {
                if (testStartedTime != value)
                {
                    testStartedTime = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(StatusMessageVisible));
                }
            }
        }

        private bool testStarted;

        public bool TestStarted
        {
            get { return testStarted; }
            set
            {
                if (testStarted != value)
                {
                    testStarted = value;
                    RaisePropertyChanged();
                }
            }
        }

        public long FileSize
        {
            get { return ViewModelContainer.OptionsViewModel.FileSizeBytes; }
        }

        private BigTest testSuite;

        public ObservableCollection<TestResultsDetailed> TestResults
        {
            get; private set;
        }

        private string GetPathToDrive(string driveNameOrIndex) // drive index can be used
        {
            char? fromDriveIndex = null;

            if (driveNameOrIndex.Length == 1 && driveNameOrIndex[0] > '0' && driveNameOrIndex[0] <= '9') // most likely drive index used
            {
                foreach (var d in Drives)
                    if (d.DisplayIndex == driveNameOrIndex[0])
                    {
                        fromDriveIndex = d.DisplayIndex;
                        return d.Name;
                    }
            }

            return driveNameOrIndex;
        }

        const string testResultsFolder = "CPDT_TestResults";

        ICommand quickTestDrive;

        private bool quickTest = false;

        public ICommand QuickTestDrive
        {
            get
            {
                return quickTestDrive != null ? quickTestDrive :
                    quickTestDrive = new Command(() =>
                    {
                        quickTest = true;
                        if (!string.IsNullOrEmpty(firstAvailableDrive)) TestDrive.Execute(firstAvailableDrive);   
                    });
            }
        }

        private ICommand testDrive;

        public ICommand TestDrive
        {
            get
            {
                if (testDrive == null)
                    testDrive = new ErrorHandlingCommand(

                        execute: (driveNameOrIndex) =>

                         {
                             if (testStarted) return;

                             if (!quickTest) ViewModelContainer.ResultsDbViewModel.SendPageHit("test");
                             else ViewModelContainer.ResultsDbViewModel.SendPageHit("quickTest");
                             quickTest = false;

                             DependencyService.Get<IKeepScreenOn>()?.Enable();
                             TestStarted = true;
                             TestStartedTime = DateTime.Now;
                             TestResults.Clear();
                             string driveNameToUse = null;

                             driveNameToUse = GetPathToDrive(driveNameOrIndex as string);
                             SelectedDrive = driveNameToUse;
                             var testNumber = 1;

                             var optionsVm = ViewModelContainer.OptionsViewModel;
                             var l11n = ViewModelContainer.L11n;

                             StatusMessage = nameof(l11n.TestStarted);

                             var memCache = optionsVm.MemCacheBool
                                ? MemCacheOptions.Enabled
                                : Device.RuntimePlatform == Device.Android ? MemCacheOptions.DisabledEmulation : MemCacheOptions.Disabled;

                             long freeSpace = 0;
                             long totalSpace = 0;

                             string androidCachePurgeFile = null;

                             if (Device.RuntimePlatform == Device.Android)
                             {
                                 foreach (var ad in androidDrives)
                                     if (ad.Name == driveNameToUse)
                                     {
                                         driveNameToUse = ad.AppFolderPath;
                                         freeSpace = ad.BytesFree;
                                         totalSpace = ad.TotalBytes;
                                     }

                                 androidCachePurgeFile = Path.Combine(androidDrives.First<AndroidDrive>().AppFolderPath, "CPDT_CachePurging.dat");
                             }
                             else {
                                 var dd = posixDrives.Where(d => d.Name == driveNameToUse).First();
                                 freeSpace = dd.BytesFree;
                                 totalSpace = dd.TotalBytes;
                             }

                             var freeMemService = DependencyService.Get<IFreeMemory>();
                             var flushService = DependencyService.Get<IFileSync>();
                             var diService = DependencyService.Get<IDeviceInfo>();

                             testSuite = new BigTest(
                                driveNameToUse,
                                optionsVm.FileSizeBytes,
                                //optionsVm.FileSizeBytes/64, 
                                optionsVm.WriteBufferingBool, 
                                memCache, 
                                purgingFilePath: androidCachePurgeFile,
                                freeMem: freeMemService == null ? null : (Func<long>)(freeMemService.GetBytesFree),
                                totalMem: diService == null ? -1 : (long)(diService.GetRamSizeGb()*1024*1024*1024),
                                flusher: flushService == null ? null : 
                                    new WriteBufferFlusher(flushService.OpenFile, flushService.Flush, flushService.Close),
                                mockFileStream: false
                            );

                             TotalTests = testSuite.TotalTests;

                             FileNameAndTime = testSuite.FilePath+", "+string.Format("{0:HH:mm:ss} {0:d.MM.yyyy}", TestStartedTime);
                             FileName = testSuite.FilePath;
                             Options = string.Format(
                                 ViewModelContainer.NavigationViewModel.IsNarrowView ? l11n.TestSummaryShortFormatString : l11n.TestSummaryFormatString,
                                 optionsVm.FileSizeGb,
                                 (double)freeSpace/1024/1024/1024,
                                 optionsVm.WriteBufferingBool ? l11n.On : l11n.Off,
                                 optionsVm.MemCacheBool ? l11n.On : l11n.Off);

                             var testSession = new TestSession
                             {
                                 TestStartedTime = TestStartedTime,
                                 FileNameAndTime = FileNameAndTime,
                                 FileName = FileName,
                                 DriveName = SelectedDrive,
                                 FileSizeBytes = optionsVm.FileSizeBytes,
                                 FreeSpaceBytes = freeSpace,
                                 TotalSpaceBytes = totalSpace,
                                 MemCache = optionsVm.MemCacheBool,
                                 WriteBuffering = optionsVm.WriteBufferingBool
                             };

                             testSuite.StatusUpdate += (sender, e) =>
                             {
                                 if (!testStartedInternal || e.Status == TestStatus.NotStarted || e.Status == TestStatus.Interrupted || breakingTest) return;
                                 var test = (sender as Test);

                                 Device.BeginInvokeOnMainThread(() =>
                                 {
                                     switch (e.Status)
                                     {
                                         case TestStatus.Started:
                                             ShowTestStatusMessage = ShowTestProgress = true;
                                             ShowCurrentSpeed = false;

                                             ShowTimeSeries = sender is SequentialTest || sender is MemCopyTest;
                                             SeqTotalBlocks = sender is SequentialTest ? (int)(sender as SequentialTest).TotalBlocks :
                                                                sender is MemCopyTest ? (int)(sender as MemCopyTest).TotalBlocks : -1;
                                             SmoothTimeSeries = sender is MemCopyTest;

                                             TestStatusMessage = l11n.TestStarted;
                                             CurrentTest = test.Name;
                                             BlockSizeBytes = test.BlockSizeBytes;
                                             break;
                                         case TestStatus.InitMemBuffer:
                                             TestStatusMessage = l11n.TestInitMemBuffer;
                                             break;
                                         case TestStatus.PurgingMemCache:
                                             TestStatusMessage = l11n.TestPurgingMemCache;
                                             break;
                                         case TestStatus.NotEnoughMemory:
                                             TestStatusMessage = l11n.TestNotEnoughMemory;
                                             TestResults.Add(new TestResultsDetailed(e.Results, true) { BulletPoint = (TestResults.Count + 1).ToString() });
                                             break;
                                         case TestStatus.WarmigUp:
                                             TestStatusMessage = l11n.TestWarmigUp;
                                             break;
                                         case TestStatus.Running:
                                             ShowTestStatusMessage = false;
                                             ShowCurrentSpeed = true;
                                             if (e.RecentResult.HasValue) RecentResultMbps = e.RecentResult.Value;
                                             if (e.ProgressPercent.HasValue) ProgressPercent = e.ProgressPercent;
                                             if (e.Results != RecentResults) RecentResults = e.Results;
                                             break;
                                         case TestStatus.Completed:
                                             if (CurrentTestNumber == testSuite.TotalTests || testSuite.TotalTests == 0 /**already disposed*/) ShowTestProgress = false; // last test
                                             RecentResults = null;
                                             ProgressPercent = 0;

                                             ShowTimeSeries = false;

                                             if (e.Results != null)
                                             {
                                                 var bullet = "*";
                                                 if (!(e.Results.BlockSizeBytes != TestSession.randBlockToShowInSum && sender is RandomTest))
                                                     bullet = (testNumber++).ToString();

                                                 Device.BeginInvokeOnMainThread(() => // Make the update latter, so the footer is hidden first
                                                 {
                                                     TestResults.Add(new TestResultsDetailed(e.Results) { BulletPoint = bullet });
                                                 });
                                             }

                                             break;
                                     }
                                 }
                                );
                             };

                             var t = Task.Run(() =>
                                 {
                                     testStartedInternal = true;

                                     using (testSuite)
                                     {
                                         testSuite.Execute();

                                         if (optionsVm.CsvBool && !breakingTest)
                                         {
                                             testSession.CsvFileName = testSuite.ExportToCsv(Path.Combine(testSuite.FileFolderPath, testResultsFolder), true, testSession.TestStartedTime)[0];
                                         }
                                     }

                                     testStartedInternal = false;

                                     Device.BeginInvokeOnMainThread(() =>
                                        {
                                            if (!breakingTest)
                                            {
                                                Options = "";

                                                testSession.Results = TestResults.ToArray();

                                                ViewModelContainer.TestSessionsViewModel.Add(testSession);

                                                if (optionsVm.CsvBool)
                                                {
                                                    StatusMessage = nameof(l11n.StatusTestCsvCompleted);
                                                }
                                                else StatusMessage = nameof(l11n.StatusTestCompleted);
                                            }
                                            else
                                            {
                                                StatusMessage = nameof(l11n.StatusTestInterrupted);
                                                breakingTest = false;
                                            }
                                            TestStarted = false;
                                            DependencyService.Get<IKeepScreenOn>()?.Disable();
                                        }
                                    );
                                 }
                             );
                         },

                        fallBack: () =>

                        {
                            TestStarted = false;
                            testSuite?.Dispose();
                            StatusMessage = nameof(ViewModelContainer.L11n.StatusTestError);
                            DependencyService.Get<IKeepScreenOn>()?.Disable();
                        }
                );

                return testDrive;
            }
        }

        private volatile bool testStartedInternal;
        private bool breakingTest = false;

        private ICommand breakTest;
        public ICommand BreakTest
        {
            get
            {
                if (breakTest == null)
                    breakTest = new Command(() =>
                        {
                            if (testStartedInternal)
                            {
                                StatusMessage = nameof(ViewModelContainer.L11n.StatusBreakingTest);
                                ShowTestStatusMessage = true;
                                ShowCurrentSpeed = false;
                                TestStatusMessage = StatusMessage;

                                breakingTest = true;

                                try // There're seldom exceptions registered in Android Vitals with no apparent reason. JIC making them silent
                                {
                                    testSuite.Break();
                                }
                                catch { }

                                ViewModelContainer.ResultsDbViewModel.SendPageHit("breakTest");
                            }
                        });

                return breakTest;
            }
        }

        private string currentTest = nameof(L11n.SequentialWriteTest);

        public string CurrentTest
        {
            get => currentTest;
            set
            {
                if (value != currentTest)
                {
                    currentTest = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string testStatusMessage;

        public string TestStatusMessage
        {
            get => testStatusMessage;
            set
            {
                if (value != testStatusMessage)
                {
                    testStatusMessage = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool showTestStatusMessage = true;

        public bool ShowTestStatusMessage
        {
            get => showTestStatusMessage;
            set
            {
                if (value != showTestStatusMessage)
                {
                    showTestStatusMessage = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool showTestProgress = true;

        public bool ShowTestProgress
        {
            get => showTestProgress;
            set
            {
                if (value != showTestProgress)
                {
                    showTestProgress = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool showCurrentSpeed = true;

        public bool ShowCurrentSpeed
        {
            get => showCurrentSpeed;
            set
            {
                if (value != showCurrentSpeed)
                {
                    showCurrentSpeed = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool showTimeSeries= false;

        public bool ShowTimeSeries
        {
            get => showTimeSeries;
            set
            {
                if (value != showTimeSeries)
                {
                    showTimeSeries = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool smoothTimeSeries = false;

        public bool SmoothTimeSeries
        {
            get => smoothTimeSeries;
            set
            {
                if (value != smoothTimeSeries)
                {
                    smoothTimeSeries = value;
                    RaisePropertyChanged();
                }
            }
        }

        private double? progressPercent = 100;

        public double? ProgressPercent
        {
            get => progressPercent;
            set
            {
                if (value != progressPercent)
                {
                    progressPercent = value;
                    RaisePropertyChanged();
                }
            }
        }

        private double recentResultMbps = 8888.88 * 1024; // set defau;lt value to all 8s to display at first start and have siz eof label defined automatically

        public double RecentResultMbps
        {
            get => recentResultMbps;
            set
            {
                if (value != recentResultMbps)
                {
                    recentResultMbps = value;
                    RaisePropertyChanged();
                }
            }
        }

        private Saplin.StorageSpeedMeter.TestResults recentResults = null;

        public Saplin.StorageSpeedMeter.TestResults RecentResults
        {
            get => recentResults;
            set
            {
                if (value != recentResults)
                {
                    recentResults = value;
                    RaisePropertyChanged();
                }
            }
        }

        private long blockSizeBytes;

        public long BlockSizeBytes
        {
            get => blockSizeBytes;
            set
            {
                if (value != blockSizeBytes)
                {
                    blockSizeBytes = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int seqTotalBlocks = -1;

        public int SeqTotalBlocks
        {
            get => seqTotalBlocks;
            set
            {
                if (value != seqTotalBlocks)
                {
                    seqTotalBlocks = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int CurrentTestNumber
        {
            get
            {
                return Math.Min(TestResults.Count + 1,TotalTests);
            }
        }

        public int TotalTests
        {
            get; private set;
        }
    }
}