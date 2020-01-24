using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork06
{
    public interface ICodeChecker
    {
        bool CheckCodeSyntax(string source, Language lang);
    }
}
