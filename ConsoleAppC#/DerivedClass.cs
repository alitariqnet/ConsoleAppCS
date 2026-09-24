using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS;

internal class DerivedClass : BaseClass
{
    new public static int x = 20;

    // Nested type hiding the base type members.
    new public class NestedC
    {
        public int x = 100;
        public int y;
        public int z;
    }

    public static void Test()
    {
        Console.WriteLine(x);
        Console.WriteLine(BaseClass.x);
        Console.WriteLine(y);

        // Creating an object from the overlapping class:
        NestedC c1 = new NestedC();

        // Creating an object from the hidden class:
        BaseClass.NestedC c2 = new BaseClass.NestedC();

        Console.WriteLine(c1.x);
        Console.WriteLine(c2.x);
    }
}
