using Saplin.CPDT.UICore;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(Saplin.CPDT.WPF.ShellOpenFileFolder))]
namespace Saplin.CPDT.WPF
{
    public class ShellOpenFileFolder : IShellOpenFileFolder
    {
        public void OpenContainingFolder(string fileName)
        {
           //var folderPath = Path.GetDirectoryName(fileName);

            var startInfo = new ProcessStartInfo
            {
                Arguments = string.Format("/select,\"{0}\"", fileName),
                FileName = "explorer.exe"
            };

            Process.Start(startInfo);
        }
    }
}
