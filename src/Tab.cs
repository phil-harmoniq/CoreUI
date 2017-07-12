﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreUI.Interface;
using CoreUI.Interop;
using CoreUI.Utils;

namespace CoreUI
{
    /// Selectable container for multiple Control children
    public class Tab : ContainerControl<TabPageCollection, Tab>
    {
        public Tab()
        {
            handle = NativeMethods.NewTab();
        }
    }

    public class TabPageCollection : ControlCollection<Tab>
    {
        public TabPageCollection(Tab uiParent) : base(uiParent)
        {
        }

        public override void Add(Control child)
        {
            var page = child as TabPage;
            if (page == null)
            {
                throw new ArgumentException("cannot only attach TabPage to Tab");
            }
            base.Add(child);
            NativeMethods.TabAppend(Owner.handle, StringUtil.GetBytes(page.Name), child.handle);
            child.DelayRender();
        }

        public override void Insert(int i, Control child)
        {
            var page = child as TabPage;
            if (page == null)
            {
                throw new ArgumentException("cannot only attach TabPage to Tab");
            }
            base.Insert(i, child);
            NativeMethods.TabInsertAt(Owner.handle, StringUtil.GetBytes(page.Name), i, child.handle);
            child.DelayRender();
        }

        public override bool Remove(Control item)
        {
            NativeMethods.TabDelete(Owner.handle, item.Index);
            return base.Remove(item);
        }
    }
}
