using Humanizer;
using System.Net.Http.Headers;

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppCS;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("==============");
        //CollectionsPractice collectionsPractice = new CollectionsPractice();
        //collectionsPractice.DoPractice();
        //ValueTypeExample.Maine();
        //NullableType.Maine();
        //SomeQueues.Maine();
        //ConcurrentBagDemo.Man();
        //Example.Man();
        //SealIt.RunSealedLogic();
        //HumanizeQuantities();
        //HumanizeDates();
        //StaticCharge.PrintClassName();
        //Program2.Man();

        //LetsDelegate.RunDelegateExample();

        //HttpRequest.MainAsync().GetAwaiter().GetResult();

        //Variables.Run();

        //Conversions.conversion();

        //Exceptions.exceptions();

        //GoodMemory.test();

        //Enums.currentSeason();

        //FileOperations.BinaryReadWriteEncodingTest();

        //LINQquery.Test();

        ExecutionOfAnIterator();

        Console.WriteLine("==============");
    }

    

    public static void ExecutionOfAnIterator()
    {
        //source: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield

        var numbers = ProduceEvenNumbers(5);
        Console.WriteLine("Caller: about to iterate.");
        foreach (int i in numbers)
        {
            Console.WriteLine($"foreach loop runs");
            Console.WriteLine($"Caller: {i}");
        }

        IEnumerable<int> ProduceEvenNumbers(int upto)
        {
            Console.WriteLine("Iterator: start.");
            for (int i = 0; i <= upto; i += 2)
            {
                Console.WriteLine($"for loop runs");

                Console.WriteLine($"Iterator: about to yield {i}");
                yield return i;
                Console.WriteLine($"Iterator: yielded {i}");
            }
            Console.WriteLine("Iterator: end.");
        }
        // Output:
        // Caller: about to iterate.
        // Iterator: start.
        // Iterator: about to yield 0
        // Caller: 0
        // Iterator: yielded 0
        // Iterator: about to yield 2
        // Caller: 2
        // Iterator: yielded 2
        // Iterator: about to yield 4
        // Caller: 4
        // Iterator: yielded 4
        // Iterator: end.
    }

    public static void YieldTest() 
    
    
   { 
    
    }

    static void HumanizeQuantities()
{
Console.WriteLine("case".ToQuantity(0));
Console.WriteLine("case".ToQuantity(1));
Console.WriteLine("case".ToQuantity(5));
}

static void HumanizeDates()
{
Console.WriteLine(DateTime.UtcNow.AddHours(-24).Humanize());
Console.WriteLine(DateTime.UtcNow.AddHours(-2).Humanize());
Console.WriteLine(TimeSpan.FromDays(1).Humanize());
Console.WriteLine(TimeSpan.FromDays(16).Humanize());
}

    int multiplier(int x, int y)
    {
        return x * y;
    }

    int multiplier(int x, int y, int z)
    {
        return x * y * z;
    }

    static void switchTest()
    {
        int x = 1;
        switch (x)
        {
            case 0:
                int y;
                break;
            case var z when z < 10:
                break;
            default:
                y = 10;
                // Valid: y is in scope
                Console.WriteLine(x + y);
                // Invalid: z is not scope
                //Console.WriteLine(x + z);
                break;
        }
    }

    public static void Enumerabling()
    {

        //List<int> list = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    }

}


public class App
{
    // Exercise the Iterator and show that it's more
    // performant.
    public static void _Main()
    {
        TestStreamReaderEnumerable();
        Console.WriteLine("---");
        TestReadingFile();
    }

