using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;

namespace ConsoleAppCS;

//Data parallelism is a form of parallel programming that focuses on performing the same operation on multiple data elements simultaneously.
internal class DataParallelism
{
    public static void Test() 
    {
        //List<int> list = [1, 2, 3, 4, 5, 6, 7, 8, 9];

        // Sequential version
        //foreach (int item in list)
        //{
        //    Process(item);
        //}
        //Console.WriteLine();
        // Expected output:

        // Parallel equivalent
        //Parallel.ForEach(list, item => Process(item));

        //ConcurrentBagTest();

        //WhenAllTest();

        //MultipleFileIOConcurrently();

        HandleThreeTest();
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

    static async Task WhenAllTest()
    {
        var urls = new List<string>
        {
            "https://example.com",
            "https://example.org",
            "https://example.net"
        };

        var tasks = new List<Task<string>>();

        foreach (var url in urls)
        {
            tasks.Add(FetchDataAsync(url));
        }

        // Wait for all tasks to complete
        var results = await Task.WhenAll(tasks);

        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }
    static async Task<string> FetchDataAsync(string url)
    {
        using (var client = new HttpClient())
        {
            return await client.GetStringAsync(url);
        }
    }

    static void MultipleFileIOConcurrently()
    {
        try
        {
            TraverseTreeParallelForEach(@"C:\Program Files", (f) =>
            {
                // Exceptions are no-ops.
                try
                {
                    // Do nothing with the data except read it.
                    byte[] data = File.ReadAllBytes(f);
                }
                catch (FileNotFoundException) { }
                catch (IOException) { }
                catch (UnauthorizedAccessException) { }
                catch (SecurityException) { }
                // Display the filename.
                Console.WriteLine(f);
            });
        }
        catch (ArgumentException)
        {
            Console.WriteLine(@"The directory 'C:\Program Files' does not exist.");
        }

        // Keep the console window open.
        Console.ReadKey();
    }
    public static void TraverseTreeParallelForEach(string root, Action<string> action)
    {
        //Count of files traversed and timer for diagnostic output
        int fileCount = 0;
        var sw = Stopwatch.StartNew();

        // Determine whether to parallelize file processing on each folder based on processor count.
        int procCount = Environment.ProcessorCount;

        // Data structure to hold names of subfolders to be examined for files.
        Stack<string> dirs = new Stack<string>();

        if (!Directory.Exists(root))
        {
            throw new ArgumentException(
                "The given root directory doesn't exist.", nameof(root));
        }
        dirs.Push(root);

        while (dirs.Count > 0)
        {
            string currentDir = dirs.Pop();
            string[] subDirs = { };
            string[] files = { };

            try
            {
                subDirs = Directory.GetDirectories(currentDir);
            }
            // Thrown if we do not have discovery permission on the directory.
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            // Thrown if another process has deleted the directory after we retrieved its name.
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }

            try
            {
                files = Directory.GetFiles(currentDir);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }

            // Execute in parallel if there are enough files in the directory.
            // Otherwise, execute sequentially.Files are opened and processed
            // synchronously but this could be modified to perform async I/O.
            try
            {
                if (files.Length < procCount)
                {
                    foreach (var file in files)
                    {
                        action(file);
                        fileCount++;
                    }
                }
                else
                {
                    Parallel.ForEach(files, () => 0,
                        (file, loopState, localCount) =>
                        {
                            action(file);
                            return (int)++localCount;
                        },
                        (c) =>
                        {
                            Interlocked.Add(ref fileCount, c);
                        });
                }
            }
            catch (AggregateException ae)
            {
                ae.Handle((ex) =>
                {
                    if (ex is UnauthorizedAccessException)
                    {
                        // Here we just output a message and go on.
                        Console.WriteLine(ex.Message);
                        return true;
                    }
                    // Handle other exceptions here if necessary...

                    return false;
                });
            }

            // Push the subdirectories onto the stack for traversal.
            // This could also be done before handing the files.
            foreach (string str in subDirs)
                dirs.Push(str);
        }

        // For diagnostic purposes.
        Console.WriteLine($"Processed {fileCount} files in {sw.ElapsedMilliseconds} milliseconds");
    }

    static void HandleThreeTest()
    {
        HandleThree();
    }

    public static void HandleThree()
    {
        var task = Task.Run(
            () => throw new CustomException("This exception is expected!"));

        try
        {
            task.Wait();
        }
        catch (AggregateException ae)
        {
            foreach (var ex in ae.InnerExceptions)
            {
                // Handle the custom exception.
                if (ex is CustomException)
                {
                    Console.WriteLine(ex.Message);
                }
                // Rethrow any other exception.
                else
                {
                    throw ex;
                }
            }
        }
    }

    // Define the CustomException class
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
    }
    // The example displays the following output:
    //    

    static void HandleFour()
    {
        var task = Task.Run(
            () => throw new CustomException("This exception is expected!"));

        try
        {
            task.Wait();
        }
        catch (AggregateException ae)
        {
            ae.Handle(ex =>
            {
                // Handle the custom exception.
                if (ex is CustomException)
                {
                    Console.WriteLine(ex.Message);
                    return true;
                }
                // Rethrow any other exception.
                return false;
            });
        }
    }
}
