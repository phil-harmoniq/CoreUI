﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreUI.Interface;
using CoreUI.Interop;

namespace CoreUI
{
    public class Grid : ContainerControl<GridItemCollection, Grid>
    {
        public Grid()
        {
            handle = NativeMethods.NewGrid();
        }

        private bool _allowPadding;
        public bool AllowPadding
        {
            get
            {
                _allowPadding = NativeMethods.GridPadded(handle);
                return _allowPadding;
            }
            set
            {
                if (_allowPadding != value)
                {
                    NativeMethods.GridSetPadded(handle, value);
                    _allowPadding = value;
                }
            }
        }
    }

    public class GridItemCollection : ControlCollection<Grid>
    {
        public GridItemCollection(Grid uiParent) : base(uiParent)
        {
        }

        public override void Add(Control item)
        {
            Add(item, 0, 0, 0, 0, 0, HorizontalAlignment.Stretch, 0, VerticalAlignment.Stretch);
        }

        public virtual void Add(Control item, int left, int top, int xspan, int yspan, int hexpand,
            HorizontalAlignment halign, int vexpand, VerticalAlignment valign)
        {
            if (this.Contains(item))
            {
                throw new InvalidOperationException("cannot add the same control.");
            }
            if (item == null) return;
            NativeMethods.GridAppend(Owner.handle, item.handle, left, top, xspan, yspan, hexpand, halign, vexpand, valign);
            base.Add(item);
        }

        private new void Insert(int index, Control item)
        {
            
        }

        public virtual void Insert(Control item, Control existui,GridEdge at, int xspan, int yspan, int hexpand, HorizontalAlignment halign, int vexpand, VerticalAlignment valign)
        {
            NativeMethods.GridInsertAt(Owner.handle, item.handle, existui.handle, at, xspan, yspan, hexpand, halign, vexpand, valign);
            base.Insert(existui.Index, item);
        }
    }
}
