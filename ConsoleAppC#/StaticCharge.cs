using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS
{
    internal static class StaticCharge
    {
        public static void PrintClassName()
        {
            Console.WriteLine("StaticCharge");
            OnlyFromThisFile.PrintClassName();
        }
    }
    file class OnlyFromThisFile
    {
        public static void PrintClassName()
        {
            Console.WriteLine("OnlyFromThisFile");
        }
    }
}
