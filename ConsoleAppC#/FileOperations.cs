using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS
{
    internal class FileOperations
    {
        public static void TestDirectory()
        {
            string directoryPath = @"C:\ExampleDirectory";

            // Create a new directory
            Directory.CreateDirectory(directoryPath);

            // Check if the directory exists
            if (Directory.Exists(directoryPath))
            {
                Console.WriteLine("Directory exists.");

                // Enumerate files in the directory
                foreach (string file in Directory.EnumerateFiles(directoryPath))
                {
                    Console.WriteLine(file);
                }
            }
            else
            {
                Console.WriteLine("Directory does not exist.");
            }

        }

        public static void TestFile()
        {
            string filePath = @"C:\ExampleFile.txt";

            // Create a new file and write text to it
            File.WriteAllText(filePath, "Hello, World!");

            // Read the text from the file
            string text = File.ReadAllText(filePath);
            Console.WriteLine(text);
        }
    }
}
