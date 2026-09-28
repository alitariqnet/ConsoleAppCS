using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS;

internal class ActionDelegate
{
        static string? message = "Hello, I am Action delegate";
    public static void Test() {
        Action messageTarget = ActionDelegate.Display;

        messageTarget();
    }

    static void Display()
    {
        Console.WriteLine(message);
    }
}
