using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS
{
    internal class RefType
    {
        public static void Test()
        {
            int value = 40;
            
            Console.WriteLine(value);
            
            Console.WriteLine(PassByValue(value));
            
            // value will remain 40
            Console.WriteLine(value);
            
            Console.WriteLine(PassByRef(ref value));
            
            // value will be 80
            Console.WriteLine(value);
        }
        public static int PassByValue(int val)
        {
            Console.WriteLine(val);
            val = val + val;
            Console.WriteLine(val);
            return val;
        }

        public static int PassByRef(ref int val)
        {
            Console.WriteLine(val);
            val = val + val;
            Console.WriteLine(val);
            return val;
        }
    }
}
