using AppKit;
using Foundation;
using Saplin.CPDT.UICore;
using Xamarin.Forms;

[assembly: Dependency(typeof(Saplin.CPDT.Mac.ShellOpenFileFolder))]
namespace Saplin.CPDT.Mac
{
    public class ShellOpenFileFolder : IShellOpenFileFolder
    {
        public void OpenContainingFolder(string fileName)
        {
            NSUrl[] fileUrls = { NSUrl.FromFilename(fileName) };
            var ws = new NSWorkspace();
            ws.ActivateFileViewer(fileUrls);
        }
    }
}
