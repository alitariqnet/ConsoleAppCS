using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS
{
    internal class Exceptions
    {
        public static void exceptions()
        {
            //ArgumentException invalidArgumentException = new ArgumentException("ArgumentException: The 'GraphData' method received data outside the expected range.");
            //throw invalidArgumentException;
            try
            {
                throw new FormatException("FormatException: Calculations in process XYZ have been cancelled due to invalid data format.");
            }
            catch (FormatException fe)

            {
                Console.WriteLine(fe.Message);
            }
            finally
            {
                Console.WriteLine("Finally block");
            }
        }
    }
}
