using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleAppCS;

internal class Account
{
    public string? Name { get; set; }
    public decimal Balance { get; set; }
}

public class AccountHelper
{
    public static async Task Test()
    {
        // Combine a directory and file name, then create the directory if it doesn't exist
        string directoryPath = @"C:\TempDir";
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        string fileName = "account.json";
        string filePath = Path.Combine(directoryPath, fileName);

        Account account = new Account { Name = "Elize Harmsen", Balance = 1000.00m };

        // Save account data to a file asynchronously
        string? jsonString = JsonSerializer.Serialize(account);
        await File.WriteAllTextAsync(filePath, jsonString);

        // Load account data from the file asynchronously
        jsonString = null;
        jsonString = await File.ReadAllTextAsync(filePath);
        
        Account? loadedAccount = JsonSerializer.Deserialize<Account>(jsonString);

        Console.WriteLine($"Name: {loadedAccount?.Name}, Balance: {loadedAccount?.Balance}");
    }
  
}