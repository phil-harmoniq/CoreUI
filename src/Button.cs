using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreUI.Interface;
using CoreUI.Interop;
using CoreUI.Utils;
using System.Reflection;

namespace CoreUI
{
    public class Button : ButtonBase
    {
        public event EventHandler Click;

        public override string Text
        {
            get { return StringUtil.GetString(NativeMethods.ButtonText(handle)); }
            set { NativeMethods.ButtonSetText(handle, StringUtil.GetBytes(value));}
        }

        public Button(string text) : base(text)
        {
            /*var result = this.GetType().GetTypeInfo().IsSubclassOf(typeof(Button));
            if (!result)
            {
                ControlHandle = NativeMethods.NewButton(StringUtil.GetBytes(text));
                InitializeEvents();
            }*/
            handle = NativeMethods.NewButton(StringUtil.GetBytes(text));
            InitializeEvents();
        }

        protected sealed override void InitializeEvents()
        {
            NativeMethods.ButtonOnClicked(handle, (button, data) =>
            {
                OnClick(EventArgs.Empty);
            }, IntPtr.Zero);
        }

        protected virtual void OnClick(EventArgs e)
        {
            Click?.Invoke(this, e);
        }
    }
}
