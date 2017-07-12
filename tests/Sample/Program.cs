using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreUI;

namespace Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = new Application();
            var window = new MainWindow("CoreUI - Test", 640, 480, true);
            window.AllowMargins = true;
            app.Run(window);
        }
    }
}
