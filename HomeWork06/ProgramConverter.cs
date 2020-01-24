using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork06
{
    public class ProgramConverter : IConvertible
    {
        public string ConvertToCSharp(string source) => source + " converted to C#";
        public string ConvertToVB(string source) => source + " converted to VB";
    }
}
