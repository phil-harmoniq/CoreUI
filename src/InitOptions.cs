using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CoreUI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InitOptions
    {
        public UIntPtr Size;
    }
}
