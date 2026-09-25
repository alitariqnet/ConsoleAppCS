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
            string? lines = File.ReadAllLines(filePath).ToString();
            Console.WriteLine(lines?.ToString());
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

    public static void StreamReaderTest()
    {
        string filePath = "C:\\data.csv";
        using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }

    public static void FileStreamWriteTest()
    {
        string path = "C:\\example.txt";
        byte[] data = System.Text.Encoding.UTF8.GetBytes("Hello, FileStream!");

        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
        {
            fs.Write(data, 0, data.Length);
        }

        Console.WriteLine("Data written to file.");
    }

    public static void FileStreamReadTest()
    {
        string path = "C:\\example.txt";
        byte[] buffer = new byte[10]; // Adjust buffer size as needed

        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            int bytesRead = fs.Read(buffer, 0, buffer.Length);
            string readData = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Data read from file: " + readData);
        }
    }
    
    public static Task SeekTest()
    {
        string path = "example.txt";
        byte[] data = System.Text.Encoding.UTF8.GetBytes("Hello, FileStream!");

        // Writing to the file
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
        {
            fs.Write(data, 0, data.Length);
            fs.Flush();
        }

        // Reading from the file
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[data.Length];
            fs.Seek(0, SeekOrigin.Begin);
            int bytesRead = fs.Read(buffer, 0, buffer.Length);
            string readData = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Data read from file: " + readData);
        }
        return Task.CompletedTask;
    }

    public static void BinaryReadWriteTest()
    {
        // Create a file to write to
        using (FileStream fs = new FileStream("C:\\example.dat", FileMode.Create))
        {
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                // Write some data
                writer.Write(42); // Integer
                writer.Write(3.14); // Double
                writer.Write("Hello, World!"); // String
            }
        }

        // Read the data back
        using (FileStream fs = new FileStream("C:\\example.dat", FileMode.Open))
        {
            using (BinaryReader reader = new BinaryReader(fs))
            {
                int intValue = reader.ReadInt32();
                double doubleValue = reader.ReadDouble();
                string stringValue = reader.ReadString();

                Console.WriteLine($"Integer: {intValue}");
                Console.WriteLine($"Double: {doubleValue}");
                Console.WriteLine($"String: {stringValue}");
            }
        }
    }

    public static void BinaryReadWriteEncodingTest()
    {
        // Create a file to write to
        using (FileStream fs = new FileStream("C:\\example-encoding.dat", FileMode.Create))
        {
            using (BinaryWriter writer = new BinaryWriter(fs, Encoding.UTF8))
            {
                // Write some data with UTF-8 encoding
                writer.Write(42); // Integer
                writer.Write(3.14); // Double
                writer.Write("Hello, World!"); // String
            }
        }

        // Read the data back
        using (FileStream fs = new FileStream("C:\\example-encoding.dat", FileMode.Open))
        {
            using (BinaryReader reader = new BinaryReader(fs, Encoding.UTF8))
            {
                int intValue = reader.ReadInt32();
                double doubleValue = reader.ReadDouble();
                string stringValue = reader.ReadString();

                Console.WriteLine($"Integer: {intValue}");
                Console.WriteLine($"Double: {doubleValue}");
                Console.WriteLine($"String: {stringValue}");
            }
        }
    }


}
