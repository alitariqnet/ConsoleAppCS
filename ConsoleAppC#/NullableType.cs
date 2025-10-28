using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS
{
    internal class NullableType
    {
        public static void Maine()
        {
            double? pi = 3.14;
            char? letter = 'a';

            int m2 = 10;
            int? m = m2;

            bool? flag = null;
            Console.WriteLine(flag); 

            // An array of a nullable value type:
            int?[] arr = new int?[10];
        }
    }
}
