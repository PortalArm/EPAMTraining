using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GCDCalculation
{
    class Program
    {

        //[STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine(GCDHelper.GCD(5, 5));
            var renderer = new PictureBoxRenderer();
            renderer.SetDataLegend("GCD", "Efficient GCD");
            renderer.Render(TimeSpan.FromMilliseconds(5235), TimeSpan.FromMilliseconds(2313), Orientation.Vertical);
            Console.ReadKey();
            renderer.TerminateThread();
        }
    }
}
