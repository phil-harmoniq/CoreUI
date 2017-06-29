﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreUI.Drawing;
using CoreUI.Interface;
using CoreUI.Interop;

namespace CoreUI
{
    public class ColorPicker : Control
    {
        public event EventHandler ColorChanged;

        public ColorPicker()
        {
            handle = NativeMethods.NewColorButton();
            _color = new Color();
            InitializeEvents();
        }

        private Color _color;
        public Color Color
        {
            get
            {
                NativeMethods.ColorButtonColor(handle, out _color.R, out _color.G, out _color.B, out _color.A);
                return _color;
            }
            set
            {
                if (_color != value)
                {
                    NativeMethods.ColorButtonSetColor(handle, value.R, value.G, value.B, value.A);
                    _color = value;
                }
            }
        }

        protected  sealed override void InitializeEvents()
        {
            NativeMethods.ColorButtonOnChanged(handle, (button, data) =>
            {
                OnColorChanged(EventArgs.Empty);
            },IntPtr.Zero);
        }

        protected virtual void OnColorChanged(EventArgs e)
        {
            ColorChanged?.Invoke(this, e);
        }
    }
}
