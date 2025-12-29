using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS
{
    internal static class LetsDelegate
    {
        public delegate void PrintMyName(string name);

        // Declare a delegate.
        delegate void NotifyCallback(string str);

        // Declare a method with the same signature as the delegate.
        static void Notify(string name)
        { 
            Console.WriteLine($"Notification received for: {name}");
        }

        static void PrintName(string name)
        {
            Console.WriteLine(name);
        }
        public static int PrintStringLength(string str)
        {
            Console.WriteLine(str.Length);
            return 0;
        }

        public static void RunDelegateExample()
        {
            PrintMyName pmn = new(PrintName);
            pmn("Ali");

            NotifyCallback notifyCallback = new(Notify);
            notifyCallback("Notifying...");
        }

    }
}
