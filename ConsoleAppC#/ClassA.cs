using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static ConsoleAppCS.Variables;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleAppCS
{
    internal class ClassA
    {

        //Note: As specified above, the declaration space of a block includes any nested blocks.Thus, in the following example, the F and G methods result in a compile-time error because the name i is declared in the outer block and cannot be redeclared in the inner block.However, the H and I methods are valid since the two i’s are declared in separate non-nested blocks.

        void F()
        {
            int i = 0;
            if (true)
            {
                //int i = 1;
            }
        }

        void G()
        {
            if (true)
            {
                //int i = 0;
            }
            int i = 1;
        }

        void H()
        {
            if (true)
            {
                int i = 0;
            }
            if (true)
            {
                int i = 1;
            }
        }

        void I()
        {
            for (int i = 0; i < 10; i++)
            {
                H();
            }
            for (int i = 0; i < 10; i++)
            {
                H();
            }
        }
    }
}
