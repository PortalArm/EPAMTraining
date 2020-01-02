using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDCalculation
{
    public enum Orientation {Vertical, Horizontal }

    public interface IRenderer
    {
        void Render(TimeSpan first, TimeSpan second, Orientation orientation = Orientation.Vertical);
        void SetDataLegend(string firstName, string secondName);
    }
}
