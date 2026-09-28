using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS;

internal class CustomDelegate
{
    public delegate int PerformCalculation(int x, int y);

    public static void Test()
    {
        CustomDelegate TestCustomDelegate = new();
        PerformCalculation pc = TestCustomDelegate.PerformCalc;
        int result = pc(1, 2);
        Console.WriteLine(result);
    }

    int PerformCalc(int x, int y)
    {
        return x + y;
    }

}
