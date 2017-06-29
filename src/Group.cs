﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreUI.Interop;
using CoreUI.Utils;

namespace CoreUI
{
    public class Group : Control
    {
        public Group(string title)
        {
            handle = NativeMethods.NewGroup(StringUtil.GetBytes(title));
        }

        public string Title
        {
            get { return StringUtil.GetString(NativeMethods.GroupTitle(handle)); }
            set { NativeMethods.GroupSetTitle(handle, StringUtil.GetBytes(value));}
        }

        public bool AllowMargins
        {
            get { return NativeMethods.GroupMargined(handle); }
            set { NativeMethods.GroupSetMargined(handle, value);}
        }

        private Control _child;
        public Control Child
        {
            get { return _child; }
            set
            {
                if (_child != value)
                {
                    NativeMethods.GroupSetChild(handle, value?.handle ?? IntPtr.Zero);
                    _child = value;
                }
            }
        }

        protected override void Destroy()
        {
            if (Child != null)
            {
                var child = Child;
                Child = null;
                child.Dispose(true);
            }
            base.Destroy();
        }
    }
}
