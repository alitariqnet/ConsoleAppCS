using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS
{
    internal class Nullifiers
    {
        public static void Test()
        {
            // Accessing a member on null throws NullReferenceException at runtime:
            // string? name = null;
            // int length = name.Length; // throws NullReferenceException

            // Check before you dereference:
            string? name = null;
            if (name is not null)
            {
                Console.WriteLine($"Name has {name.Length} characters.");
            }
            else
            {
                Console.WriteLine("Name has no value.");
            }
            // Output: Name has no value.
        }
    }
}
