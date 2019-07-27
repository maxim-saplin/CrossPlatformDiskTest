using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using Saplin.CPDT.UICore;
using Xamarin.Forms;

[assembly: Dependency(typeof(Saplin.CPDT.iOS.iOSDrives))]
namespace Saplin.CPDT.iOS
{
    public class iOSDrives  : IPlatformDrives
    {
        public IEnumerable<PlatformDrive> GetDrives()
        {
            var drives = new List<PlatformDrive>();

            var drive = new PlatformDrive();

            try
            {
                drive.AppFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "tmp"); 
                InitDrive(drive, 3);
            }
            catch { drive.Accessible = false; }

            if (!string.IsNullOrEmpty(drive.Name)) drives.Add(drive);

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

            drive.BytesFree = (long)NSFileManager.DefaultManager.GetFileSystemAttributes(Environment.GetFolderPath(Environment.SpecialFolder.Personal)).Size;
            drive.TotalBytes = (long)NSFileManager.DefaultManager.GetFileSystemAttributes(Environment.GetFolderPath(Environment.SpecialFolder.Personal)).FreeSize;

        }
    }
}
