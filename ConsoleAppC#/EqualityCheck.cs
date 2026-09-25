using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS
{
    internal class EqualityCheck
    {
        public static void Test()
        {
            //Console.WriteLine("a" == "a");
            //Console.WriteLine("a" == "a ");
            //Console.WriteLine("a" == "A");
            //Console.WriteLine(1 == 2);

            //string myValue = "a";
            //Console.WriteLine(myValue == "a");

            //string value1 = " a";
            //string value2 = "A ";
            //Console.WriteLine(value1.Trim().ToLower() == value2.Trim().ToLower());

            Console.WriteLine("a" != "a");
            Console.WriteLine("a" != "A");
            Console.WriteLine(1 != 2);

            string myValue = "a";
            Console.WriteLine(myValue != "a");
        }
    }
}
