using Saplin.CPDT.UICore.ViewModels;

//Cope-Paste from generated resx helper class with properties converted from static to instance
//TODO - use T4 template for code generation
namespace Saplin.CPDT.UICore.Localization
{
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class L11nBase : BaseViewModel
    {

        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Globalization.CultureInfo resourceCulture;

        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Saplin.CPDT.UICore.Localization.L11ns", typeof(L11ns).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        public string this[string key]
        {
            get
            {
                return ResourceManager.GetString(key, resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to This application uses standard OS&apos;s file API (WinAPI on Windows, POSIX on Mac and NDK on Android) to measure the speed of data transfer (in Megabytes per Second) between storage device (HDD, SSD, USB flash drive) and system memory(RAM). API calls are done through .NET Framework/Mono..
        /// </summary>
        public string About1
        {
            get
            {
                return ResourceManager.GetString("About1", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Sequential read and sequential write tests transfer large chunks of data (megabytes) between RAM and Storage. These tests are representative of such disk operations as large file copying, video recording/encoding/decoding etc..
        /// </summary>
        public string About2
        {
            get
            {
                return ResourceManager.GetString("About2", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Random tests run for 7 seconds each and do transfers in small chunks (4KB and 32KB) at random positions within the test file. These tests show how file system performance influence applications&apos; load times, copying multiple small files, running database queries etc..
        /// </summary>
        public string About3
        {
            get
            {
                return ResourceManager.GetString("About3", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to In &apos;Options&apos; section you might find settings which may influence test results:.
        /// </summary>
        public string About4
        {
            get
            {
                return ResourceManager.GetString("About4", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to • Write buffering - influences write test. Write operations use intermediary memory buffer and postpone data commit to latter more convenient time for better performance at a cost of less resilient writes (e.g. power failure and not committing to disk write buffer contents)..
        /// </summary>
        public string About5
        {
            get
            {
                return ResourceManager.GetString("About5", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to • In-memory file cache - influences read tests. Any file operation requires from OS either transferring file data to memory or memory data to disk, OS will keep those memory pages in RAM until there&apos;s pressure for RAM from other apps. In case OS receives subsequent file read/write requests through API it will simply copy the cached memory pages from previous file operations and not utilize the actual storage device. Turning this option on is essential a test of OS&apos;s file caching subsystem and RAM speed, rat [rest of string was truncated]&quot;;.
        /// </summary>
        public string About6
        {
            get
            {
                return ResourceManager.GetString("About6", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Operations on computers and smartphones are executed by processor (CPU) against data which is loaded in system memory (RAM). This memory is not permanent and limited in size, that&apos;s why theres always a permanent storage (SSD, HDD, SD Card - aka &quot;disk/drive&quot;). In many cases the performance of the system is determined not only by CPU (which are usually in the spotlight of advertising and target of numerous benchmarks) but by the performance of memory, specifically RAM and storage. Official specs (especially w [rest of string was truncated]&quot;;.
        /// </summary>
        public string About7
        {
            get
            {
                return ResourceManager.GetString("About7", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to The application is open-source, you might want to check project&apos;s GitHub at:.
        /// </summary>
        public string About8
        {
            get
            {
                return ResourceManager.GetString("About8", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to You can download the app for different platforms (Windows, macOS, Android/APK) at the following link:.
        /// </summary>
        public string About9
        {
            get
            {
                return ResourceManager.GetString("About9", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to same drive, different aliases.
        /// </summary>
        public string AndroidSameAliases
        {
            get
            {
                return ResourceManager.GetString("AndroidSameAliases", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Available drives:.
        /// </summary>
        public string AvailableDrives
        {
            get
            {
                return ResourceManager.GetString("AvailableDrives", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to B.
        /// </summary>
        public string b
        {
            get
            {
                return ResourceManager.GetString("b", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to block.
        /// </summary>
        public string Block
        {
            get
            {
                return ResourceManager.GetString("Block", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to B/s.
        /// </summary>
        public string bps
        {
            get
            {
                return ResourceManager.GetString("bps", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to [Esc, B]reak test.
        /// </summary>
        public string BreakTest
        {
            get
            {
                return ResourceManager.GetString("BreakTest", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Close.
        /// </summary>
        public string CClose
        {
            get
            {
                return ResourceManager.GetString("CClose", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to [Esc, C]lose.
        /// </summary>
        public string Close
        {
            get
            {
                return ResourceManager.GetString("Close", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to [C]ompare.
        /// </summary>
        public string Compare
        {
            get
            {
                return ResourceManager.GetString("Compare", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to [E]xport test results to CSV.
        /// </summary>
        public string CsvOption
        {
            get
            {
                return ResourceManager.GetString("CsvOption", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to [D]atabase.
        /// </summary>
        public string Database
        {
            get
            {
                return ResourceManager.GetString("Database", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Results Database isn&apos;t available. Check internet connection.
        /// </summary>
        public string DbNotAvailable
        {
            get
            {
                return ResourceManager.GetString("DbNotAvailable", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to https://maxim-saplin.github.io/cpdt_results/?download=&amp;lang=en&amp;app=.
        /// </summary>
        public string DownloadLink
        {
            get
            {
                return ResourceManager.GetString("DownloadLink", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to [F]ile size:.
        /// </summary>
        public string FileSizeOption
        {
            get
            {
                return ResourceManager.GetString("FileSizeOption", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to GB.
        /// </summary>
        public string gb
        {
            get
            {
                return ResourceManager.GetString("gb", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to GB free.
        /// </summary>
        public string GbFree
        {
            get
            {
                return ResourceManager.GetString("GbFree", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to GB/s.
        /// </summary>
        public string gbps
        {
            get
            {
                return ResourceManager.GetString("gbps", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to [?, H]elp.
        /// </summary>
        public string HelpButton
        {
            get
            {
                return ResourceManager.GetString("HelpButton", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to To start tap on a drive in the list above.
        /// </summary>
        public string HintAndroid
        {
            get
            {
                return ResourceManager.GetString("HintAndroid", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to To start tests click on a drive in the list above or press number key.
        /// </summary>
        public string HintMisc
        {
            get
            {
                return ResourceManager.GetString("HintMisc", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to KB.
        /// </summary>
        public string kb
        {
            get
            {
                return ResourceManager.GetString("kb", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to KB/s.
        /// </summary>
        public string kbps
        {
            get
            {
                return ResourceManager.GetString("kbps", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to [L]anguage:.
        /// </summary>
        public string Language
        {
            get
            {
                return ResourceManager.GetString("Language", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Max.
        /// </summary>
        public string Max
        {
            get
            {
                return ResourceManager.GetString("Max", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to MB.
        /// </summary>
        public string mb
        {
            get
            {
                return ResourceManager.GetString("mb", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to MB/s.
        /// </summary>
        public string mbps
        {
            get
            {
                return ResourceManager.GetString("mbps", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to In-[m]emory file cache:.
        /// </summary>
        public string MemCacheOption
        {
            get
            {
                return ResourceManager.GetString("MemCacheOption", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Memory copy.
        /// </summary>
        public string MemCopyTest
        {
            get
            {
                return ResourceManager.GetString("MemCopyTest", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Mem.
        ///copy.
        /// </summary>
        public string MemCopyTestShort
        {
            get
            {
                return ResourceManager.GetString("MemCopyTestShort", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Mem. copy.
        /// </summary>
        public string MemCopyTestShortNB
        {
            get
            {
                return ResourceManager.GetString("MemCopyTestShortNB", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Min.
        /// </summary>
        public string Min
        {
            get
            {
                return ResourceManager.GetString("Min", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to (Off).
        /// </summary>
        public string Off
        {
            get
            {
                return ResourceManager.GetString("Off", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to (On).
        /// </summary>
        public string On
        {
            get
            {
                return ResourceManager.GetString("On", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to [O]ptions.
        /// </summary>
        public string OptionsButton
        {
            get
            {
                return ResourceManager.GetString("OptionsButton", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to - pick any drive to run perofrmance test against it.
        /// </summary>
        public string PickDrive
        {
            get
            {
                return ResourceManager.GetString("PickDrive", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to https://github.com/maxim-saplin/CrossPlatformDiskTest.
        /// </summary>
        public string ProjectLink
        {
            get
            {
                return ResourceManager.GetString("ProjectLink", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to [Q]uit.
        /// </summary>
        public string Quit
        {
            get
            {
                return ResourceManager.GetString("Quit", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Terminating application....
        /// </summary>
        public string Quiting
        {
            get
            {
                return ResourceManager.GetString("Quiting", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Random read.
        /// </summary>
        public string RandomReadTest
        {
            get
            {
                return ResourceManager.GetString("RandomReadTest", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Rand.
        ///read.
        /// </summary>
        public string RandomReadTestShort
        {
            get
            {
                return ResourceManager.GetString("RandomReadTestShort", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Rand. read.
        /// </summary>
        public string RandomReadTestShortNB
        {
            get
            {
                return ResourceManager.GetString("RandomReadTestShortNB", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Random write.
        /// </summary>
        public string RandomWriteTest
        {
            get
            {
                return ResourceManager.GetString("RandomWriteTest", resourceCulture);
            }
        }

        public string Share
        {
            get
            {
                return ResourceManager.GetString("Share", resourceCulture);
            }
        }

        public string ShareTitle
        {
            get
            {
                return ResourceManager.GetString("ShareTitle", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Rand.
        ///write.
        /// </summary>
        public string RandomWriteTestShort
        {
            get
            {
                return ResourceManager.GetString("RandomWriteTestShort", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Rand. write.
        /// </summary>
        public string RandomWriteTestShortNB
        {
            get
            {
                return ResourceManager.GetString("RandomWriteTestShortNB", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to [R]efresh.
        /// </summary>
        public string RefreshButton
        {
            get
            {
                return ResourceManager.GetString("RefreshButton", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Sequential read.
        /// </summary>
        public string SequentialReadTest
        {
            get
            {
                return ResourceManager.GetString("SequentialReadTest", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Seq.
        ///read.
        /// </summary>
        public string SequentialReadTestShort
        {
            get
            {
                return ResourceManager.GetString("SequentialReadTestShort", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Seq. read.
        /// </summary>
        public string SequentialReadTestShortNB
        {
            get
            {
                return ResourceManager.GetString("SequentialReadTestShortNB", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Sequential write.
        /// </summary>
        public string SequentialWriteTest
        {
            get
            {
                return ResourceManager.GetString("SequentialWriteTest", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Seq.
        ///write.
        /// </summary>
        public string SequentialWriteTestShort
        {
            get
            {
                return ResourceManager.GetString("SequentialWriteTestShort", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Seq. write.
        /// </summary>
        public string SequentialWriteTestShortNB
        {
            get
            {
                return ResourceManager.GetString("SequentialWriteTestShortNB", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to BREAKING TEST.
        /// </summary>
        public string StatusBreakingTest
        {
            get
            {
                return ResourceManager.GetString("StatusBreakingTest", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Test has completed execution. Test file deleted.
        /// </summary>
        public string StatusTestCompleted
        {
            get
            {
                return ResourceManager.GetString("StatusTestCompleted", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Test execution completed. Test results exported to CVS file.
        /// </summary>
        public string StatusTestCsvCompleted
        {
            get
            {
                return ResourceManager.GetString("StatusTestCsvCompleted", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Test execution interrupted due to error.
        /// </summary>
        public string StatusTestError
        {
            get
            {
                return ResourceManager.GetString("StatusTestError", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Test execution interrupted. Test file deleted.
        /// </summary>
        public string StatusTestInterrupted
        {
            get
            {
                return ResourceManager.GetString("StatusTestInterrupted", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Initializing test data in RAM....
        /// </summary>
        public string TestInitMemBuffer
        {
            get
            {
                return ResourceManager.GetString("TestInitMemBuffer", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Not enough memory.
        /// </summary>
        public string TestNotEnoughMemory
        {
            get
            {
                return ResourceManager.GetString("TestNotEnoughMemory", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Purging memory cache....
        /// </summary>
        public string TestPurgingMemCache
        {
            get
            {
                return ResourceManager.GetString("TestPurgingMemCache", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Running test....
        /// </summary>
        public string TestRunning
        {
            get
            {
                return ResourceManager.GetString("TestRunning", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Test started.
        /// </summary>
        public string TestStarted
        {
            get
            {
                return ResourceManager.GetString("TestStarted", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to File size: {0} GB. Free space: {1:0.0} GB. Write Buffering: {2}. In-memory file cache: {3}.
        /// </summary>
        public string TestSummaryFormatString
        {
            get
            {
                return ResourceManager.GetString("TestSummaryFormatString", resourceCulture);
            }
        }

        public string TestSummaryShortFormatString
        {
            get
            {
                return ResourceManager.GetString("TestSummaryShortFormatString", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Warming up....
        /// </summary>
        public string TestWarmigUp
        {
            get
            {
                return ResourceManager.GetString("TestWarmigUp", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to [W]hite theme (restart required).
        /// </summary>
        public string WhiteTheme
        {
            get
            {
                return ResourceManager.GetString("WhiteTheme", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Write [b]uffering:.
        /// </summary>
        public string WriteBufferingOption
        {
            get
            {
                return ResourceManager.GetString("WriteBufferingOption", resourceCulture);
            }
        }

        public string DownloadLinkShort
        {
            get
            {
                return ResourceManager.GetString("DownloadLinkShort", resourceCulture);
            }
        }

        public string ModeH
        {
            get
            {
                return ResourceManager.GetString("ModeH", resourceCulture);
            }
        }

        public string About10
        {
            get
            {
                return ResourceManager.GetString("About10", resourceCulture);
            }
        }

        public string SimpleUI_StartA
        {
            get
            {
                return ResourceManager.GetString("SimpleUI_StartA", resourceCulture);
            }
        }

        public string SimpleUI_Test
        {
            get
            {
                return ResourceManager.GetString("SimpleUI_Test", resourceCulture);
            }
        }

        public string SimpleUI_OrSee
        {
            get
            {
                return ResourceManager.GetString("SimpleUI_OrSee", resourceCulture);
            }
        }

        public string SimpleUI_More
        {
            get
            {
                return ResourceManager.GetString("SimpleUI_More", resourceCulture);
            }
        }

        public string SimpleUIOption
        {
            get
            {
                return ResourceManager.GetString("SimpleUIOption", resourceCulture);
            }
        }
    }
}
