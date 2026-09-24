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


            // string?  means this reference might be null
            // string   means this reference should not be null
            string? nullableName = null;
            string nonNullName = "Alice";

            // ?. safely accesses a member when the reference might be null
            string display = nullableName?.ToUpper() ?? "(no name)";
            Console.WriteLine(display);         // (no name)

            display = nonNullName.ToUpper();    // safe: nonNullName is never null
            Console.WriteLine(display);         // ALICE

            string? city = GetCity();

            // ?. — access a member only when non-null
            int? len = city?.Length;

            // ?? — substitute a default when null
            string _display = city ?? "unknown";

            // is null — preferred null test
            if (city is null)
            {
                Console.WriteLine("No city provided.");
            }
            else
            {
                Console.WriteLine($"{_display} ({len} chars)");
            }
            // Output: No city provided.

            string NewCity = "Doha";

            string? MyCity = "Lahore" ;

            // Null-coalescing assignment -- Assign only if MyCity is null
            MyCity ??= NewCity;

            Console.WriteLine($"MyCity: {MyCity}");
        }
        public static string GetCity()
        {
            return null;
        }
    }
}
