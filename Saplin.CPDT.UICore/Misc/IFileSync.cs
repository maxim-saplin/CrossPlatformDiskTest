using System;
using System.Collections.Generic;
using System.Text;

namespace Saplin.CPDT.UICore.Misc
{
    public interface IFileSync
    {
        void OpenFile(string path);
        void Flush();
        void Close();
    }
}
