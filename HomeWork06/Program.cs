using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork06
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramConverter[] converters = {
                new ProgramConverter(),
                new ProgramHelper(),
                new ProgramHelper(),
                new ProgramConverter(),
                new ProgramHelper(),
                new ProgramConverter(),
            };

            foreach (ProgramConverter pc in converters)
            {
                if (pc is ICodeChecker)
                    Console.WriteLine((pc as ICodeChecker).CheckCodeSyntax("Console.WriteLine(\"haha\")", Language.CSharp));
                else
                {
                    Console.WriteLine(pc.ConvertToVB("csharp code"));
                    Console.WriteLine(pc.ConvertToCSharp("vb code"));
                }
            }
            Console.ReadKey();
        }
    }
}
