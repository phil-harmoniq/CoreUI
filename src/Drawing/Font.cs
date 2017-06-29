using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CoreUI.Interface;
using CoreUI.Interop;

namespace CoreUI.Drawing
{
    public class Font
    {
        protected internal IntPtr handle { get; set; }

        public UIntPtr Handle
        {
            get { return NativeMethods.DrawTextFontHandle(handle); }
        }

        internal Font()
        {
        }

        public Font(FontDescriptor descriptor)
        {
            handle = NativeMethods.DrawLoadClosestFont(ref descriptor);
        }

        public void Free()
        {
            NativeMethods.DrawFreeTextFont(handle);
        }

        public FontDescriptor Describe
        {
            get
            {
                FontDescriptor value;
                NativeMethods.DrawTextFontDescribe(handle, out value);
                return value;
            }
        }

        public FontMetrics Metrics
        {
            get
            {
                FontMetrics value;
                NativeMethods.DrawTextFontGetMetrics(handle, out value);
                return value;
            }
        }
    }
}
