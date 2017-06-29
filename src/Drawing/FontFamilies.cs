using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreUI.Interface;
using CoreUI.Interop;
using CoreUI.Utils;

namespace CoreUI.Drawing
{
    public class FontFamilies
    {
        public IntPtr handle;

        public FontFamilies()
        {
            handle = NativeMethods.DrawListFontFamilies();
        }

        public int Count
        {
            get { return NativeMethods.DrawFontFamiliesNumFamilies(handle); }
        }

        public string this[int index]
        {
            get { return StringUtil.GetString(NativeMethods.DrawFontFamiliesFamily(handle, index)); }
        }

        public void Free()
        {
            NativeMethods.DrawFreeFontFamilies(handle);
        }
    }
}
