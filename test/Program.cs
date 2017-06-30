using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreUI.Drawing;

namespace CoreUI.SimpleSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = new Application(hiddenConsole: true);
            var window = new MainWindow("libui Control Gallery", 640, 480, true);
            window.AllowMargins = true;
            app.Run(window);
        }
    }
}
