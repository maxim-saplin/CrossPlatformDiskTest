using System.Collections.Generic;
using Android.App;
using Android.OS;
using Saplin.CPDT.UICore;
using Xamarin.Forms;

[assembly: Dependency(typeof(Saplin.CPDT.Droid.PlatformDrives))]
namespace Saplin.CPDT.Droid
{
    public class PlatformDrives  : IPlatformDrives
    {
        public IEnumerable<PlatformDrive> GetDrives()
        {
            var drives = new List<PlatformDrive>();

            var drive = new PlatformDrive();

            try
            {
                drive.AppFolderPath = MainActivity.Instance.FilesDir.AbsolutePath;
                InitDrive(drive, 3);
            }
            catch { drive.Accessible = false; }

            if (!string.IsNullOrEmpty(drive.Name)) drives.Add(drive);

            var ext = MainActivity.Instance.GetExternalFilesDirs(null);

            foreach (var e in ext)
            {
                 if (e == null) continue;

                drive = new PlatformDrive();

                try
                {

                    drive.AppFolderPath = e.AbsolutePath;
                    InitDrive(drive, 4);
                }
                catch { drive.Accessible = false; }

                if (!string.IsNullOrEmpty(drive.Name)) drives.Add(drive);
            }

            return drives;
        }

        private static void InitDrive(PlatformDrive drive, int dashesIncludeInName)
        {
            drive.Name = drive.AppFolderPath;
            var c = 0;
            var i = 0;
            for (i = 0; i < drive.Name.Length; i++) // extract '/data/user'
            {
                if (drive.Name[i] == '/') c++;
                if (c == dashesIncludeInName) break;
            }

            if (i < drive.Name.Length)
                drive.Name = drive.Name.Substring(0, i);

            var stats = new StatFs(drive.AppFolderPath);
            drive.BytesFree = stats.AvailableBlocksLong * stats.BlockSizeLong;
            drive.TotalBytes = stats.BlockCountLong * stats.BlockSizeLong;
        }
    }
}
