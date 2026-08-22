using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleAppCS.Variables;

namespace ConsoleAppCS;

public class Variables
{

    /*
     * C# defines eight categories of variables: static variables, instance variables, array elements, value parameters, input parameters, reference parameters, output parameters, and local variables. The subclauses that follow describe each of these categories.
     */
    public static void Run()
    {
        int a = 1;
        int b = 2;
        int c;
        int d = 3;
        A.F(new int[] { 1, 2, 3 }, a, ref b, out c, in d);
        Console.WriteLine($"a: {a}, b: {b}, c: {c}, d: {d}");
    }
    public class A
    {
        public static int x;
        int y;

        public static void F(int[] v, int a, ref int b, out int c, in int d)
        {
            int i = 1;
            c = a + b++ + d;
        }

        /*
         * x is a static variable, y is an instance variable, v[0] is an array element, a is a value parameter, b is a reference parameter, c is an output parameter, d is an input parameter, and i is a local variable.
         * 
         */
    }
}
