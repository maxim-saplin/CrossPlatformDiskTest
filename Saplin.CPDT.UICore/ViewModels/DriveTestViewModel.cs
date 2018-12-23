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
                        if (Device.RuntimePlatform == Device.Android)
                        {
                            StatusMessage = nameof(ViewModelContainer.L11n.HintAndroid);
                        }
                        else StatusMessage = nameof(ViewModelContainer.L11n.HintMisc);
                    }
                    return false;
                }
            );

        }

        private void InitDrives()
        {
            Action<DriveDetailed, int> setAvailableAndIndex = (DriveDetailed d, int i) =>
            {
                const int extraSpace = 512 * 1024 * 1024;
                d.AvailableForTest = d.BytesFree > FileSize + extraSpace;
                d.DisplayIndex = d.BytesFree > FileSize + extraSpace ? (i < 9 ? (i+1).ToString()[0] : '.') : ' ';
            };

            try
            {
                if (Device.RuntimePlatform == Device.Android)
                {

                    androidDrives = DependencyService.Get<IAndroidDrives>()?.GetDrives();

                    var i = 0;
                    long prevSize = -1;

                    foreach (var ad in androidDrives)
                    {
                        setAvailableAndIndex(ad, i);
                        i++;
                        if (ad.BytesFree == prevSize) ad.ShowDiveIsSameMessage = true;
                        prevSize = ad.BytesFree;
                    }
                }
                else
                {
                    var drives = new List<DriveDetailed>();

                    var i = 0;

                    foreach (var d in RamDiskUtil.GetEligibleDrives())
                    {
                        var dd = new DriveDetailed();

                        dd.Name = d.Name;

                        long size = -1;

                        try
                        {
                            size = d.TotalFreeSpace; // requesting disk size might throw access exceptions
                        }
                        catch { }

                        
                        dd.BytesFree = size;

                        setAvailableAndIndex(dd, i);
                        i++;

                        drives.Add(dd);

                        this.drives = drives;
                    }
                }
            }
            catch (Exception ex)
            {
                ViewModelContainer.ErrorViewModel.DoShow(ex);
            }
        }

        public void RefreshDrives()
        {
            InitDrives();
            RaisePropertyChanged(nameof(Drives));
        }

        private IEnumerable<AndroidDrive> androidDrives = null;
        private IEnumerable<DriveDetailed> drives = null;

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
                    if (drives == null) InitDrives();

                    return drives;
                }
            }
        }

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

        private string fileName;

        public string FileNameAndTime
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

        private string GetValidatedDriveName(string driveName) // drive index can be used
        {
            char? fromDriveIndex = null;

            if (driveName.Length == 1 && driveName[0] > '0' && driveName[0] <= '9') // most likely drive index used
            {
                foreach (var d in Drives)
                    if (d.DisplayIndex == driveName[0])
                    {
                        fromDriveIndex = d.DisplayIndex;
                        return d.Name;
                    }
            }

            return driveName;
        }

        private ICommand pickAndTestDrive;

        const string testResultsFolder = "CPDT_TestResults";

        public ICommand PickAndTestDrive
        {
            get
            {
                if (pickAndTestDrive == null)
                    pickAndTestDrive = new ErrorHandlingCommand(

                        execute: (driveName) =>

                         {
                             if (testStarted) return;

                             DependencyService.Get<IKeepScreenOn>()?.Enable();
                             TestStarted = true;
                             TestStartedTime = DateTime.Now;
                             TestResults.Clear();
                             string driveNameToUse = null;

                             driveNameToUse = GetValidatedDriveName(driveName as string);
                             SelectedDrive = driveNameToUse;
                             var testNumber = 1;

                             var optionsVm = ViewModelContainer.OptionsViewModel;
                             var l11n = ViewModelContainer.L11n;

                             StatusMessage = nameof(l11n.TestStarted);

                             var memCache = optionsVm.MemCacheBool
                                ? MemCacheOptions.Enabled
                                : Device.RuntimePlatform == Device.Android ? MemCacheOptions.DisabledEmulation : MemCacheOptions.Disabled;

                             long freeSpace = 0;

                             if (Device.RuntimePlatform == Device.Android)
                             {
                                 foreach (var ad in androidDrives)
                                     if (ad.Name == driveNameToUse)
                                     {
                                         driveNameToUse = ad.AppFolderPath;
                                         freeSpace = ad.BytesFree;
                                     }
                             }
                             else { freeSpace = drives.Where(d => d.Name == driveNameToUse).First().BytesFree; }

                             Func<long> freeMem = null;
                             var freeMemService = DependencyService.Get<IFreeMemory>();
                             if (freeMemService != null) freeMem = freeMemService.GetBytesFree;

                             testSuite = new BigTest(
                                driveNameToUse,
                                //optionsVm.FileSizeBytes,
                                optionsVm.FileSizeBytes/32, 
                                optionsVm.WriteBufferingBool, 
                                 memCache, 
                                freeMem: freeMem);

                             FileNameAndTime = testSuite.FilePath+", "+string.Format("{0:HH:mm:ss} {0:d.MM.yyyy}", TestStartedTime);
                             Options = string.Format(l11n.TestSummaryFormatString,
                                 optionsVm.FileSizeGb,
                                 (double)freeSpace/1024/1024/1024,
                                 optionsVm.WriteBufferingBool ? l11n.On : l11n.Off,
                                 optionsVm.MemCacheBool ? l11n.On : l11n.Off);

                             var testSession = new TestSession
                             {
                                 TestStartedTime = TestStartedTime,
                                 FileNameAndTime = FileNameAndTime,
                                 DriveName = SelectedDrive,
                                 FileSizeBytes = optionsVm.FileSizeBytes,
                                 FreeSpaceBytes = freeSpace,
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
                                             break;
                                         case TestStatus.Completed:
                                             if (CurrentTestNumber - 1 == testSuite.TotalTests || testSuite.TotalTests == 0 /**already disposed*/) ShowTestProgress = false; // last test
                                             if (e.Results != null)
                                             {
                                                 var bullet = "*";
                                                 if (!(e.Results.BlockSizeBytes != TestSession.randBlockToShowInSum && sender is RandomTest))
                                                     bullet = (testNumber++).ToString();

                                                 TestResults.Add(new TestResultsDetailed(e.Results) { BulletPoint = bullet });
                                                
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
                                             testSession.CsvFileName = testSuite.ExportToCsv(Path.Combine(testSuite.FileFolderPath, testResultsFolder), false, testSession.TestStartedTime)[0];
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

                return pickAndTestDrive;
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

                                testSuite.Break();
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

        public int CurrentTestNumber
        {
            get
            {
                return TestResults.Count + 1;
            }
        }
    }
}