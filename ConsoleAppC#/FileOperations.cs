using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS;

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
        try
        {

            string filePath = @"C:\ExampleFile.txt";
            if (File.Exists(filePath))
            {
                Console.WriteLine("File exists. Appending text to it.");
                File.AppendAllText(filePath, "\nThis file is created by Ali Tariq!");
            }
            else
            {
                Console.WriteLine("File does not exist. Creating a new file.");
                // Create a new file and write text to it
                File.WriteAllText(filePath, "Hallo, World!");
            }
            // Read the text from the file
            string text = File.ReadAllText(filePath);
            Console.WriteLine(text);
            string lines = File.ReadAllLines(filePath).ToString();
            Console.WriteLine(lines.ToString());
            string attributes = File.GetAttributes(filePath).ToString();
            Console.WriteLine($"File attributes: {attributes}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("File operation completed.");
        }
    }

    public static void StreamWriterTest()
    {
        string filePath = "C:\\data.csv";

        using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
        {
            // Write some data
            writer.WriteLine("Name,Age,Occupation");
            writer.WriteLine("Elize Harmsen,30,Engineer");
            writer.WriteLine("Peter Zammit,25,Designer");
            writer.WriteLine("Niki Demetriou,35,Manager");
        }

        Console.WriteLine($"CSV file created at: {filePath}");
    }
}
