using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork06
{
    public interface IConvertible
    {
        string ConvertToCSharp(string source);
        string ConvertToVB(string source);
    }
}
