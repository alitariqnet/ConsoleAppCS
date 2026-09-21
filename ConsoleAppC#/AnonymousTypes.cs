using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS
{
    internal class AnonymousTypes
    {
        public static void Test()
        {
            var person = new { Name = "Alice", Age = 30 };
            Console.WriteLine($"{person.Name} is {person.Age} years old.");
            // Output:
            // Alice is 30 years old.
        }
    }
}
