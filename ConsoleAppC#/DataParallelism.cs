using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ConsoleAppCS;

//Data parallelism is a form of parallel programming that focuses on performing the same operation on multiple data elements simultaneously.
internal class DataParallelism
{
    public static void Test() 
    {
        List<int> list = [1, 2, 3, 4, 5, 6, 7, 8, 9];

        // Sequential version
        foreach (int item in list)
        {
            Process(item);
        }
        Console.WriteLine();
        // Expected output:

        // Parallel equivalent
        Parallel.ForEach(list, item => Process(item));

        ConcurrentBagTest();
    }

    static void Process(int item)
    {
        Console.Write(item);
        Console.Write(' '); // here even this space is not guaranteed to be printed immediately after item
        //Following are two outputs of two different runs:
        //1 2 3 4 5 6 7 8 9
        //3 9 6 8 5 7 1 42 ============== // see it is not 42 it is 4 and 2 but space was not printed after 4
        //
        //1 2 3 4 5 6 7 8 9
        //6 7 1 5 3 2 8 9 4 ==============
    }

    static void ConcurrentBagTest()
    {
        var results = new ConcurrentBag<int>();
        Parallel.For(0, 1000, i =>
        {
            // Simulate some work
            Task.Delay(10).Wait();
            results.Add(i);
        });
        //Parallel.ForEach(results, item => Process(item));
        foreach (int item in results)
        {
            Process(item);
        }
        Console.WriteLine($"Processed {results.Count} items in parallel.");
    }
}
