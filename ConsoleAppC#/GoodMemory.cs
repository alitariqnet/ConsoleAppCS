using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS
{
    internal class GoodMemory
    {
        public static void test()
        {
            char[] abc = { 'a','_','b','c' };
            Console.WriteLine(abc);
            Int128 a = new Int128(1, 2);
            Console.WriteLine(a);

        }
    }
}
