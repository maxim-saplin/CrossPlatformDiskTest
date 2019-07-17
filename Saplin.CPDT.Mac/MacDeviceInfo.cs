using System;
using System.Runtime.InteropServices;
using ObjCRuntime;
using Saplin.CPDT.UICore.Misc;
using Xamarin.Forms;

[assembly: Dependency(typeof(Saplin.CPDT.Mac.MacDeviceInfo))]
namespace Saplin.CPDT.Mac
{
    public class MacDeviceInfo : IDeviceInfo
    {
        [DllImport(Constants.SystemLibrary)]
        static internal extern int sysctlbyname([MarshalAs(UnmanagedType.LPStr)] string property, IntPtr output, IntPtr oldLen, IntPtr newp, uint newlen);

        private string cpu = null;
        private string model = null;
        private float? ram = null;

        public bool IsChromeOs => false;

        public string GetCPU()
        {
            if (cpu == null)
            {
                cpu = "";
                try
                {
                    var pLen = Marshal.AllocHGlobal(sizeof(int));
                    sysctlbyname("machdep.cpu.brand_string", IntPtr.Zero, pLen, IntPtr.Zero, 0);
                    var length = Marshal.ReadInt32(pLen);
                    var pStr = Marshal.AllocHGlobal(length);
                    sysctlbyname("machdep.cpu.brand_string", pStr, pLen, IntPtr.Zero, 0);
                    cpu = Marshal.PtrToStringAnsi(pStr);
                }
                catch { };
            }

            return cpu;
        }

        public string GetModelName()
        {
            if (model == null)
            {
                model = "";
                try
                {
                    var pLen = Marshal.AllocHGlobal(sizeof(int));
                    sysctlbyname("hw.model", IntPtr.Zero, pLen, IntPtr.Zero, 0);
                    var length = Marshal.ReadInt32(pLen);
                    var pStr = Marshal.AllocHGlobal(length);
                    sysctlbyname("hw.model", pStr, pLen, IntPtr.Zero, 0);
                    model = Marshal.PtrToStringAnsi(pStr);
                }
                catch { };
            }

            return model;
        }

        public float GetRamSizeGb()
        {
            if (ram == null)
            {
                ram = -1;
                try
                {
                    var pLen = Marshal.AllocHGlobal(sizeof(int));
                    sysctlbyname("hw.memsize", IntPtr.Zero, pLen, IntPtr.Zero, 0);
                    var length = Marshal.ReadInt32(pLen);
                    var pStr = Marshal.AllocHGlobal(length);
                    sysctlbyname("hw.memsize", pStr, pLen, IntPtr.Zero, 0);

                    if (length == 4)
                    {
                        var mem = Marshal.ReadInt32(pStr);
                        ram = (float)mem / 1024 / 1024 / 1024;
                    }
                    else if (length == 8)
                    {
                        var mem = Marshal.ReadInt64(pStr);
                        ram = (float)mem / 1024 / 1024 / 1024;
                    }

                }
                catch { };
            }

            return ram.Value;
        }
    }
}
