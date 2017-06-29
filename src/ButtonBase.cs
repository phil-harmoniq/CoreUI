using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreUI
{
    public abstract class ButtonBase : Control
    {
        public abstract string Text { get; set; }

        protected ButtonBase(string text)
        {
            
        }
    }
}