    public static void TestStreamReaderEnumerable()
    {
        // Check the memory before the iterator is used.
        long memoryBefore = GC.GetTotalMemory(true);
        IEnumerable<String> stringsFound;
        // Open a file with the StreamReaderEnumerable and check for a string.
        try
        {
            stringsFound =
                  from line in new StreamReaderEnumerable(@"c:\temp\tempFile.txt")
                  where line.Contains("string to search for")
                  select line;
            Console.WriteLine("Found: " + stringsFound.Count());
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine(@"This example requires a file named C:\temp\tempFile.txt.");
            return;
        }

        // Check the memory after the iterator and output it to the console.
        long memoryAfter = GC.GetTotalMemory(false);
        Console.WriteLine("Memory Used With Iterator = \t"
            + string.Format(((memoryAfter - memoryBefore) / 1000).ToString(), "n") + "kb");
    }

    public static void TestReadingFile()
    {
        long memoryBefore = GC.GetTotalMemory(true);
        StreamReader sr;
        try
        {
            sr = File.OpenText("c:\\temp\\tempFile.txt");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine(@"This example requires a file named C:\temp\tempFile.txt.");
            return;
        }

        // Add the file contents to a generic list of strings.
        List<string> fileContents = new List<string>();
        while (!sr.EndOfStream)
        {
            fileContents.Add(sr.ReadLine());
        }

        // Check for the string.
        var stringsFound =
            from line in fileContents
            where line.Contains("string to search for")
            select line;

        sr.Close();
        Console.WriteLine("Found: " + stringsFound.Count());

        // Check the memory after when the iterator is not used, and output it to the console.
        long memoryAfter = GC.GetTotalMemory(false);
        Console.WriteLine("Memory Used Without Iterator = \t" +
            string.Format(((memoryAfter - memoryBefore) / 1000).ToString(), "n") + "kb");
    }
}

// A custom class that implements IEnumerable(T). When you implement IEnumerable(T),
// you must also implement IEnumerable and IEnumerator(T).
public class StreamReaderEnumerable : IEnumerable<string>
{
    private string _filePath;
    public StreamReaderEnumerable(string filePath)
    {
        _filePath = filePath;
    }

    // Must implement GetEnumerator, which returns a new StreamReaderEnumerator.
    public IEnumerator<string> GetEnumerator()
    {
        return new StreamReaderEnumerator(_filePath);
    }

    // Must also implement IEnumerable.GetEnumerator, but implement as a private method.
    private IEnumerator GetEnumerator1()
    {
        return this.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator1();
    }
}

// When you implement IEnumerable(T), you must also implement IEnumerator(T),
// which will walk through the contents of the file one line at a time.
// Implementing IEnumerator(T) requires that you implement IEnumerator and IDisposable.
public class StreamReaderEnumerator : IEnumerator<string>
{
    private StreamReader _sr;
    public StreamReaderEnumerator(string filePath)
    {
        _sr = new StreamReader(filePath);
    }

    private string _current;
    // Implement the IEnumerator(T).Current publicly, but implement
    // IEnumerator.Current, which is also required, privately.
    public string Current
    {

        get
        {
            if (_sr == null || _current == null)
            {
                throw new InvalidOperationException();
            }

            return _current;
        }
    }

    private object Current1
    {

        get { return this.Current; }
    }

    object IEnumerator.Current
    {
        get { return Current1; }
    }

    // Implement MoveNext and Reset, which are required by IEnumerator.
    public bool MoveNext()
    {
        _current = _sr.ReadLine();
        if (_current == null)
            return false;
        return true;
    }

    public void Reset()
    {
        _sr.DiscardBufferedData();
        _sr.BaseStream.Seek(0, SeekOrigin.Begin);
        _current = null;
    }

    // Implement IDisposable, which is also implemented by IEnumerator(T).
    private bool disposedValue = false;
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposedValue)
        {
            if (disposing)
            {
                // Dispose of managed resources.
            }
            _current = null;
            if (_sr != null)
            {
                _sr.Close();
                _sr.Dispose();
            }
        }

        this.disposedValue = true;
    }

    ~StreamReaderEnumerator()
    {
        Dispose(disposing: false);
    }
}
// This example displays output similar to the following:
//       Found: 2
//       Memory Used With Iterator =     33kb
//       ---
//       Found: 2
//       Memory Used Without Iterator =  206kb