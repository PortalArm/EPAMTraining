using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorPolynomial
{
    interface ILoggable
    {
        Action<string> Logger { get; set; }
    }
}
